using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class HI_ACTIVE_COOLING : ICoolingType
    {
        public int lowerLimit => 0;

        public int upperLimit => 45;
    }
}
