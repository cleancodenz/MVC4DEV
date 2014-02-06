using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionLess.CustomModelValidator
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AllRequiredAttribute : Attribute
    {

    }
}