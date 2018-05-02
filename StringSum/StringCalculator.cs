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

        public static int Add(string numbers)
        {
            var sum = 0;
            if (numbers.Length > 1)
            {
                foreach (var number in numbers.Split(','))
                {
                    sum += int.Parse(number);
                }
            }
            else sum = string.IsNullOrWhiteSpace(numbers) ? 0 : int.Parse(numbers);

            return sum;
        }
    }
}
