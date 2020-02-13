using System;
using System.Collections.Generic;
using System.Text;

namespace EcoConception
{
    public class Product
    {
        public int Id { get; private set; }
        public Single Price { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Category Category { get; set; }

        public bool PriceIsBig { get => true; }
    }
}