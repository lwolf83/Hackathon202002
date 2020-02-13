using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;

namespace EcoConception
{
    public class HomeModule : AbstractModule
    {
        public override IEnumerable<Product> Products
        {
            get; 
        }

        public override IEnumerable<Category> Categories 
        { 
            get
            {
                return Database.GetAllCategories();
            }
        }

        public HomeModule()
        {
            Get("/", ServeHome);
            Get("/products", ServeProducts);
            Get("/categories", ServeCategories);
            Get("/categories/cat-{idCategory}", parameters => ServeProductsByCategory(parameters.idCategory));
        }

        private dynamic ServeHome(object manyParameters)
        {
            return View["home.sshtml", Products];
        }

        private dynamic ServeProducts(object manyParameters)
        {
            return View["Products.sshtml", Products];
        }

        private dynamic ServeCategories(object manyParameters)
        {
            return View["categories.sshtml", Categories];
        }

        private dynamic ServeProductsByCategory(int idCategory)
        {
            List<Product> products = Database.GetProductsByCategory(idCategory);
            return View["ProductsByCategory.sshtml", products];
        }
    }
}