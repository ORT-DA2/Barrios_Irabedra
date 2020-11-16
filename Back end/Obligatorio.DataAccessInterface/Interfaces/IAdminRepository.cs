using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IAdminRepository
    {
        bool IsValidAdmin(string email, string password);
        void Add(Admin adminToRegister);
        void Delete(string email);
        void Update(string email, Admin value);
    }
}
