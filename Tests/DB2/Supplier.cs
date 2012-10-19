//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Tests.DB2
{
    public partial class Supplier
    {
        #region Primitive Properties
    
        public virtual int SupplierID
        {
            get;
            set;
        }
    
        public virtual string CompanyName
        {
            get;
            set;
        }
    
        public virtual string ContactName
        {
            get;
            set;
        }
    
        public virtual string ContactTitle
        {
            get;
            set;
        }
    
        public virtual string Address
        {
            get;
            set;
        }
    
        public virtual string City
        {
            get;
            set;
        }
    
        public virtual string Region
        {
            get;
            set;
        }
    
        public virtual string PostalCode
        {
            get;
            set;
        }
    
        public virtual string Country
        {
            get;
            set;
        }
    
        public virtual string Phone
        {
            get;
            set;
        }
    
        public virtual string Fax
        {
            get;
            set;
        }
    
        public virtual string HomePage
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    var newCollection = new FixupCollection<Product>();
                    newCollection.CollectionChanged += FixupProducts;
                    _products = newCollection;
                }
                return _products;
            }
            set
            {
                if (!ReferenceEquals(_products, value))
                {
                    var previousValue = _products as FixupCollection<Product>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProducts;
                    }
                    _products = value;
                    var newValue = value as FixupCollection<Product>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProducts;
                    }
                }
            }
        }
        private ICollection<Product> _products;

        #endregion
        #region Association Fixup
    
        private void FixupProducts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Product item in e.NewItems)
                {
                    item.Supplier = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product item in e.OldItems)
                {
                    if (ReferenceEquals(item.Supplier, this))
                    {
                        item.Supplier = null;
                    }
                }
            }
        }

        #endregion
    }
}
