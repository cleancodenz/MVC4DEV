using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindViewModels
{
    public interface IRuleEntity
    {
        List<RuleViolation> GetRuleViolations();
    }
}
