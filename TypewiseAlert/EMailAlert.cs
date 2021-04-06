using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EMailAlert : IAlerter
    {      
        public void GenerateAlert(AlertConstants.BreachType breachType)
        {
            string recepient = "abc@com";
            BreachFactory breachFactory = new BreachFactory();
            string breachLevel = breachType.ToString().Split('_')[1].ToString().ToUpper();
            IBreachNotifier iBreachDetails = breachFactory.GetInstanceOfBreachNotifier(breachLevel);
            iBreachDetails.Display(recepient);
        }
    }
}
