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

        public override bool Equals(object obj)
        {
            return obj is CategoryModelIn model &&
                   Name == model.Name &&
                   Id == model.Id;
        }
    }
}
