using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class ConsoleAlert:IAlerter
    {
        public bool isGenerateAlertCalledOnce { get; set; }
        public ConsoleAlert()
        {
            this.isGenerateAlertCalledOnce = false;
        }
        public void GenerateAlert(AlertConstants.BreachType breachType)
        {
            this.isGenerateAlertCalledOnce = true;
            Console.WriteLine("Breach Type is - {0}\n", breachType);
        }
    }
}
