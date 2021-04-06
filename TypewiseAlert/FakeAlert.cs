using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class FakeAlert : IAlerter,IFakeAlertChecker
    {
        bool isGenerateAlertCalledOnce = false;
        public void GenerateAlert(AlertConstants.BreachType breachType)
        {
            isGenerateAlertCalledOnce = true;
        }
        bool IFakeAlertChecker.IsAlertTriggered()
        {
            return this.isGenerateAlertCalledOnce;
        }
    }
}
