using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class LowBreachType : IBreachType
    {
        public AlertConstants.BreachType BreachValue(double value, double limitValue)
        {
            if(value<limitValue)
            {
                return AlertConstants.BreachType.TOO_LOW;
            }
            else
            {
                return AlertConstants.BreachType.NORMAL;
            }
        }
    }
}
