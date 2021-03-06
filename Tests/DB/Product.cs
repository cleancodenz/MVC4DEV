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

namespace Tests.DB
{
    public partial class Product
    {
        #region Primitive Properties
    
        public virtual int ProductID
        {
            get;
            set;
        }
    
        public virtual string ProductName
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SupplierID
        {
            get { return _supplierID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_supplierID != value)
                    {
                        if (Supplier != null && Supplier.SupplierID != value)
                        {
                            Supplier = null;
                        }
                        _supplierID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _supplierID;
    
        public virtual Nullable<int> CategoryID
        {
            get { return _categoryID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_categoryID != value)
                    {
                        if (Category != null && Category.CategoryID != value)
                        {
                            Category = null;
                        }
                        _categoryID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _categoryID;
    
        public virtual string QuantityPerUnit
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> UnitPrice
        {
            get;
            set;
        }
    
        public virtual Nullable<short> UnitsInStock
        {
            get;
            set;
        }
    
        public virtual Nullable<short> UnitsOnOrder
        {
            get;
            set;
        }
    
        public virtual Nullable<short> ReorderLevel
        {
            get;
            set;
        }
    
        public virtual bool Discontinued
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Category Category
        {
            get { return _category; }
            set
            {
                if (!ReferenceEquals(_category, value))
                {
                    var previousValue = _category;
                    _category = value;
                    FixupCategory(previousValue);
                }
            }
        }
        private Category _category;
    
        public virtual ICollection<Order_Detail> Order_Details
        {
            get
            {
                if (_order_Details == null)
                {
                    var newCollection = new FixupCollection<Order_Detail>();
                    newCollection.CollectionChanged += FixupOrder_Details;
                    _order_Details = newCollection;
                }
                return _order_Details;
            }
            set
            {
                if (!ReferenceEquals(_order_Details, value))
                {
                    var previousValue = _order_Details as FixupCollection<Order_Detail>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupOrder_Details;
                    }
                    _order_Details = value;
                    var newValue = value as FixupCollection<Order_Detail>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupOrder_Details;
                    }
                }
            }
        }
        private ICollection<Order_Detail> _order_Details;
    
        public virtual Supplier Supplier
        {
            get { return _supplier; }
            set
            {
                if (!ReferenceEquals(_supplier, value))
                {
                    var previousValue = _supplier;
                    _supplier = value;
                    FixupSupplier(previousValue);
                }
            }
        }
        private Supplier _supplier;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupCategory(Category previousValue)
        {
            if (previousValue != null && previousValue.Products.Contains(this))
            {
                previousValue.Products.Remove(this);
            }
    
            if (Category != null)
            {
                if (!Category.Products.Contains(this))
                {
                    Category.Products.Add(this);
                }
                if (CategoryID != Category.CategoryID)
                {
                    CategoryID = Category.CategoryID;
                }
            }
            else if (!_settingFK)
            {
                CategoryID = null;
            }
        }
    
        private void FixupSupplier(Supplier previousValue)
        {
            if (previousValue != null && previousValue.Products.Contains(this))
            {
                previousValue.Products.Remove(this);
            }
    
            if (Supplier != null)
            {
                if (!Supplier.Products.Contains(this))
                {
                    Supplier.Products.Add(this);
                }
                if (SupplierID != Supplier.SupplierID)
                {
                    SupplierID = Supplier.SupplierID;
                }
            }
            else if (!_settingFK)
            {
                SupplierID = null;
            }
        }
    
        private void FixupOrder_Details(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Order_Detail item in e.NewItems)
                {
                    item.Product = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Order_Detail item in e.OldItems)
                {
                    if (ReferenceEquals(item.Product, this))
                    {
                        item.Product = null;
                    }
                }
            }
        }

        #endregion
    }
}
