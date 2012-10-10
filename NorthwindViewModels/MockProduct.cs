using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindViewModels
{
    public class MockProduct : IRuleEntity
    {
        public decimal UnitPrice { get; set; }

        public List<RuleViolation> GetRuleViolations()
        {
            List<RuleViolation> validationIssues = new List<RuleViolation>();

            if (UnitPrice < 1)
            {
                validationIssues.Add(new RuleViolation(
                    "Unit Price",
                    UnitPrice,
                    "Unit Price too low"
                    ));
            }   
         
            return validationIssues;
        }
    }
}
