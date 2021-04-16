using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class FakeEmailAlert : IBreachObserver
    {
        public bool isGenerateAlertCalledOnce = false;
        public virtual void GenerateAlert(string breachType)
        {
            Console.WriteLine("Fake Email Sent");
            isGenerateAlertCalledOnce = true;
        }        
    }
}
