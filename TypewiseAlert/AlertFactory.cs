using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class AlertFactory
    {
        public IAlerter GetInstanceOfAlertType(string source)
        {
            Type typeAssembly = FindTypeInAssembly.FindInstanceOfAssembly(source,typeof(IAlerter).ToString());
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as IAlerter;
        }
      
    }
}
