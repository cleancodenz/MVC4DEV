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
    public partial class Order
    {
        #region Primitive Properties
    
        public virtual int OrderID
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> OrderDate
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> RequiredDate
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> ShippedDate
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> Freight
        {
            get;
            set;
        }
    
        public virtual string ShipName
        {
            get;
            set;
        }
    
        public virtual string ShipAddress
        {
            get;
            set;
        }
    
        public virtual string ShipCity
        {
            get;
            set;
        }
    
        public virtual string ShipRegion
        {
            get;
            set;
        }
    
        public virtual string ShipPostalCode
        {
            get;
            set;
        }
    
        public virtual string ShipCountry
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                }
            }
        }
        private Customer _customer;
    
        public virtual Employee Employee
        {
            get { return _employee; }
            set
            {
                if (!ReferenceEquals(_employee, value))
                {
                    var previousValue = _employee;
                    _employee = value;
                    FixupEmployee(previousValue);
                }
            }
        }
        private Employee _employee;
    
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
    
        public virtual Shipper Shipper
        {
            get { return _shipper; }
            set
            {
                if (!ReferenceEquals(_shipper, value))
                {
                    var previousValue = _shipper;
                    _shipper = value;
                    FixupShipper(previousValue);
                }
            }
        }
        private Shipper _shipper;

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue)
        {
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.Orders.Contains(this))
                {
                    Customer.Orders.Add(this);
                }
            }
        }
    
        private void FixupEmployee(Employee previousValue)
        {
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Employee != null)
            {
                if (!Employee.Orders.Contains(this))
                {
                    Employee.Orders.Add(this);
                }
            }
        }
    
        private void FixupShipper(Shipper previousValue)
        {
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Shipper != null)
            {
                if (!Shipper.Orders.Contains(this))
                {
                    Shipper.Orders.Add(this);
                }
            }
        }
    
        private void FixupOrder_Details(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Order_Detail item in e.NewItems)
                {
                    item.Order = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Order_Detail item in e.OldItems)
                {
                    if (ReferenceEquals(item.Order, this))
                    {
                        item.Order = null;
                    }
                }
            }
        }

        #endregion
    }
}
