using System;

namespace StringSum
{
    class Program
    {
        private static readonly StringCalculator _strCalc = new StringCalculator();
        static void Main(string[] args)
        {
            string str = "5,1\n20";
            string str2 = "//####\n1####23####2";
            Console.WriteLine(_strCalc.Add(str2));
        }
            
        }
    }

