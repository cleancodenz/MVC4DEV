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
    public partial class webpages_Membership
    {
        #region Primitive Properties
    
        public virtual int UserId
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> CreateDate
        {
            get;
            set;
        }
    
        public virtual string ConfirmationToken
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> IsConfirmed
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> LastPasswordFailureDate
        {
            get;
            set;
        }
    
        public virtual int PasswordFailuresSinceLastSuccess
        {
            get;
            set;
        }
    
        public virtual string Password
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> PasswordChangedDate
        {
            get;
            set;
        }
    
        public virtual string PasswordSalt
        {
            get;
            set;
        }
    
        public virtual string PasswordVerificationToken
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> PasswordVerificationTokenExpirationDate
        {
            get;
            set;
        }

        #endregion
    }
}
