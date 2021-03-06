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
    public partial class Region
    {
        #region Primitive Properties
    
        public virtual int RegionID
        {
            get;
            set;
        }
    
        public virtual string RegionDescription
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Territory> Territories
        {
            get
            {
                if (_territories == null)
                {
                    var newCollection = new FixupCollection<Territory>();
                    newCollection.CollectionChanged += FixupTerritories;
                    _territories = newCollection;
                }
                return _territories;
            }
            set
            {
                if (!ReferenceEquals(_territories, value))
                {
                    var previousValue = _territories as FixupCollection<Territory>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTerritories;
                    }
                    _territories = value;
                    var newValue = value as FixupCollection<Territory>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTerritories;
                    }
                }
            }
        }
        private ICollection<Territory> _territories;

        #endregion
        #region Association Fixup
    
        private void FixupTerritories(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Territory item in e.NewItems)
                {
                    item.Region = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Territory item in e.OldItems)
                {
                    if (ReferenceEquals(item.Region, this))
                    {
                        item.Region = null;
                    }
                }
            }
        }

        #endregion
    }
}
