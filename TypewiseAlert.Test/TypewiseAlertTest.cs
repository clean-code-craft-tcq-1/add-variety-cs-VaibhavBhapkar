using Moq;
using System;
using TypewiseAlert.NotifierImplementation;
using Xunit;
using static TypewiseAlert.AlertConstants;

namespace TypewiseAlert.Test
{
    public class TypeWiseAlertTest
    {
        double value, lowerLimit, upperLimit,temperatureInC;
        string actualBreachType,expectedBreachType,coolingType;
        [Fact]
        public void InferBreach_ValueSmallerThanLowerLimit_Low()
        {
            value = 12;
            lowerLimit = 20;
            upperLimit = 30;
            expectedBreachType = "Low";
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            actualBreachType = typeWiseAlert.InferBreach(value,lowerLimit,upperLimit);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void InferBreach_ValueHigherThanUpperLimit_High()
        {
            value = 35;
            lowerLimit = 20;
            upperLimit = 30;
            expectedBreachType = "High";
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            actualBreachType = typeWiseAlert.InferBreach(value,lowerLimit,upperLimit);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void InferBreach_ValueInSpecifiedRange_Normal()
        {
            value = 25;
            lowerLimit = 20;
            upperLimit = 30;
            expectedBreachType = "Normal";
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            actualBreachType = typeWiseAlert.InferBreach(value, lowerLimit, upperLimit);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit_ValueComparingWithMediumCooling_High()
        {
            coolingType = "MediumCooling";
            temperatureInC = 42;
            expectedBreachType = "High";
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            actualBreachType = typeWiseAlert.ClassifyTemperatureBreach(coolingType, temperatureInC);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit_ValueComparingWithHighCooling_Normal()
        {
            coolingType = "HighCooling";
            temperatureInC = 42;
            expectedBreachType = "Normal";
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            actualBreachType = typeWiseAlert.ClassifyTemperatureBreach(coolingType, temperatureInC);
            Assert.True(actualBreachType == expectedBreachType);
        }
        [Fact]
        public void ClassifyTemperatureBreachLimit_ValueComparingWithPassiveCooling_Low()
        {
            coolingType = "PassiveCooling";
            temperatureInC = -1;
            expectedBreachType = "Low";
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            actualBreachType = typeWiseAlert.ClassifyTemperatureBreach(coolingType, temperatureInC);
            Assert.True(actualBreachType == expectedBreachType);
        }       
        [Fact]
        public void CheckParameterAndAlert_GenerateEmailAlert_WithoutException()
        {
            IBreachObserver emailBreachObserver = new EmailAlert();
            IBreachObserver consoleBreachObserver = new ConsoleAlert();
            IBreachObserver controllerBreachObserver = new ControllerAlert();
            CombineAlertNotifiers combineAlertNotifiers = new CombineAlertNotifiers();
            combineAlertNotifiers.Add(emailBreachObserver);
            combineAlertNotifiers.Add(consoleBreachObserver);
            combineAlertNotifiers.Add(controllerBreachObserver);
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert(combineAlertNotifiers);
            BatteryCharacter batteryCharacter = new BatteryCharacter("MediumCooling", "Bosch");            
            temperatureInC = 42;            
            var exception = Record.Exception(() => typeWiseAlert.CheckParameterAndAlert(batteryCharacter, temperatureInC));
            Assert.Null(exception);
        }
        
        [Fact]
        public void CheckParameterAndAlert_FakeEmailAlert_CalledAtLeastOnce()
        {
            IBreachObserver breachObserver = new FakeEmailAlert();
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert(breachObserver);
            BatteryCharacter batteryCharacter = new BatteryCharacter("MediumCooling", "Bosch");
            temperatureInC = 42;
            typeWiseAlert.CheckParameterAndAlert(batteryCharacter,temperatureInC);
            FakeEmailAlert fakeEmailAlert = breachObserver as FakeEmailAlert;
            Assert.True(fakeEmailAlert.isGenerateAlertCalledOnce);
        }
    }
}
