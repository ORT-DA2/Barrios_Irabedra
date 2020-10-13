using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain.DomainEntities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Admin()
        {
            this.Name = "Default Name";
            this.Email = "Default Email";
            this.Password = "Default Password";
        }

        public override bool Equals(object obj)
        {
            return obj is Admin admin &&
                   Email == admin.Email;
        }
    }
}
