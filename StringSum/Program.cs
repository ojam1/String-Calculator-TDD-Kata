using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "";
            for (int i = 1; i <= 1294; i++)
            {
                test += i.ToString();
                if (i != 1294)
                {
                    test += ",";
                }
            }

            string sdj = "1\n2,3";

            Console.WriteLine(sdj.IndexOf('\n'));
        }
    }
}
