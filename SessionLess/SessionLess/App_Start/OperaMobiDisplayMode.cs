using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace SessionLess
{
    // display a different version of views
    public class OperaMobiDisplayMode : DefaultDisplayMode
    {
        public OperaMobiDisplayMode() :base("Mobile")
        {
            ContextCondition = context => IsMobile(context.GetOverriddenUserAgent()); 
        }

        private bool IsMobile(string useragentString)
        {
            return useragentString.IndexOf("Opera Mobi",
                 StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}