using Newtonsoft.Json;
using Obligatorio.ExternalFileImport.Import;
using Obligatorio.ExternalFileImport.Models;
using System;
using System.IO;

namespace Obligatorio.JsonImport.Logics
{
    public class JsonAccommodationImport : IAccommodationImport
    {

        public AccommodationImportModel CreateObjectModel(string path)
        {
            AccommodationImportModel acc = JsonConvert.DeserializeObject<AccommodationImportModel>(File.ReadAllText(path));
            return acc;
        }
    }
}
