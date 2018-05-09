using NUnit.Framework;

namespace StringSum.Test
{
    [TestFixture]
    public class UnitTest1
    {
        internal StringCalculator StrCalc = new StringCalculator();

        [Test]
        public void empty_string_should_return_0()
        {
            Assert.AreEqual(StrCalc.Add(""), 0);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        [TestCase("4",4)]
        [TestCase("5",5)]
        [TestCase("7",7)]
        [TestCase("8",8)]
        [TestCase("9",9)]
        public void should_calculate_with_one_number(string numbers, int expected)
        {
           Assert.AreEqual(StrCalc.Add(numbers), expected);
        }

        [TestCase("1,2",3)]
        [TestCase("6,23", 29)]
        [TestCase("3,4", 7)]
        [TestCase("7,56", 63)]
        [TestCase("1,3", 4)]
        [TestCase("5,10", 15)]
        [TestCase("9,9", 18)]
        public void should_calculate_with_two_numbers(string numbers, int expected)
        {
            Assert.AreEqual(StrCalc.Add(numbers), expected);
        }

        [TestCase(100,5050)]
        [TestCase(1024,500500)]
        public void should_calcuate_for_large_amount_of_numbers(int numbers, int expected)
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
            Assert.AreEqual(StrCalc.Add(newStringToCalc), expected);
        }

        [TestCase("1\n3",4)]
        [TestCase("5,1\n20",26)]
        [TestCase("1\n2,3",6)]
        public void should_calcualte_if_string_contains_new_lines(string numbers, int expected)
        {
            Assert.AreEqual(StrCalc.Add(numbers), expected);                  
            
        }

        [TestCase("//s\n1s3",4)]
        [TestCase("//;\n5;1;20",26)]
        [TestCase("//*\n12*3",15)]
        public void should_calculate_with_optional_delimiter(string numbers, int expected)
        {
            Assert.AreEqual(StrCalc.Add(numbers), expected);
        }

        [TestCase("//**\n1**23**2", 26)]
        [TestCase("//####\n1####23####2", 26)]
        [TestCase("//ccc\n1ccc1ccc1", 3)]
        public void should_calculate_with_optional_multi_char_delimiter(string numbers, int expected)
        {
            Assert.AreEqual(StrCalc.Add(numbers), expected);
        }

        [TestCase("1,-1")]
        [TestCase("2,-4,-1")]
        [TestCase("-1,-1,-1")]
        public void negatives_not_allowed(string numbers)
        {
            Assert.Throws<NegativeException>(() => StrCalc.Add(numbers));
        }

        [TestCase("1,1002,6,2",9)]
        [TestCase("2,1000",1002)]
        [TestCase("12,3,12938",15)]
        public void should_ignore_numbers_greater_than_1000(string numbers, int expected)
        {
            Assert.AreEqual(StrCalc.Add(numbers), expected);
        }
    }
}
