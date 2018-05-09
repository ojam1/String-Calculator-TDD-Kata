using System;
using System.Linq;

namespace StringSum
{
    public class StringCalculator
    {
        public StringCalculator() { }

        public int Add(string numbers)
        {
            if (IsEmptyString(numbers)) return 0;

            if (IsSingleNumberString(numbers)) return int.Parse(numbers);
            
            var delimiter = DelimiterIdentifier(numbers);

            var newString = NewStringToCalculate(numbers);

            if (ContainsNegativeNumbers(newString, delimiter).Length > 0)
            {
                throw new NegativeException(ContainsNegativeNumbers(newString, delimiter));
            }

            return SplitStringByDelimter(newString, delimiter).Where(number => int.Parse(number) < 1001).Sum(int.Parse);

        }
        
        private static bool DelimiterNeeded(string numbers)
        {
            return numbers.Length > 1 && (numbers[0] == '/' && numbers[1] == '/');
        }
 
        private static char[] DelimiterIdentifier(string numbers)
        {
            var delimiter = "";
            foreach (var item in numbers)
            {
                if (item == '\n')
                {
                    break;
                }
                delimiter += item.ToString();
                
            }

            return DelimiterNeeded(numbers) ? delimiter.Substring(2).ToCharArray() : new [] {','};
        }

        private static string[] SplitStringByDelimter(string newString, char[] delimiter)
        {
            return newString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string NewStringToCalculate(string numbers)
        {
            var delimiterAsString = DelimiterIdentifier(numbers).Aggregate("", (current, item) => current + item.ToString());
            var delimiterLength = DelimiterIdentifier(numbers).Length;
            return DelimiterNeeded(numbers) ? numbers.Substring(delimiterLength+3).Replace("\n", delimiterAsString) : numbers.Replace("\n", delimiterAsString);
        }
        

        private static int[] ContainsNegativeNumbers(string newString, char[] delimiter)
        {
            return (from number in SplitStringByDelimter(newString, delimiter) where int.Parse(number) < 0 select int.Parse(number)).ToArray();
        }

        private static bool IsSingleNumberString(string numbers)
        {
            return numbers.Length == 1 && int.Parse(numbers) > 0;
        }

        private static bool IsEmptyString(string numbers)
        {   
            return string.IsNullOrWhiteSpace(numbers);
        }
    }

    public class NegativeException : Exception
    {
        public NegativeException(int[] numbers)
        {
            Console.WriteLine("negatives not allowed");
            Console.Write($"{numbers.Length} found: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}");
                if (i != numbers.Length-1)
                {
                    Console.Write(",");
                }
            }
        }
    }
}


