using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAdminLogic
    {
        bool IsValidAdmin(string email, string password);
        void Add(Admin adminToRegister);
        void Delete(string email);
        void Update(string email, Admin value);
    }
}
