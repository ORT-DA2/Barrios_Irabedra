using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using System;

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
            catch (Exception ex) 
            {
                throw new RepeatedObjectException();
            }
        }

        public void Delete(string email)
        {
            this.adminRespository.Delete(email);
        }

        public bool IsValidAdmin(string email, string password)
        {
            bool isValid = adminRespository.IsValidAdmin(email, password);
            return isValid;
        }

        public void Update(string email, Admin value)
        {
            this.adminRespository.Update(email, value);
        }
    }
}
