using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class BreachFactory
    {
        public IBreachType GetInstanceOfBreachType(string source)
        {
            Type typeAssembly = FindTypeInAssembly.FindInstanceOfAssembly(source,typeof(IBreachType).ToString());
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as IBreachType;
        }
        
    }
}
