using System;
using System.Collections.Generic;
using System.Text;

namespace EcoConception
{
    public class CartModule : AbstractModule
    {
        public override IEnumerable<Product> Products { get; }
        public override IEnumerable<Category> Categories { get; }
    }
}