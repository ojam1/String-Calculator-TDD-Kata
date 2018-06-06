namespace StringSum
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (ContainsNoNumbers(numbers)) return 0;

            if (ContainsASingleNumber(numbers)) return GetSingleNumber(numbers);

            var formattedNumbers = new FormattedNumberString(numbers);

            var negativeNumbers = new NegativeNumbers(formattedNumbers);

            if (negativeNumbers.HasAny())
                throw new NegativeException($"Negatives not allowed, {negativeNumbers}");

            return new Calculator(formattedNumbers).GetTotal();
        }

        private static int GetSingleNumber(string numbers)
        {
            return int.Parse(numbers);
        }

        private static bool ContainsASingleNumber(string numbers)
        {
            return numbers.Length == 1 && int.Parse(numbers) > 0;
        }

        private static bool ContainsNoNumbers(string numbers)
        {   
            return string.IsNullOrWhiteSpace(numbers);
        }
    }
}


