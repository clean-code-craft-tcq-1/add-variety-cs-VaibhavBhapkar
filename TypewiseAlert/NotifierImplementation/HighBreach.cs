using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class HighBreach : IBreachNotifier
    {
        public void Display(string recepient)
        {
            Console.WriteLine("To: {0}\n", recepient);
            Console.WriteLine("Hi, the temperature is too high\n");
        }
    }
}
