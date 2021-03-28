using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class CoolingTypeFactory
    {
        Dictionary<string, Type> coolingType;
        public CoolingTypeFactory()
        {
            LoadTypesAssemblyCanReturn();
        }
        public ICoolingType CreateInstance(string source)
        {
            Type typeAssembly = GetTypeToCreate(source);
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as ICoolingType;
        }
        private Type GetTypeToCreate(string sourceName)
        {
            foreach (var source in coolingType)
            {
                Console.WriteLine(source.Key);
                if (source.Key.Contains(sourceName))
                {
                    return coolingType[source.Key];
                }
            }
            return null;
        }
        private void LoadTypesAssemblyCanReturn()
        {
            coolingType = new Dictionary<string, Type>();
            Type[] typeInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in typeInThisAssembly)
            {
                if (type.GetInterface(typeof(ICoolingType).ToString()) != null)
                {
                    coolingType.Add(type.Name.ToUpper(), type);
                }
            }
        }
    }
}
