﻿using Newtonsoft.Json;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.ExternalFileImport.Import;
using Obligatorio.ExternalFileImport.Models;
using Obligatorio.ImportLogic.CustomExceptions;
using Obligatorio.ImportLogicInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace Obligatorio.ImportLogic.Logics
{
    public class ImportLogic : IImportLogic
    {

        private readonly ITouristSpotLogic touristSpotLogic;
        private readonly IAccommodationLogic accommodationLogic;

        public ImportLogic(ITouristSpotLogic touristSpotLogic, IAccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
            this.touristSpotLogic = touristSpotLogic;
        }

        public List<string> GetImplementationNames()
        {
            Assembly jsonAssembly = Assembly.LoadFile("D:\\Documentos\\ORT\\DA2\\Barrios_Irabedra\\Back end\\Obligatorio.JsonImport\\bin\\Debug\\netstandard2.0\\Obligatorio.JsonImport.dll"); //corregir path
            Assembly xmlAssembly = Assembly.LoadFile("D:\\Documentos\\ORT\\DA2\\Barrios_Irabedra\\Back end\\Obligatorio.XmlImport\\bin\\Debug\\netstandard2.0\\Obligatorio.XmlImport.dll"); //corregir path
            return FindImplementations(new List<Assembly> { jsonAssembly, xmlAssembly });
        }

        private List<string> FindImplementations(List<Assembly> list)
        {
            List<string> ret = new List<string>();
            IEnumerable<Type> implementations;
            foreach (var item in list)
            {
                implementations = item.GetTypes().Where(t => typeof(IAccommodationImport).IsAssignableFrom(t));
                foreach (var imp in implementations)
                {
                    ret.Add(imp.FullName);
                }
            }
            return ret;
        }

        public bool Import(string path, string type)
        {
            try
            {
                IAccommodationImport requestedImplementation = GetImplementation(path, type);
                AccommodationImportModel imported = requestedImplementation.CreateObjectModel(path);
                TouristSpotImportModel tsm = imported.TouristSpot;
                TouristSpot ts = tsm.ToEntity();
                if (!this.touristSpotLogic.AlreadyExistsByName(tsm.Name))
                {
                    this.touristSpotLogic.Add(ts);
                }
                if (!this.accommodationLogic.AlreadyExistsByName(imported.Name))
                {
                    Accommodation acc = imported.ToEntity();
                    acc.TouristSpot = this.touristSpotLogic.GetByName(ts.Name);
                    this.accommodationLogic.Add(acc, this.touristSpotLogic.GetByName(ts.Name).Id);
                    return true;
                }

                return false;
            }
            catch (JsonReaderException)
            {
                throw new FileIsNotJsonException();
            }
        }

        private IAccommodationImport GetImplementation(string path, string type)
        {
            if (type.ToLower().Equals("xml"))
            {
                Assembly xmlAssembly = Assembly.LoadFrom("D:\\Documentos\\ORT\\DA2\\Barrios_Irabedra\\Back end\\Obligatorio.XmlImport\\bin\\Debug\\netstandard2.0\\Obligatorio.XmlImport.dll");
                foreach (var item in xmlAssembly.GetTypes().Where(t => typeof(IAccommodationImport).IsAssignableFrom(t)))
                {
                    if (item.FullName.ToLower().Contains("xml"))
                    {
                        return Activator.CreateInstance(item) as IAccommodationImport;
                    }
                }
            }
            if (type.ToLower().Equals("json"))
            {
                Assembly jsonAssembly = Assembly.LoadFrom("D:\\Documentos\\ORT\\DA2\\Barrios_Irabedra\\Back end\\Obligatorio.JsonImport\\bin\\Debug\\netstandard2.0\\Obligatorio.JsonImport.dll");
                foreach (var item in jsonAssembly.GetTypes().Where(t => typeof(IAccommodationImport).IsAssignableFrom(t)))
                {
                    if (item.FullName.ToLower().Contains("json"))
                    {
                        return Activator.CreateInstance(item) as IAccommodationImport;
                    }
                }
            }
            throw new DllNotFoundException("File format must be xml or json");
        }

    }
}