using System;
using System.Collections.Generic;

namespace TypewiseAlert
{
    public class TypewiseAlert
    {        
        public static string InferBreach(double value, double lowerLimit, double upperLimit)
        {
            
            string result = "Normal";            
            List<string> breachTypes = new List<string>();
            Dictionary<string, double> limitsAsPerBreachType = new Dictionary<string, double>();
            limitsAsPerBreachType.Add("HighBreachType", upperLimit);
            limitsAsPerBreachType.Add("LowBreachType", lowerLimit);
            breachTypes = GetBreachTypesByComparingWithValue(value, limitsAsPerBreachType);
            result = breachTypes.Find(x => x != "Normal");
            result = result == null ? "Normal" : result;
            return result;
        }        
        public static string ClassifyTemperatureBreach(string coolingType, double temperatureInC)
        {
            ICoolingType coolingTypeInstance = CreateCoolingTypeInstanceFromFactory(coolingType);
            return InferBreach(temperatureInC, coolingTypeInstance.lowerLimit, coolingTypeInstance.upperLimit);
        }              
        public static void CheckParameterAndAlert(string alertTarget, AlertConstants.BatteryCharacter batteryChar, double temperatureInC)
        {
            string breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);            
            IAlerter ialertDetails = CreateAlertTypeInstanceFromFactory(alertTarget);
            ialertDetails.GenerateAlert(breachType);
        }
        private static IAlerter CreateAlertTypeInstanceFromFactory(string alertType)
        {
            AlertFactory alertFactory = new AlertFactory();
            return alertFactory.GetInstanceOfAlertType(alertType);
        }
        private static ICoolingType CreateCoolingTypeInstanceFromFactory(string coolingType)
        {
            CoolingTypeFactory coolingTypeFactory = new CoolingTypeFactory();
            return coolingTypeFactory.GetInstanceOfCoolingType(coolingType);
        }
        private static List<string> GetBreachTypesByComparingWithValue(double value, Dictionary<string, double> limitsAsPerBreachType)
        {
            
            double limitValue = 0;
            string breachTypeObjectName = string.Empty;            
            List<Object> breachTypeObjects = new List<object>();
            List<string> breachTypes = new List<string>();
            BreachFactory breachFactory = new BreachFactory();
            breachTypeObjects = breachFactory.GetInstanceListOfBreachType();
            foreach (Object typeObject in breachTypeObjects)
            {
                breachTypeObjectName = typeObject.ToString();
                foreach (KeyValuePair<string, double> breachLimit in limitsAsPerBreachType)
                {
                    if (breachLimit.Key == breachTypeObjectName.Split('.')[1])
                    {
                        limitValue = breachLimit.Value;
                        break;
                    }
                }
                breachTypes.Add(new InferBreachParameter((IBreachType)typeObject).BreachLimit(value, limitValue));
            }
            return breachTypes;
        }
    }
}
