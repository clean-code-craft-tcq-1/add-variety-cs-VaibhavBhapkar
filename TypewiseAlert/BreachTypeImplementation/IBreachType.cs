using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IBreachType
    {
        string BreachValue(double value,double limitValue);
    }
}
