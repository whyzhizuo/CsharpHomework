using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, -2, 12, 21 };
            ShowValue(list);

            Console.Read();
        }

        static void ShowValue(params int[] intList)
        {
            int minValue = Int32.MaxValue, maxValue = Int32.MinValue, allValue = 0;
            foreach(int num in intList)
            {
                if (num <= minValue) minValue = num;

                if (num >= maxValue) maxValue = num;

                allValue += num;
            }

            Console.Write("最大值为:" + maxValue + "\n最小值为:" + minValue + "\n所有元素的和为:" + allValue + "\n均值为:" + (float)allValue / intList.Length);
        }
    }
}
