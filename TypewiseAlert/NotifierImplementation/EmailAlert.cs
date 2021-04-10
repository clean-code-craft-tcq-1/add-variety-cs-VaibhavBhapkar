using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailAlert : IAlerter
    {      
        public void GenerateAlert(string breachType)
        {
            string recepient = "abc@com";
            BreachFactory breachFactory = new BreachFactory();
            IBreachNotifier iBreachDetails = breachFactory.GetInstanceOfBreachNotifier(breachType);
            iBreachDetails.Display(recepient);
        }
    }
}
