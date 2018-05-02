using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSum
{
    public class StringCalculator
    {
        public StringCalculator()
        {  

            
        }

       public int Add(string numbers)
        {
            string newStringToCalculate = numbers.Replace('\n', ',');

            if (newStringToCalculate.Length == 1)
            {
                return int.Parse(newStringToCalculate);
            }

            return (newStringToCalculate.Length <= 1 || string.IsNullOrWhiteSpace(newStringToCalculate))
                ? 0
                : newStringToCalculate.Split(',').Sum(int.Parse);
        }
    }
}
