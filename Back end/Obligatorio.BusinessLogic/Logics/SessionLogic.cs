using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.SessionInterface;

namespace Obligatorio.BusinessLogic.Logics
{
    public class SessionLogic : ISessionLogic
    {
        private readonly IAdminLogic adminLogic;

        public SessionLogic(IAdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

   
        public void Add(Admin admin)
        {
            this.adminLogic.Add(admin);
        }

        public string GetAdminToken()
        {
            string adminToken = "admin";
            return adminToken;
        }

        public bool IsCorrectToken(string token)
        {
            return token == GetAdminToken();
        }

        public bool IsValidAdmin(string email, string password)
        {
            bool validAdmin = adminLogic.IsValidAdmin(email, password);
            return validAdmin;
        }


    }
}
