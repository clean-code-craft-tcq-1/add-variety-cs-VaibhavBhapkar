using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class BreachFactory
    {
        public IBreachNotifier GetInstanceOfBreachNotifier(string source)
        {
            Type typeAssembly = FindTypeInAssembly.FindInstanceOfAssembly(source,typeof(IBreachNotifier).ToString());
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as IBreachNotifier;
        }

        public List<Object> GetInstanceListOfBreachType()
        {
            return FindTypeInAssembly.GetInstanceFromInterface(typeof(IBreachType).ToString());
        }
    }
}
