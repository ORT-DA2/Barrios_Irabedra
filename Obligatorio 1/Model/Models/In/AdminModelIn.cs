using System;
using System.Collections.Generic;
using System.Text;

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
            this.Email = "Default Password";
        }
    }
}
