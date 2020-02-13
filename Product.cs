using System;
using System.Collections.Generic;
using System.Text;

namespace EcoConception
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Category { get; set; }

        public bool PriceIsBig { get => true; }
    }
}