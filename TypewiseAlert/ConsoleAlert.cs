using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class ConsoleAlert:IAlerter
    {        
        public void GenerateAlert(AlertConstants.BreachType breachType)
        {
            Console.WriteLine("Breach Type is - {0}\n", breachType);
        }
    }
}
