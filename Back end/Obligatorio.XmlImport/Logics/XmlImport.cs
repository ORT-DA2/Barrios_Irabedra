using Obligatorio.ExternalFileImport.Import;
using Obligatorio.ExternalFileImport.Models;
using Obligatorio.ImportLogicInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Obligatorio.XmlImport.Logics
{
    public class XmlAccommodationImport : IAccommodationImport
    {
        public AccommodationImportModel CreateObjectModel(string path)
        {
            var mySerializer = new XmlSerializer(typeof(AccommodationImportModel));
            var myFileStream = new FileStream(path, FileMode.Open);
            var myObject = (AccommodationImportModel)mySerializer.Deserialize(myFileStream);
            return myObject;
        }
    }
}