using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IAlerter
    {
        bool isGenerateAlertCalledOnce { get; set; }
        void GenerateAlert(AlertConstants.BreachType breachType);
    }
}
