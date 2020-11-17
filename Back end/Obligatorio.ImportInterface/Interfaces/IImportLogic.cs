using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.ImportLogicInterface.Interfaces
{
    public interface IImportLogic
    {
        List<string> GetImplementationNames(string jsonPath, string xmlPath);
        bool Import(string path, string type); //type tiene que ser XML o JSON ignorando el case. 
    }
}
