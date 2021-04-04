using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class ControllerAlert : IAlerter
    {
        public bool isGenerateAlertCalledOnce { get ; set; }
        public ControllerAlert()
        {
            this.isGenerateAlertCalledOnce = false;
        }

        public void GenerateAlert(AlertConstants.BreachType breachType)
        {
            this.isGenerateAlertCalledOnce=true;
            const ushort header = 0xfeed;
            Console.WriteLine("{0} : {1}\n", header, breachType);
        }
    }
}
