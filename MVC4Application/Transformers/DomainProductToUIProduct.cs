using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCompany.Data.Entity;


namespace MVC4Application.Transformers
{
    public class DomainProductToUIProduct
    {
        public static MyCompany.UI.Data.Model.Product Transforme(
            Product dproduct)
        {
            MyCompany.UI.Data.Model.Product uiproduct = new
            MyCompany.UI.Data.Model.Product();

            uiproduct.CategoryID = dproduct.CategoryID;
            if (dproduct.Category != null)
            {
                uiproduct.Category = dproduct.Category.Description;
            }
            uiproduct.Id = dproduct.ProductID;
            uiproduct.Name = dproduct.ProductName;
            uiproduct.Price = dproduct.UnitPrice;

            return uiproduct;
        }
    }
}