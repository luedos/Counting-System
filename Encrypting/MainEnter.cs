using System;
using System.Collections.Generic;
using System.Text;

namespace Encrypting
{
    class MainEnter
    {
        public static void Main()
        {
            CountSystem testCS = new CountSystem(256, 97384793);

            Console.WriteLine(testCS.ToString());

            testCS.MyOrder = 26;

            Console.WriteLine(testCS.ToString());

            testCS.MyOrder = 256;

            Console.WriteLine(testCS.ToString());

            Console.ReadLine();

        }
    }
}
