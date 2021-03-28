using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EMailAlert : IAlerter
    {
        public bool GenerateAlert(AlertConstants.BreachType breachType)
        {
            string recepient = "abc@com";
            BreachFactory breachFactory = new BreachFactory();
            string breachLevel = breachType.ToString().Split('_')[1].ToString().ToUpper();
            IBreachType iBreachDetails = breachFactory.CreateInstance(breachLevel);
            iBreachDetails.Display(recepient);
            return true;
        }
    }
}
