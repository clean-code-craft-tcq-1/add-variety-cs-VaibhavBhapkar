using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface IAlertFactory
    {
        IAlerter CreateInstance(string source);
    }
}
