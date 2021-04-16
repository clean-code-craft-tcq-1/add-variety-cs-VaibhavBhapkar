using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class HighCooling : ICoolingType
    {
        public int lowerLimit => 0;

        public int upperLimit => 45;
    }
}
