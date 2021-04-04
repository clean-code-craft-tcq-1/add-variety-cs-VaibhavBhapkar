using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class AlertConstants
    {
        public enum BreachType
        {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };
        public enum CoolingType
        {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };
        public enum AlertTarget
        {
            TO_CONTROLLER,
            TO_EMAIL,
            TO_CONSOLE
        };
        public struct BatteryCharacter
        {
            public AlertConstants.CoolingType coolingType;
            public string brand;
            public BatteryCharacter(AlertConstants.CoolingType coolingType,string brand)
            {
                this.coolingType = coolingType;
                this.brand = brand;
            }
        };
    }
}
