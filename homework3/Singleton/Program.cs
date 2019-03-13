using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.ShowMessage();

            // 读取任意一个字符结束
            Console.Read();
        }
    }
}
