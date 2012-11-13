using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCompany.UI.Data.Model;
using MyCompany.Business;
using MVC4Application.Transformers;


namespace MVC4Application.APIControllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };


        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
     

        // /api/products
        public IEnumerable<Product> GetAllProducts()
        {
            var p = from product in _productService.GetAllProductsWithCategory()
                    select DomainProductToUIProduct.Transforme(product) ;
            return p;
        }

        // /api/products/id
        public Product GetProductById(int id)
        {
            var product = DomainProductToUIProduct.Transforme
            (_productService.GetProductByID(id));

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        // /api/products/?category=category
        public IEnumerable<Product> GetProductsByCategory(int categoryid)
        {
            var p = from product in _productService.GetProductsByCategory(categoryid)
                    select DomainProductToUIProduct.Transforme(product);
            return p;
        }

        // new product
        public HttpResponseMessage PostProduct(Product item)
        {
            products.ToList().Add(item);

            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            
            return response;

            
        }

        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            //if (!repository.Update(product))
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
        }

        public HttpResponseMessage DeleteProduct(int id)
        {
            // repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
