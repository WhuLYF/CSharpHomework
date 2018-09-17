using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_T9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] MyArray = new int[100];
            for (int i = 0; i < 100; i++)
            {
                MyArray[i] = (i + 1);
            }
            bool[] isPrime = new bool[100];

            int p = 0;
            for (int i = 0; i < 100; i++)
            {
                isPrime[i] = true;
            }
            isPrime[0] = isPrime[1] = false;
            for (int i = 0; i < 100; i++)
            {
                if (isPrime[i])
                {
                    MyArray[p++] = i;
                    for (int j = i * 2; j < 100; j = j + i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine(MyArray[i]);
            }
        }
    }
}
