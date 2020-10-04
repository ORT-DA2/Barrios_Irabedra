using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccess.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Category> categories;


        public CategoryRepository(DbContext myContext)
        {
            this.myContext = myContext;
            this.categories = myContext.Set<Category>();
        }

        public Category Get(string name)
        {
            var category = Find(name);
            if (category is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return category;
        }

        public Category Find(string name)
        {
            foreach (var item in this.categories)
            {
                if (item.Name.Equals(name))
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories;
        }

        public void Add(Category newEntity)
        {
            if (AlreadyExistsByName(newEntity))
            {
                throw new RepeatedObjectException();
            }
            else
            {
                categories.Add(newEntity);
                myContext.SaveChanges();
            }
        }
        private bool AlreadyExistsByName(Category newEntity)
        {
            foreach (var r in this.categories)
            {
                if (r.Name == newEntity.Name)
                {
                    return true;
                }
            }
            return false;
        }


        public void Update(Category category)
        {
            categories.Update(category);
            myContext.SaveChanges();
        }

        public void Add(Category category, TouristSpotCategory touristSpotCategory)
        {
            category.TouristSpotCategories.Add(touristSpotCategory);
            this.categories.Update(category);
            myContext.SaveChanges();
        }
    }
}