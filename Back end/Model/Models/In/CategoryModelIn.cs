using Obligatorio.Domain;

namespace Model.Models.In
{
    public class CategoryModelIn
    {
        public string Name { get; set; }


        public CategoryModelIn()
        {
        }
        public CategoryModelIn(Category category)
        {
            this.Name = category.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryModelIn model &&
                   Name == model.Name; 
        }

        public Category ToEntity()
        {
            Category category = new Category();
            category.Name = this.Name;
            return category;
        }
    }
}
