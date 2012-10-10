using NorthwindViewModels;
using System.Web.Mvc;
using System.Collections.Generic;
namespace MVC4Application
{
    public static class   Utilities
    {
        public static void  UpdateModelStateWithRuleViolations(IRuleEntity entity,
            ModelStateDictionary modelState)
        {
            List<RuleViolation> issues = entity.GetRuleViolations();

            foreach (var issue in issues)
            {
                modelState.AddModelError(issue.PropertyName,
                 
                    issue.ErrorMessage);
            }
        }
    }
}