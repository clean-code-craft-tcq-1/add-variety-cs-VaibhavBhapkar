using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class HighBreachType : IBreachType
    {
        public AlertConstants.BreachType BreachValue(double value,double limitValue)
        {
            if (value > limitValue)
            {
                return AlertConstants.BreachType.TOO_HIGH;
            }
            else
            {
                return AlertConstants.BreachType.NORMAL;
            }
        }
    }
}
