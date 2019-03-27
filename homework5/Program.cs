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
            OrderDetail detail1 = new OrderDetail("1号商品", 20);
            OrderDetail detail2 = new OrderDetail("2号商品", 40);
            OrderDetail detail3 = new OrderDetail("3号商品", 10);
            OrderDetail detail4 = new OrderDetail("4号商品", 80);

            Order order1 = new Order("顾客1", "1", detail1, detail2);
            Order order2 = new Order("顾客2", "2", detail2, detail3);
            Order order3 = new Order("顾客1", "3", detail3, detail4, detail1);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            Console.WriteLine("显示所有订单信息");
            service.ShowOrderInfo();

            Console.WriteLine("\n按订单号排序");
            service.SortOrderByNum();
            service.ShowOrderInfo();

            Console.WriteLine("\n按总金额排序");
            service.SortOrderByMoney();
            service.ShowOrderInfo();

            Console.Read();
        }
    }
}
