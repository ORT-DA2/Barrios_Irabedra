using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.Model.Models.In
{
    public class AdminModelIn
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AdminModelIn()
        {
            this.Name = "Default Name";
            this.Email = "Default Email";
            this.Password = "Default Password";
        }

        public AdminModelIn(Admin anAdmin)
        {
            this.Name = anAdmin.Name;
            this.Email = anAdmin.Email;
            this.Password = anAdmin.Password;
        }

        public Admin ToEntity()
        {
            Admin adminToReturn = new Admin();
            adminToReturn.Name = this.Name;
            adminToReturn.Email = this.Email;
            adminToReturn.Password = this.Password;
            return adminToReturn;
        }
    }
}
