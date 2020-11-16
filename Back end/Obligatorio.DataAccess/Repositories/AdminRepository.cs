using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccess.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Admin adminToRegister)
        {
            if (IsRepetedAdmin(adminToRegister)) 
            {
                throw new RepeatedObjectException();
            }
            else 
            {
                admins.Add(adminToRegister);
                myContext.SaveChanges();
            }
        }

        public void Delete(string email)
        {
            Admin adminToDelete = FindByEmail(email);
            if(adminToDelete is null)
            {
                throw new Obligatorio.BusinessLogic.CustomExceptions.ObjectNotFoundInDatabaseException();
            }
            else
            {
                myContext.Entry(adminToDelete).State = EntityState.Deleted;
                admins.Remove(adminToDelete);
                myContext.SaveChanges();
            }
        }

        private Admin FindByEmail(string email)
        {
            List<Admin> admins = this.admins.ToList();
            foreach (var item in admins)
            {
                if(item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }

        public bool IsRepetedAdmin(Admin adminToVerify)
        {
            List<Admin> adminsToValidate = admins.ToList();
            bool isRepeted = false;
            foreach (var item in adminsToValidate)
            {
                if (item.Email == adminToVerify.Email)
                {
                    isRepeted = true;
                }
            }
            return isRepeted;
        }

        public bool IsValidAdmin(string email, string password)
        {
            List<Admin> adminsToValidate = admins.ToList();
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

        public void Update(string email, Admin value)
        {
            Admin adminFound = FindByEmail(email);
            if(adminFound is null)
            {
                throw new Obligatorio.BusinessLogic.CustomExceptions.ObjectNotFoundInDatabaseException();
            }
            else
            {
                adminFound.Name = value.Name;
                adminFound.Password = value.Password;
                myContext.Entry(adminFound).State = EntityState.Modified;
                myContext.SaveChanges();
            }
        }
    }
}
