using System.Linq;

namespace StringSum
{
    public class FormattedNumberString
    {
        public readonly string Numbers;
        public readonly string Delimiter;

        public FormattedNumberString(string numbers)
        {
            Delimiter = new Delimiter(numbers).GetIdentifier().Aggregate("", (current, item) => current + item.ToString());

            Numbers = !Delimiter.Contains(',') ? numbers.Substring(Delimiter.Length + 3).Replace("\n", Delimiter) : numbers.Replace("\n", Delimiter);
        }
    }
}