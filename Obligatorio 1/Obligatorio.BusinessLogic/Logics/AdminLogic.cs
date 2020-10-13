using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class AdminLogic : IAdminLogic
    {
        private readonly IAdminRepository adminRespository;

        public AdminLogic(IAdminRepository adminRespository)
        {
            this.adminRespository = adminRespository;
        }
    }
}
