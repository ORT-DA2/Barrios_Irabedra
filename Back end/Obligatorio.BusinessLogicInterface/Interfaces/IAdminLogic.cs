using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAdminLogic
    {
        bool IsValidAdmin(string email, string password);
        void Add(Admin adminToRegister);
    }
}
