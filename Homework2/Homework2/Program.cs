using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] MyArray = { 1, 5, 9, 15, 25, 40, 64, 92 };
            int length = MyArray.Length;
            //求最大数
            int max = MyArray[0];
            for (int i = 0; i < length; i++)
            {
                if (max < MyArray[i])
                {
                    max = MyArray[i];
                }
            }
            Console.WriteLine("最大数：" + max);
            //求最小数
            int min = MyArray[0];
            for (int i = 0; i < length; i++)
            {
                if (min > MyArray[i])
                {
                    min = MyArray[i];
                }
            }
            Console.WriteLine("最小数：" + min);
            //求和
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += MyArray[i];
            }
            Console.WriteLine("和：" + sum);
            //求平均数
            int average = sum / length;
            Console.WriteLine("平均数：" + average);
        }
    }
}
