using Newtonsoft.Json;
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
        private readonly IRegionLogic regionLogic;

        public ImportLogic(ITouristSpotLogic touristSpotLogic, IAccommodationLogic accommodationLogic, IRegionLogic regionLogic)
        {
            this.accommodationLogic = accommodationLogic;
            this.touristSpotLogic = touristSpotLogic;
            this.regionLogic = regionLogic;
        }

        public List<string> GetImplementationNames(string jsonPath, string xmlPath)
        {
            Assembly jsonAssembly = Assembly.LoadFrom(jsonPath);
            Assembly xmlAssembly = Assembly.LoadFrom(xmlPath); 
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

        public bool Import(string binaryPath, string filePath,  string type)
        {
            try
            {
                IAccommodationImport requestedImplementation = GetImplementation(binaryPath, type);
                AccommodationImportModel imported = requestedImplementation.CreateObjectModel(filePath);
                TouristSpotImportModel tsm = imported.TouristSpot;
                TouristSpot ts = tsm.ToEntity();
                if (regionLogic.Get(tsm.RegionName).Name == tsm.RegionName)
                {
                    if (!this.touristSpotLogic.AlreadyExistsByName(tsm.Name))
                    {
                        this.touristSpotLogic.Add(ts);
                        this.regionLogic.AddTouristSpotToRegion(tsm.RegionName, tsm.Name);
                    }
                }
                if (!this.accommodationLogic.AlreadyExistsByName(imported.Name) && this.touristSpotLogic.AlreadyExistsByName(tsm.Name))
                {
                    Accommodation acc = imported.ToEntity();
                    acc.TouristSpot = this.touristSpotLogic.GetByName(ts.Name);
                    this.accommodationLogic.Add(acc, this.touristSpotLogic.GetByName(ts.Name).Name);
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
                Assembly xmlAssembly = Assembly.LoadFrom(path);
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
                Assembly jsonAssembly = Assembly.LoadFrom(path);
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
