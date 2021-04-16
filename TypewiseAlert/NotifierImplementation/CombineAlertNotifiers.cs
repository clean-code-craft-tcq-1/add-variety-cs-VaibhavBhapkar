using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert.NotifierImplementation
{
    public class CombineAlertNotifiers : IBreachObserver
    {
        List<IBreachObserver> _iBreachObservers = new List<IBreachObserver>();
        public void Add(IBreachObserver breachObserver)
        {
            _iBreachObservers.Add(breachObserver);
        }
        public void GenerateAlert(string breachType)
        {
            foreach (IBreachObserver breachObserver in _iBreachObservers)
            { 
                breachObserver.GenerateAlert(breachType);
            }
        }
    }
}
