using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio.BusinessLogic.Logics
{
    public class TouristSpotCategoryLogic : ITouristSpotCategoryLogic
    {
        private readonly ITouristSpotRepository touristSpotRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ITouristSpotCategoryRepository touristSpotCategoryRepository;

        public TouristSpotCategoryLogic(ITouristSpotRepository touristSpotRepository
            , ICategoryRepository categoryRepository, ITouristSpotCategoryRepository touristSpotCategoryRepository)
        {
            this.touristSpotRepository = touristSpotRepository;
            this.categoryRepository = categoryRepository;
            this.touristSpotCategoryRepository = touristSpotCategoryRepository;
        }

        public IEnumerable<TouristSpotCategory> GetAllData()
        {
            return this.touristSpotCategoryRepository.GetAll();
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
                this.categoryRepository.Add(category, touristSpotCategory);
                this.touristSpotRepository.Add(touristSpot, touristSpotCategory);
                this.touristSpotCategoryRepository.Add(category, touristSpot);
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

        public IEnumerable<TouristSpot> FindByCategory(string name)
        {
            try
            {
                Category categoryToCompare = this.categoryRepository.Get(name);
                List<TouristSpotCategory> tuplesForComparison = GetAllData().ToList();
                List<TouristSpot> touristSpotsToReturn = new List<TouristSpot>();
                foreach (var item in tuplesForComparison)
                {
                    if (categoryToCompare.Id == item.CategoryId)
                    {
                        touristSpotsToReturn.Add(this.touristSpotRepository.Get(item.TouristSpotId));
                    }
                }
                return touristSpotsToReturn;
            }
            catch (Exception)
            {
                return new List<TouristSpot>();
            }
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
