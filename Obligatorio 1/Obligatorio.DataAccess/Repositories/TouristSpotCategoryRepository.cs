using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio.DataAccess.Repositories
{
    public class TouristSpotCategoryRepository : ITouristSpotCategoryRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<TouristSpotCategory> touristSpotCategories;

        public TouristSpotCategoryRepository(DbContext context)
        {
            this.myContext = context;
            this.touristSpotCategories = context.Set<TouristSpotCategory>();
        }

        public void UpdateCategoryAndTouristSpot(Category category, TouristSpot touristSpot)
        {
            IList<TouristSpotCategory> list = this.touristSpotCategories.ToList<TouristSpotCategory>();
            foreach (var item in list)
            {
                if (category.Id == item.CategoryId && touristSpot.Id == item.TouristSpotId)
                {
                    item.Category = category;
                    item.TouristSpot = touristSpot;
                    myContext.Update(item);
                    myContext.SaveChanges();
                }
            }
        }

        public IEnumerable<TouristSpotCategory> GetAll()
        {
            IList<TouristSpotCategory> list = this.touristSpotCategories.ToList<TouristSpotCategory>();
            return list;
        }

        public void Add(Category category, TouristSpot touristSpot)
        {
            bool valid = true;
            IList<TouristSpotCategory> list = this.touristSpotCategories.ToList<TouristSpotCategory>();
            foreach (var item in list)
            {
                if (category.Id == item.CategoryId && touristSpot.Id == item.TouristSpotId)
                {
                    valid = false;
                }
            }
            if (valid)
            {
                TouristSpotCategory ts = new TouristSpotCategory
                {
                    Category = category,
                    CategoryId = category.Id,
                    TouristSpot = touristSpot,
                    TouristSpotId = touristSpot.Id
                };
                this.touristSpotCategories.Add(ts);
                this.myContext.SaveChanges();
            }
        }
    }
}
