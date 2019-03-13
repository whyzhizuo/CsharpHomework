using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> brandList = XMLUtilTV.ParseTVXML("TV.xml");
            foreach(string brandName in brandList)
            {
                try
                {
                    TV tv = TVFactory.ProduceTV(brandName);
                    tv.Play();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // 读取任意一个字符后结束
            Console.Read();
        }
    }
}
