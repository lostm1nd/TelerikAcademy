using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FallDown
{
    class Program
    {
        static void Main(string[] args)
        {
            //store numbers in array
            byte[] numbers = new byte[8];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = byte.Parse(Console.ReadLine());
            }

            //cycle 8 times through all numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    byte temp = (byte)(numbers[j-1] & numbers[j]); //take all zero bits
                    numbers[j] = (byte)(numbers[j - 1] | numbers[j]); //take all one bits and put them on the next row
                    numbers[j - 1] = temp; //put all the zero bits on the previous row
                }
            }

            //print new numbers
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
