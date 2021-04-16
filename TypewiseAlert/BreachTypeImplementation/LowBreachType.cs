using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class LowBreachType : IBreachType
    {
        public string BreachValue(double value, double limitValue)
        {
            if(value<limitValue)
            {
                return "Low";
            }
            else
            {
                return "Normal";
            }
        }
    }
}
