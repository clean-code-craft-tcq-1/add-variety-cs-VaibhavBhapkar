using System;
using System.Collections.Generic;

namespace TypewiseAlert
{
    public class TypewiseAlert
    {        
        public static AlertConstants.BreachType InferBreach(double value, double lowerLimit, double upperLimit)
        {
            string breachTypeObjectName = string.Empty;
            double limitValue = 0;
            AlertConstants.BreachType result = AlertConstants.BreachType.NORMAL;
            List<Object> breachTypeObjects = new List<object>();
            List<AlertConstants.BreachType> breachTypes = new List<AlertConstants.BreachType>();
            Dictionary<string, double> limitsAsPerBreachType = new Dictionary<string, double>();
            limitsAsPerBreachType.Add("HighBreachType", upperLimit);
            limitsAsPerBreachType.Add("LowBreachType", lowerLimit);
            BreachFactory breachFactory = new BreachFactory();            
            breachTypeObjects = breachFactory.GetInstanceListOfBreachType();
            foreach (Object typeObject in breachTypeObjects)
            {
                breachTypeObjectName = typeObject.ToString();
                foreach (KeyValuePair<string, double>  breachLimit in limitsAsPerBreachType)
                {
                    if (breachLimit.Key == breachTypeObjectName.Split('.')[1])
                    {
                        limitValue = breachLimit.Value;
                        break;
                    }
                }
                breachTypes.Add(new InferBreachParameter((IBreachType)typeObject).BreachLimit(value,limitValue));
            }
            result = breachTypes.Find(x => x != AlertConstants.BreachType.NORMAL);
            return result;
        }
        
        public static AlertConstants.BreachType ClassifyTemperatureBreach(AlertConstants.CoolingType coolingType, double temperatureInC)
        {
            CoolingTypeFactory factory = new CoolingTypeFactory();
            ICoolingType coolingTypeInstance = factory.GetInstanceOfCoolingType(coolingType.ToString());
            return InferBreach(temperatureInC, coolingTypeInstance.lowerLimit, coolingTypeInstance.upperLimit);
        }
              
        public static bool CheckParameterAndAlert(AlertConstants.AlertTarget alertTarget, AlertConstants.BatteryCharacter batteryChar, double temperatureInC)
        {
            AlertConstants.BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            AlertFactory alertFactory = new AlertFactory();
            string alertType = alertTarget.ToString().Split('_')[1].ToString().ToUpper();
            IAlerter ialertDetails = alertFactory.GetInstanceOfAlertType(alertType);
            ialertDetails.GenerateAlert(breachType);
            return ialertDetails.isGenerateAlertCalledOnce;
        }
       

    }
}
