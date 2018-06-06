using System.Collections.Generic;
using System.Linq;

namespace StringSum
{
    public class NegativeNumbers
    {
        private readonly FormattedNumberString _numbers;

        public NegativeNumbers(FormattedNumberString numbers)
        {
            _numbers = numbers;
        }

        public bool HasAny()
        {
            return GetNegativeNumbers().Any();
        }

        private IEnumerable<int> GetNegativeNumbers()
        {
            return (from num in SplitByDelimiter.Splitter(_numbers) where int.Parse(num) < 0 select int.Parse(num)).ToArray();
        }
        
        public override string ToString()
        {
            return string.Join(", ", GetNegativeNumbers().Distinct().ToArray()); ;
        }
    }
}