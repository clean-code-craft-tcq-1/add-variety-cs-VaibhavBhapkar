using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface ICoolingTypeFactory
    {
        ICoolingType CreateInstance(string source);
    }
}
