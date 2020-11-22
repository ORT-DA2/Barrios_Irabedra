using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain.DomainEntities
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Accommodation acccommodation { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Review()
        {
        }
    }
}
