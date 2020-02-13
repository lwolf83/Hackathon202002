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
            get
            {
                // You must get products from a database
                // in the real version. This code is only
                // here to show you how to pass a model
                // to your view
                // Database.GetMostRecentProducts();
                List<Product> products = new List<Product>();
                IEnumerable<Category> categories = Categories;
                //Category badassCategory = Categories.Single(category => category.Name == "Badaa$$");
                //products.Add(new Product { Name = "Corentin", Price = 30000, Category = badassCategory, Description = "SuperDev" });
                return products;
            }
        }

        public override IEnumerable<Category> Categories 
        { 
            get
            {
                List<Category> categories = new List<Category>
                {
                    new Category{ Name = "Badaa$$", Description = "Really good stuffgfdgfdgretezfdsgfdfezrez" }
                };
                return categories;
            }
        }

        public HomeModule()
        {
            Get("/", ServeHome);
            Get("/products", ServeProducts);
            Get("/categories", ServeCategories);
        }

        private dynamic ServeHome(object manyParameters)
        {
            List<Product> productsRandom = Database.GetThreeRandomProducts();
            return View["index.sshtml", productsRandom];
        }

        private dynamic ServeProducts(object manyParameters)
        {
            return View["Products.sshtml", Products];
        }

        private dynamic ServeCategories(object manyParameters)
        {
            return View["Products.sshtml", Products];
        }
    }
}