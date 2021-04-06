using System;
using Xunit;
using static TypewiseAlert.AlertConstants;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InferBreachAsPerLowLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 20, 30) ==
              AlertConstants.BreachType.TOO_LOW);
        }
        [Fact]
        public void InferBreachAsPerHighLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(35, 20, 30) ==
              AlertConstants.BreachType.TOO_HIGH);
        }
        [Fact]
        public void InferBreachAsPerNormal()
        {
            Assert.True(TypewiseAlert.InferBreach(25, 20, 30) ==
              AlertConstants.BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimitMediun()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(AlertConstants.CoolingType.MED_ACTIVE_COOLING, 42) ==
              AlertConstants.BreachType.TOO_HIGH);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimitHigh()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(AlertConstants.CoolingType.HI_ACTIVE_COOLING, 42) ==
              AlertConstants.BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimitLow()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(AlertConstants.CoolingType.PASSIVE_COOLING, -1) ==
              AlertConstants.BreachType.TOO_LOW);
        }       
        [Fact]
        public void CheckAlertTypeConsole()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter(AlertConstants.CoolingType.MED_ACTIVE_COOLING, "Bosch");
            var exception = Record.Exception(() => TypewiseAlert.CheckParameterAndAlert(AlertConstants.AlertTarget.TO_CONSOLE, batteryCharacter, 42));
            Assert.Null(exception);
        }
        
        [Fact]
        public void CheckFakeAlert()
        {
            FakeAlert fakeAlert = new FakeAlert();
            IAlerter generateTrigger = fakeAlert;
            generateTrigger.GenerateAlert(AlertConstants.BreachType.TOO_HIGH);
            IFakeAlertChecker fakeAlertChecker = fakeAlert;
            Assert.True(fakeAlertChecker.IsAlertTriggered());
        }
    }
}
