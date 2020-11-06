using Obligatorio.ExternalFileImport.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Obligatorio.ExternalFileImport.Import
{
    public interface IAccommodationImport
    {
        AccommodationImportModel CreateObjectModel(string path);
    }
}
