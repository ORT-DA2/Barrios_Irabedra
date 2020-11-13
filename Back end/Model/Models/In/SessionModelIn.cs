using Obligatorio.Domain.DomainEntities;
using System;

namespace Obligatorio.Model.Models.In
{
    public class SessionModelIn
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public SessionModelIn()
        {
        }

        public Admin ToEntity()
        {
            return new Admin
            {
                Email = this.Email,
                Password = this.Password
            };
        }
    }
}
