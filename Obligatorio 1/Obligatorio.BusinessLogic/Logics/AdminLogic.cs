using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
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

        public void Add(Admin adminToRegister)
        {
            try
            {
                this.adminRespository.Add(adminToRegister);
            }
            catch (RepeatedObjectException e)
            {

                throw new RepeatedObjectException();
            }
            catch (Exception ex) 
            {
                throw new Exception();
            }
        }

        public bool IsValidAdmin(string email, string password)
        {
            bool isValid = adminRespository.IsValidAdmin(email, password);
            return isValid;
        }
    }
}
