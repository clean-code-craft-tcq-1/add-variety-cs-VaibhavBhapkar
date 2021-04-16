using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IBreachObserver
    {
        void GenerateAlert(string breachType);
    }
}
