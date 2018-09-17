using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("输入一个整数:");
            string s = " ";
            s = Console.ReadLine();
            int n = Int32.Parse(s);
            Console.WriteLine(s + "以内的素数为:");
            int k = 0;
            for (int i = 1; i < n; i++)
            {
                k = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        k++;
                    }
                }
                if (k == 1)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
