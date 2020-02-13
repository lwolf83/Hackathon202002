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
            //Get("/categories", ServeCategories);

        }

        private dynamic ServeHome(object manyParameters)
        {
            return View["home.sshtml", Products];
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
        
       /* private dynamic ServeCategories(object manyParameters)
        {

        }*/
    }
}