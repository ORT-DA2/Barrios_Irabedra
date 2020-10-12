using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain.AuxiliaryObjects
{
    public class ImageWrapper
    {
        private string item;

        public ImageWrapper(string item)
        {
            this.item = item;
        }

        public int Id { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Image;
        }
    }
}
