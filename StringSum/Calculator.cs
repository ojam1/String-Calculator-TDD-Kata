using System.Linq;

namespace StringSum
{
    public class Calculator
    {
        private readonly FormattedNumberString _formattedNumbers;

        public Calculator(FormattedNumberString formattedNumbers)
        {
            _formattedNumbers = formattedNumbers;
        }

        public int GetTotal()
        {
            return SplitByDelimiter.Splitter(_formattedNumbers).Where(number => int.Parse(number) < 1001).Sum(int.Parse);
        }
    }
}