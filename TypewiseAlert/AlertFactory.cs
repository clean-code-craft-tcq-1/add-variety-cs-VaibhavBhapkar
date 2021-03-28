using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class AlertFactory
    {
        Dictionary<string, Type> alertMode;
        public AlertFactory()
        {
            LoadTypesAssemblyCanReturn();
        }
        public IAlerter CreateInstance(string source)
        {
            Type typeAssembly = GetTypeToCreate(source);
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as IAlerter;
        }
        private Type GetTypeToCreate(string sourceName)
        {
            foreach (var source in alertMode)
            {
                Console.WriteLine(source.Key);
                if (source.Key.Contains(sourceName))
                {
                    return alertMode[source.Key];
                }
            }
            return null;
        }
        private void LoadTypesAssemblyCanReturn()
        {
            alertMode = new Dictionary<string, Type>();
            Type[] typeInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in typeInThisAssembly)
            {
                if (type.GetInterface(typeof(IAlerter).ToString()) != null)
                {
                    alertMode.Add(type.Name.ToUpper(), type);
                }
            }
        }
    }
}
