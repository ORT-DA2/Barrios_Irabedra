using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Models.Out
{
    public class CategoryModelOut
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoryModelOut model &&
                   Name == model.Name &&
                   Id == model.Id;
        }
    }
}
