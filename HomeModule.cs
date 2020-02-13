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

            Get("/detailproducts-{idProduct}", parameters => ServeDetailProducts(parameters.idProduct));
            Get("/products", ServeProducts);
            Get("/categories", ServeCategories);
            Get("/categories/cat-{idCategory}", parameters => ServeProductsByCategory(parameters.idCategory));
            //Get("/categories", ServeCategories);


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


        private dynamic ServeDetailProducts(int idProduct)
        {            

            Product currentProduct = Database.GetProductById(idProduct);
            return View["DetailProduct.sshtml", currentProduct];
        }

        private dynamic ServeProductsByCategory(int idCategory)
        {
            List<Product> products = Database.GetProductsByCategory(idCategory);
            return View["ProductsByCategory.sshtml", products];
        }

    }
}