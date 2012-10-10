using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindViewModels
{
   public  class RuleViolation
    {
       public string PropertyName { get; set; }
       public object PropertyValue { get; set; }
       public string ErrorMessage { get; set; }

       public RuleViolation(string propertyName,
           object propertyValue,
           string errorMessage)
       {
           PropertyName = propertyName;
           PropertyValue = propertyValue;
           ErrorMessage = errorMessage;
       }
    }
}
