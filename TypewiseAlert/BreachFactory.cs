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
            Type typeAssembly = FindInstanceOfBreachType(source);
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as IBreachType;
        }
        private Type FindInstanceOfBreachType(string sourceName)
        {
            Type type = FindInstanceInExecutingAssembly(sourceName);
            if (type == null)
            {
                type = FindInstanceInReferencedAssemblies(sourceName);
            }
            return type;
        }

        private Type FindInstanceInExecutingAssembly(string sourceName)
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(IBreachType).ToString()) != null)
                {
                    if (type.Name.ToUpper().Contains(sourceName))
                    {
                        return type;
                    }
                }
            }
            return null;
        }
        private Type FindInstanceInReferencedAssemblies(string sourceName)
        {
            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                Assembly assembly = Assembly.Load(assemblyName);
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface(typeof(IBreachType).ToString()) != null)
                    {
                        if (type.Name.ToUpper().Contains(sourceName))
                        {
                            return type;
                        }
                    }
                }
            }
            return null;
        }
    }
}
