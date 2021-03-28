using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface ICoolingType
    {
        int lowerLimit { get; }
        int upperLimit { get; }
    }
}
