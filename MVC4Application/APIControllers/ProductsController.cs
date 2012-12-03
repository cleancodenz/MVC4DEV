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
       
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
     

        // /api/products
        public IEnumerable<Product> GetAllProducts()
        {
            var p = from product in _productService.GetAllProductsWithCategory()
                    select DomainAndUIProduct.FromDomainToUI(product) ;
            return p;
        }

        // /api/products/id
        public Product GetProductById(int id)
        {
            var product = DomainAndUIProduct.FromDomainToUI
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
                    select DomainAndUIProduct.FromDomainToUI(product);
            return p;
        }

        // new product
        public HttpResponseMessage PostProduct(Product item)
        {
            var _product = _productService.AddProduct(DomainAndUIProduct.FromUIToDomain(item));

            if (_product != null)
            {
                var response = Request.CreateResponse<Product>(HttpStatusCode.Created, DomainAndUIProduct.FromDomainToUI(_product));

              //  string uri = Url.Link("DefaultApi", new { id = item.Id });
               // response.Headers.Location = new Uri(uri);

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            
        }

        public HttpResponseMessage PutProduct(Product product)
        {
         
           // to get the product first
            var _product = _productService.GetProductByID(product.Id);

            if (_product != null)
            {
                // only update the name and price
                _product.ProductName = product.Name;
                _product.UnitPrice = product.Price;

                // then save it
                if (_productService.UpdateProduct(_product))
                {
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, product);
                    // will return result as a json object: {"Id":79,"Name":"testr","CategoryID":null,"Category":null,"Price":14.0}

                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        
        }

        public HttpResponseMessage DeleteProduct(Product product)
        {

            // then save it
            if (_productService.DeleteProduct(DomainAndUIProduct.FromUIToDomain(product)))
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            else
            {               
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

    }
}
