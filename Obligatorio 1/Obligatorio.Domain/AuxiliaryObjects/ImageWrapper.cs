using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain.AuxiliaryObjects
{
    public class ImageWrapper
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public ImageWrapper()
        {
        }

        public ImageWrapper(string item)
        {
            this.Image = item;
        }

        public override string ToString()
        {
            return Image;
        }
    }
}
