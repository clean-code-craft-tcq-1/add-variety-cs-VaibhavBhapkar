using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IBreachType
    {
        AlertConstants.BreachType BreachValue(double value,double limitValue);
    }
}
