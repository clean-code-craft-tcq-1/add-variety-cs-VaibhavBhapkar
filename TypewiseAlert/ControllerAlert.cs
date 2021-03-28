using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class ControllerAlert : IAlerter
    {
        public bool GenerateAlert(AlertConstants.BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{0} : {1}\n", header, breachType);
            return true;
        }
    }
}
