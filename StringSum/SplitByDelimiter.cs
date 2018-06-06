using System;

namespace StringSum
{
    public class SplitByDelimiter
    {
        
        public static string[] Splitter(FormattedNumberString numbers)
        {
            return numbers.Numbers.Split(numbers.Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}