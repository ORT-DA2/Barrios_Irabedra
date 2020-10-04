using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Models.In
{
    public class CategoryModelIn
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public CategoryModelIn()
        {
        }
        public CategoryModelIn(Category category)
        {
            this.Name = category.Name;
            this.Id = category.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryModelIn model &&
                   Name == model.Name &&
                   Id == model.Id;
        }

        public Category ToEntity()
        {
            Category category = new Category();
            category.Name = this.Name;
            return category;
        }
    }
}
