using Moq;
using System;
using Xunit;
using static TypewiseAlert.AlertConstants;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        double value, lowerLimit, upperLimit,temperatureInC;
        string actualBreachType,expectedBreachType,coolingType,alertType;
        [Fact]
        public void InferBreach_ValueSmallerThanLowerLimit_Low()
        {
            value = 12;
            lowerLimit = 20;
            upperLimit = 30;
            expectedBreachType = "Low";
            actualBreachType = TypewiseAlert.InferBreach(value,lowerLimit,upperLimit);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void InferBreach_ValueHigherThanUpperLimit_High()
        {
            value = 35;
            lowerLimit = 20;
            upperLimit = 30;
            expectedBreachType = "High";
            actualBreachType = TypewiseAlert.InferBreach(value,lowerLimit,upperLimit);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void InferBreach_ValueInSpecifiedRange_Normal()
        {
            value = 25;
            lowerLimit = 20;
            upperLimit = 30;
            expectedBreachType = "Normal";
            actualBreachType = TypewiseAlert.InferBreach(value, lowerLimit, upperLimit);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit_ValueComparingWithMediumCooling_High()
        {
            coolingType = "MediumCooling";
            temperatureInC = 42;
            expectedBreachType = "High";
            actualBreachType = TypewiseAlert.ClassifyTemperatureBreach(coolingType, temperatureInC);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit_ValueComparingWithHighCooling_Normal()
        {
            coolingType = "HighCooling";
            temperatureInC = 42;
            expectedBreachType = "Normal";
            actualBreachType = TypewiseAlert.ClassifyTemperatureBreach(coolingType, temperatureInC);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit_ValueComparingWithPassiveCooling_Low()
        {
            coolingType = "PassiveCooling";
            temperatureInC = -1;
            expectedBreachType = "Low";
            actualBreachType = TypewiseAlert.ClassifyTemperatureBreach(coolingType, temperatureInC);
            Assert.True(actualBreachType == expectedBreachType);
        }       
        [Fact]
        public void CheckParameterAndAlert_GenerateEmailAlert_WithoutException()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("MediumCooling", "Bosch");
            alertType = "EmailAlert";
            temperatureInC = 42;
            var exception = Record.Exception(() => TypewiseAlert.CheckParameterAndAlert(alertType, batteryCharacter, temperatureInC));
            Assert.Null(exception);
        }
        
        [Fact]
        public void CheckParameterAndAlert_FakeEmailAlert_CalledAtLeastOnce()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("MediumCooling", "Bosch");
            alertType = "FakeEmailAlert";
            temperatureInC = 42;
            var fakeAlertNotifier = new Mock<FakeEmailAlert>();
            fakeAlertNotifier.Setup(x => x.GenerateAlert("High")).Verifiable();
            var exception = Record.Exception(() => TypewiseAlert.CheckParameterAndAlert(alertType,batteryCharacter,temperatureInC));
            Assert.Null(exception);
            Assert.True(FakeEmailAlert.isGenerateAlertCalledOnce);
        }
    }
}
