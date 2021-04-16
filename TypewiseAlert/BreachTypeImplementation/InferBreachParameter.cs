using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class InferBreachParameter
    {
        IBreachType _breachType;
        public InferBreachParameter(IBreachType breachType)
        {
            if (breachType == null)
                throw new ArgumentNullException("IBreachType cannot be null");
            this._breachType = breachType;
        }
        public string BreachLimit(double value,double limitValue)
        {
            return _breachType.BreachValue(value,limitValue);
        }
    }
}
