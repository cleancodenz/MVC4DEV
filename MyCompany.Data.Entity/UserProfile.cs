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
    public partial class UserProfile
    {
        #region Primitive Properties
    
        public virtual int UserId
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<webpages_Roles> webpages_Roles
        {
            get
            {
                if (_webpages_Roles == null)
                {
                    var newCollection = new FixupCollection<webpages_Roles>();
                    newCollection.CollectionChanged += Fixupwebpages_Roles;
                    _webpages_Roles = newCollection;
                }
                return _webpages_Roles;
            }
            set
            {
                if (!ReferenceEquals(_webpages_Roles, value))
                {
                    var previousValue = _webpages_Roles as FixupCollection<webpages_Roles>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupwebpages_Roles;
                    }
                    _webpages_Roles = value;
                    var newValue = value as FixupCollection<webpages_Roles>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupwebpages_Roles;
                    }
                }
            }
        }
        private ICollection<webpages_Roles> _webpages_Roles;

        #endregion
        #region Association Fixup
    
        private void Fixupwebpages_Roles(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (webpages_Roles item in e.NewItems)
                {
                    if (!item.UserProfiles.Contains(this))
                    {
                        item.UserProfiles.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (webpages_Roles item in e.OldItems)
                {
                    if (item.UserProfiles.Contains(this))
                    {
                        item.UserProfiles.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
