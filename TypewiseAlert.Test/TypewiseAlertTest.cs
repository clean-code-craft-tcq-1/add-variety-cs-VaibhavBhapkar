using System;
using Xunit;
using static TypewiseAlert.AlertConstants;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 20, 30) ==
              AlertConstants.BreachType.TOO_LOW);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(AlertConstants.CoolingType.MED_ACTIVE_COOLING, 42) ==
              AlertConstants.BreachType.TOO_HIGH);
        }
        [Fact]
        public void CheckAlertType()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter(AlertConstants.CoolingType.MED_ACTIVE_COOLING, "Bosch");
            Assert.True(TypewiseAlert.CheckParameterAndAlert(AlertConstants.AlertTarget.TO_EMAIL, batteryCharacter, 42) ==
              true);
        }
    }
}
