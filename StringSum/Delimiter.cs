namespace StringSum
{
    public class Delimiter
    {
        private readonly string _numbers;
        

        public Delimiter(string numbers)
        {
            _numbers = numbers;
        }

        private static bool DelimiterNeeded(string numbers)
        {
            return numbers.Length > 1 && (numbers[0] == '/' && numbers[1] == '/');
        }

        public char[] GetIdentifier()
        {
            var delimiter = "";
            foreach (var item in _numbers)
            {
                if (item == '\n')
                {
                    break;
                }
                delimiter += item.ToString();

            }

            return DelimiterNeeded(_numbers) ? delimiter.Substring(2).ToCharArray() : new[] { ',' };
        }
    }
}