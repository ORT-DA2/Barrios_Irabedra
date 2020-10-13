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

    }
}
