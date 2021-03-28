using System;

namespace TypewiseAlert
{
    public class TypewiseAlert
    {        
        public static AlertConstants.BreachType InferBreach(double value, double lowerLimit, double upperLimit)
        {
            if (value < lowerLimit)
            {
                return AlertConstants.BreachType.TOO_LOW;
            }
            if (value > upperLimit)
            {
                return AlertConstants.BreachType.TOO_HIGH;
            }
            return AlertConstants.BreachType.NORMAL;
        }
        
        public static AlertConstants.BreachType ClassifyTemperatureBreach(AlertConstants.CoolingType coolingType, double temperatureInC)
        {
            CoolingTypeFactory factory = new CoolingTypeFactory();
            ICoolingType coolingTypeInstance = factory.CreateInstance(coolingType.ToString());
            return InferBreach(temperatureInC, coolingTypeInstance.lowerLimit, coolingTypeInstance.upperLimit);
        }
              
        public static bool CheckParameterAndAlert(AlertConstants.AlertTarget alertTarget, AlertConstants.BatteryCharacter batteryChar, double temperatureInC)
        {
            AlertConstants.BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            AlertFactory alertFactory = new AlertFactory();
            string alertType = alertTarget.ToString().Split('_')[1].ToString().ToUpper();
            IAlerter ialertDetails = alertFactory.CreateInstance(alertType);
            return ialertDetails.GenerateAlert(breachType);
        }
       

    }
}
