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
    public partial class webpages_Roles
    {
        #region Primitive Properties
    
        public virtual int RoleId
        {
            get;
            set;
        }
    
        public virtual string RoleName
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<UserProfile> UserProfiles
        {
            get
            {
                if (_userProfiles == null)
                {
                    var newCollection = new FixupCollection<UserProfile>();
                    newCollection.CollectionChanged += FixupUserProfiles;
                    _userProfiles = newCollection;
                }
                return _userProfiles;
            }
            set
            {
                if (!ReferenceEquals(_userProfiles, value))
                {
                    var previousValue = _userProfiles as FixupCollection<UserProfile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUserProfiles;
                    }
                    _userProfiles = value;
                    var newValue = value as FixupCollection<UserProfile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUserProfiles;
                    }
                }
            }
        }
        private ICollection<UserProfile> _userProfiles;

        #endregion
        #region Association Fixup
    
        private void FixupUserProfiles(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserProfile item in e.NewItems)
                {
                    if (!item.webpages_Roles.Contains(this))
                    {
                        item.webpages_Roles.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserProfile item in e.OldItems)
                {
                    if (item.webpages_Roles.Contains(this))
                    {
                        item.webpages_Roles.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}