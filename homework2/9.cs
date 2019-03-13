using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] num = new bool[100];

            for(int i = 2; i < 100; i++)
            {
                for(int j = 2; j < 100; j++)
                {
                    if(!num[j] && j != i && j % i == 0)
                    {
                        num[j] = true;
                    }
                }
            }

            Console.Write("素数为:\n");
            for(int i = 2; i < 100; i++)
            {
                if (!num[i])
                {
                    Console.Write(i + " ");
                }
            }

            Console.Read();
        }
    }
}
