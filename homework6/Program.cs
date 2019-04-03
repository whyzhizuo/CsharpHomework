#define CUS_DEBUG
//#define NUM_DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Program
    {
        static void Main(string[] args)
        {
            

            OrderService service = new OrderService();
            service.Import("./");

            Console.WriteLine("显示所有订单信息");
            service.ShowOrderInfo();

            Console.WriteLine("\n按订单号排序");
            service.SortOrderByNum();
            service.ShowOrderInfo();

            Console.WriteLine("\n按总金额排序");
            service.SortOrderByMoney();
            service.ShowOrderInfo();

            // 序列化
            service.Export("./");

            Console.Read();

        }
    }
}
