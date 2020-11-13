﻿using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogic.Logics
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ITouristSpotCategoryLogic touristSpotCategoryLogic;
        private readonly ICategoryRepository categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository
            , ITouristSpotCategoryLogic touristSpotCategoryLogic)
        {
            this.touristSpotCategoryLogic = touristSpotCategoryLogic;
            this.categoryRepository = categoryRepository;
        }

        public void Add(Category newEntity)
        {
            try
            {
                this.categoryRepository.Add(newEntity);
            }
            catch (RepeatedObjectException ex)
            {
                throw new RepeatedObjectException();
            }
        }

        public void Add(Category category, TouristSpotCategory touristSpotCategory)
        {
            this.categoryRepository.Add(category, touristSpotCategory);
        }

        public void AddTouristSpotToCategory(string categoryName, int touristSpotId)
        {
            try
            {
                this.touristSpotCategoryLogic.AddTouristSpotToCategory(categoryName, touristSpotId);
            }
            catch (RepeatedObjectException ex)
            {
                throw new RepeatedObjectException();
            }
            catch (Exception ex)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public void AddTouristSpotToCategory(string categoryName, string touristSpotName)
        {
            try
            {
                this.touristSpotCategoryLogic.AddTouristSpotToCategory(categoryName, touristSpotName);
            }
            catch (RepeatedObjectException ex)
            {
                throw new RepeatedObjectException();
            }
            catch (Exception ex)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public Category Find(string categoryName)
        {
            return this.categoryRepository.Find(categoryName);
        }

        public Category Get(string name)
        {
            try
            {
                return this.categoryRepository.Get(name);
            }
            catch (Exception ex)
            {

                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoryRepository.GetAll();
        }
    }
}
