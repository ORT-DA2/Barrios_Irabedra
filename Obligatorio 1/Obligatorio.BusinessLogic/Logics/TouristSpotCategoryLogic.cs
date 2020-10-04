using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class TouristSpotCategoryLogic : ITouristSpotCategoryLogic
    {
        private readonly ITouristSpotRepository touristSpotRepository;
        private readonly ICategoryRepository categoryRepository;

        public TouristSpotCategoryLogic(ITouristSpotRepository touristSpotRepository, ICategoryRepository categoryRepository)
        {
            this.touristSpotRepository = touristSpotRepository;
            this.categoryRepository = categoryRepository;
        }

        public void AddTouristSpotToCategory(string categoryName, int touristSpotId)
        {
            try
            {
                Category category = ValidateExistingCategory(categoryName);
                TouristSpot touristSpot = ValidateExistingTouristSpot(touristSpotId);
                TouristSpotCategory touristSpotCategory = new TouristSpotCategory
                {
                    TouristSpot = touristSpot,
                    TouristSpotId = touristSpot.Id,
                    Category = category,
                    CategoryId = category.Id
                };
                //category.TouristSpotCategories.Add(touristSpotCategory);
                this.categoryRepository.Add(category, touristSpotCategory);
                //touristSpot.TouristSpotCategories.Add(touristSpotCategory);
                this.touristSpotRepository.Add(touristSpot, touristSpotCategory);//----EN CASO DE EMERGENCIA AGREGAR EN LAS 3 TABLAS----//
                //this.categoryRepository.Update(category);
                //this.touristSpotRepository.Update(touristSpot);
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            catch (RepeatedObjectException)
            {
                throw new RepeatedObjectException();
            }
        }

        public IEnumerable<TouristSpot> FindByCategory(string value)
        {
            List<TouristSpot> touristSpots = new List<TouristSpot>();
            var category = this.categoryRepository.Find(value);
            if(category is null)
            {
            }
            else
            {
                IEnumerable<TouristSpotCategory> list = category.TouristSpotCategories;
                foreach (var tuple in category.TouristSpotCategories)
                {
                    touristSpots.Add(this.touristSpotRepository.Get(tuple.TouristSpotId));
                }
            }
            return touristSpots;
        }

        private Category ValidateExistingCategory(string categoryName)
        {
            var category = this.categoryRepository.Find(categoryName);
            if (category is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return category;
        }

        private TouristSpot ValidateExistingTouristSpot(int touristSpotId)
        {
            var touristSpot = this.touristSpotRepository.Get(touristSpotId);
            if (touristSpot is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return touristSpot;
        }
    }
}
