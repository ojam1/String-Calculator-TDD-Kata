using NUnit.Framework;

namespace StringSum.Test
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void SetUp()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void Empty_string_should_return_0()
        {
            Assert.AreEqual(_stringCalculator.Add(""), 0);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        public void Should_calculate_with_one_number(string numbers, int expected)
        {
           Assert.AreEqual(_stringCalculator.Add(numbers), expected);
        }

        [TestCase("1,2",3)]
        [TestCase("3,4", 7)]
        public void Should_calculate_with_two_numbers(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers), expected);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        public void Should_calcuate_for_large_amount_of_numbers(string numbers, int expected)
        {
           Assert.AreEqual(_stringCalculator.Add(numbers), expected);
        }

        [TestCase("1\n2",3)]
        [TestCase("1,2\n3",6)]
        [TestCase("3\n4,5",12)]
        public void Should_calcualte_if_string_contains_new_lines(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers), expected);                  
            
        }

        [TestCase("//s\n1s2",3)]
        [TestCase("//;\n2;3;4",9)]
        public void Should_calculate_with_optional_delimiter(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers), expected);
        }

        [TestCase("//**\n1**2", 3)]
        [TestCase("//####\n1####2", 3)]
        public void Should_calculate_with_optional_multi_char_delimiter(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers), expected);
        }

        [TestCase("1,-1", "Negatives not allowed, -1")]
        [TestCase("2,-4,-1", "Negatives not allowed, -4, -1")]
        [TestCase("-1,-1", "Negatives not allowed, -1")]
        public void Negatives_not_allowed(string numbers, string exceptionMessage)
        {
            var ex = Assert.Throws<NegativeException>(() => _stringCalculator.Add(numbers));
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [TestCase("1,1001",1)]
        [TestCase("2,1000",1002)]
        public void Should_ignore_numbers_greater_than_1000(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers), expected);
        }
    }
}
