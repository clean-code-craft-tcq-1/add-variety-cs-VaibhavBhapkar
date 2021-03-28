using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IAlerter
    {
        bool GenerateAlert(AlertConstants.BreachType breachType);
    }
}
