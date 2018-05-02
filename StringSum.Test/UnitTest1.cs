
using System;
using NUnit.Framework;

namespace StringSum.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void empty_string_should_return_0()
        {
            Assert.AreEqual(StringCalculator.Add(""), 0);
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("4")]
        [TestCase("5")]
        [TestCase("7")]
        [TestCase("8")]
        [TestCase("9")]
        public void should_calculate_with_one_number(string numbers)
        {
           Assert.AreEqual(StringCalculator.Add(numbers), int.Parse(numbers));
        }

        [TestCase("1,2")]
        [TestCase("6,23")]
        [TestCase("3,4")]
        [TestCase("7,56")]
        [TestCase("1,3")]
        [TestCase("5,10")]
        [TestCase("9,9")]
        public void should_calculate_with_two_numbers(string numbers)
        {
            Assert.AreEqual(StringCalculator.Add(numbers), StringCalculaterRunner(numbers));
        }

        private static int StringCalculaterRunner(string numbers)
        {
            int sum = 0;
            foreach (string number in numbers.Split(','))
            {
                sum += int.Parse(number);
            }
            return sum;
        }

        [TestCase(100)]
        [TestCase(1024)]
        public void should_calcuate_for_large_amount_of_numbers(int numbers)
        {
            string newStringToCalc = "";
            for (int i = 1; i <= numbers; i++)
            {
                newStringToCalc += i.ToString();
                if (i != numbers)
                {
                    newStringToCalc += ",";
                }
            }
            Assert.AreEqual(StringCalculator.Add(newStringToCalc), StringCalculaterRunner(newStringToCalc));
        }

        [TestCase("1\n3")]
        [TestCase("5,1\n20")]
        [TestCase("1\n2,3")]
        public void should_calcualte_if_string_contains_new_lines(string numbers)
        {
            if (numbers.IndexOf('\n')>0)
            {
                string newStringToCalc = numbers.Replace('\n', ',');
                Assert.AreEqual(StringCalculator.Add(numbers), StringCalculaterRunner(numbers));                  
            }
        }
    }
}
