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
    public partial class Customer
    {
        #region Primitive Properties
    
        public virtual string CustomerID
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

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    var newCollection = new FixupCollection<Order>();
                    newCollection.CollectionChanged += FixupOrders;
                    _orders = newCollection;
                }
                return _orders;
            }
            set
            {
                if (!ReferenceEquals(_orders, value))
                {
                    var previousValue = _orders as FixupCollection<Order>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupOrders;
                    }
                    _orders = value;
                    var newValue = value as FixupCollection<Order>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupOrders;
                    }
                }
            }
        }
        private ICollection<Order> _orders;
    
        public virtual ICollection<CustomerDemographic> CustomerDemographics
        {
            get
            {
                if (_customerDemographics == null)
                {
                    var newCollection = new FixupCollection<CustomerDemographic>();
                    newCollection.CollectionChanged += FixupCustomerDemographics;
                    _customerDemographics = newCollection;
                }
                return _customerDemographics;
            }
            set
            {
                if (!ReferenceEquals(_customerDemographics, value))
                {
                    var previousValue = _customerDemographics as FixupCollection<CustomerDemographic>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCustomerDemographics;
                    }
                    _customerDemographics = value;
                    var newValue = value as FixupCollection<CustomerDemographic>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCustomerDemographics;
                    }
                }
            }
        }
        private ICollection<CustomerDemographic> _customerDemographics;

        #endregion
        #region Association Fixup
    
        private void FixupOrders(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Order item in e.NewItems)
                {
                    item.Customer = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Order item in e.OldItems)
                {
                    if (ReferenceEquals(item.Customer, this))
                    {
                        item.Customer = null;
                    }
                }
            }
        }
    
        private void FixupCustomerDemographics(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (CustomerDemographic item in e.NewItems)
                {
                    if (!item.Customers.Contains(this))
                    {
                        item.Customers.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CustomerDemographic item in e.OldItems)
                {
                    if (item.Customers.Contains(this))
                    {
                        item.Customers.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
