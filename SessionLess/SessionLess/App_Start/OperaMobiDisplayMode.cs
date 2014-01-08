using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace SessionLess
{
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