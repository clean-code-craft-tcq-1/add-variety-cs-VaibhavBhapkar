using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class HighBreachType : IBreachType
    {
        public string BreachValue(double value,double limitValue)
        {
            if (value > limitValue)
            {
                return "High";
            }
            else
            {
                return "Normal";
            }
        }
    }
}
