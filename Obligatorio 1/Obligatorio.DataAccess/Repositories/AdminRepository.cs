using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Admin> admins;

        public AdminRepository(DbContext context)
        {
            this.myContext = context;
            this.admins = context.Set<Admin>();
        }

        public bool IsValidAdmin(string email, string password)
        {
            List<Admin> adminsToValidate = new List<Admin>();
            bool isValid = false;
            foreach (var item in adminsToValidate)
            {
                if((item.Email == email) && (item.Password == password)) 
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
