﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MyCompany.Logging;

namespace MVC4Application
{
    public class PerHttpRequestLifetime : LifetimeManager
    {
        // the key needs to be different on bases of per type
        private readonly Guid _key = Guid.NewGuid();

        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_key] = newValue;
            LogUtil.Debug(this.GetType(), "Object " + newValue.ToString() + " being added to PerHttpRequestLifeTimeManager " + _key);
        }

        // not called at all
        public override void RemoveValue()
        {
            var obj = GetValue();
            HttpContext.Current.Items.Remove(obj);
            LogUtil.Debug(this.GetType(), "Object " + obj.ToString() + " being removed from PerHttpRequestLifeTimeManager " + _key);
        }

        // not called at all
        public void Dispose()
        {
            RemoveValue();
        }

    }
}