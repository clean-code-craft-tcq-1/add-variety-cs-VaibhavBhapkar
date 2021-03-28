using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TypewiseAlert
{
    public class CoolingTypeFactory
    {       
        public ICoolingType GetInstanceOfCoolingType(string source)
        {
            Type typeAssembly = FindAssembly.FindInstanceOfAssembly(source,typeof(ICoolingType).ToString());
            if (typeAssembly == null) throw new Exception("Bad Type");
            else return Activator.CreateInstance(typeAssembly) as ICoolingType;
        }      
       
    }
}
