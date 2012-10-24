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

namespace MyCompany.Data.Entity
{
    public partial class Territory
    {
        #region Primitive Properties
    
        public virtual string TerritoryID
        {
            get;
            set;
        }
    
        public virtual string TerritoryDescription
        {
            get;
            set;
        }
    
        public virtual int RegionID
        {
            get { return _regionID; }
            set
            {
                if (_regionID != value)
                {
                    if (Region != null && Region.RegionID != value)
                    {
                        Region = null;
                    }
                    _regionID = value;
                }
            }
        }
        private int _regionID;

        #endregion
        #region Navigation Properties
    
        public virtual Region Region
        {
            get { return _region; }
            set
            {
                if (!ReferenceEquals(_region, value))
                {
                    var previousValue = _region;
                    _region = value;
                    FixupRegion(previousValue);
                }
            }
        }
        private Region _region;
    
        public virtual ICollection<Employee> Employees
        {
            get
            {
                if (_employees == null)
                {
                    var newCollection = new FixupCollection<Employee>();
                    newCollection.CollectionChanged += FixupEmployees;
                    _employees = newCollection;
                }
                return _employees;
            }
            set
            {
                if (!ReferenceEquals(_employees, value))
                {
                    var previousValue = _employees as FixupCollection<Employee>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupEmployees;
                    }
                    _employees = value;
                    var newValue = value as FixupCollection<Employee>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupEmployees;
                    }
                }
            }
        }
        private ICollection<Employee> _employees;

        #endregion
        #region Association Fixup
    
        private void FixupRegion(Region previousValue)
        {
            if (previousValue != null && previousValue.Territories.Contains(this))
            {
                previousValue.Territories.Remove(this);
            }
    
            if (Region != null)
            {
                if (!Region.Territories.Contains(this))
                {
                    Region.Territories.Add(this);
                }
                if (RegionID != Region.RegionID)
                {
                    RegionID = Region.RegionID;
                }
            }
        }
    
        private void FixupEmployees(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Employee item in e.NewItems)
                {
                    if (!item.Territories.Contains(this))
                    {
                        item.Territories.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Employee item in e.OldItems)
                {
                    if (item.Territories.Contains(this))
                    {
                        item.Territories.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
