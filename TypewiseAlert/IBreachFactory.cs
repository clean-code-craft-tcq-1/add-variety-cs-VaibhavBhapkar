using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IBreachFactory
    {
        IBreachType CreateInstance(string source);
    }
}
