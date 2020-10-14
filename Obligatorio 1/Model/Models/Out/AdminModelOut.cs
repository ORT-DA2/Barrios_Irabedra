﻿using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.Model.Models.Out
{
    public class AdminModelOut
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AdminModelOut(Admin adminToRegister)
        {
            this.Name = adminToRegister.Name;
            this.Email = adminToRegister.Email;
            this.Password = adminToRegister.Password;
        }
    }
}