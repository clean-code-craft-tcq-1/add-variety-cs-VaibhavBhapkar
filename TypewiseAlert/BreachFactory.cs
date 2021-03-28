using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class BreachFactory
    {
        Dictionary<string, Type> breachTypes;
        public BreachFactory()
        {
            LoadTypesAssemblyCanReturn();
        }
        public IBreachType CreateInstance(string source)
        {
            Type typeAssembly = GetTypeToCreate(source);
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as IBreachType;
        }
        private Type GetTypeToCreate(string sourceName)
        {
            foreach (var source in breachTypes)
            {
                Console.WriteLine(source.Key);
                if (source.Key.Contains(sourceName))
                {
                    return breachTypes[source.Key];
                }
            }
            return null;
        }
        private void LoadTypesAssemblyCanReturn()
        {
            breachTypes = new Dictionary<string, Type>();
            Type[] typeInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in typeInThisAssembly)
            {
                if (type.GetInterface(typeof(IBreachType).ToString()) != null)
                {
                    breachTypes.Add(type.Name.ToUpper(), type);
                }
            }
        }
    }
}
