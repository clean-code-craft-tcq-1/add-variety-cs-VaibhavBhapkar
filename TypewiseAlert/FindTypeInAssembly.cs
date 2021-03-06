using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public static class FindTypeInAssembly
    {
        public static Type FindInstanceOfAssembly(string sourceName, string typeName)
        {
            Type type = FindInstanceInExecutingAssembly(sourceName, typeName);
            if (type == null)
            {
                type = FindInstanceInReferencedAssemblies(sourceName, typeName);
            }
            return type;
        }

        private static Type FindInstanceInExecutingAssembly(string sourceName, string typeName)
        {
            AssemblyName[] assemblyNames = new AssemblyName[1];
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            assemblyNames[0] = assemblyName;
            return CheckTypeInAssembly(assemblyNames, sourceName, typeName);
        }
        private static Type FindInstanceInReferencedAssemblies(string sourceName, string typeName)
        {
            AssemblyName[] assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            return CheckTypeInAssembly(assemblyNames, sourceName, typeName);
        }
        private static Type CheckTypeInAssembly(AssemblyName[] assemblyNames, string sourceName, string typeName)
        {
            foreach (var assemblyName in assemblyNames)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface(typeName) != null)
                    {
                        if (type.Name.Contains(sourceName))
                        {
                            return type;
                        }
                    }
                }
            }
            return null;
        }
        public static List<object> GetInstanceFromInterface(string typeName)
        {
            List<object> instanceList = new List<object>();
            Assembly currentAssembly = Assembly.Load(Assembly.GetExecutingAssembly().GetName());
            Type[] types = currentAssembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetInterface(typeName) != null)
                {
                    instanceList.Add(Activator.CreateInstance(types[i]));
                }
            }
            return instanceList;
        }

    }
}
