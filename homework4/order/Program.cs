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
            OrderDetail detail1 = new OrderDetail("1号商品");
            OrderDetail detail2 = new OrderDetail("2号商品");
            OrderDetail detail3 = new OrderDetail("3号商品");
            OrderDetail detail4 = new OrderDetail("4号商品");

            Order order1 = new Order("顾客1", "1", detail1, detail2);
            Order order2 = new Order("顾客2", "2", detail2, detail3);
            Order order3 = new Order("顾客1", "3", detail3, detail4, detail1);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            service.ShowOrderInfo();

            Console.WriteLine("---------这里是分割线---------");
            // 获取顾客1的所有订单
            foreach(var order in service.GetOrders("顾客1", Choice.CUSTOM_NAME))
            {
                order.ShowOrderInfo();
            }

            Console.WriteLine("---------这里是分割线---------");
            // 获取所有包含3号商品的订单
            foreach (var order in service.GetOrders("3号商品", Choice.PRODUCT_NAME))
            {
                order.ShowOrderInfo();
            }

            Console.WriteLine("---------这里是分割线---------");
            // 修改2号订单的2号商品名称为5号商品
            service.UpdateOrder("2号商品", "5号商品", "2", Choice.PRODUCT_NAME);
            foreach(var order in service.GetOrders("2", Choice.ORDER_NUM))
            {
                order.ShowOrderInfo();
            }

            Console.WriteLine("---------这里是分割线---------");
            // 如果查询不存在的订单号便会发生异常
#if NUM_DEBUG
            service.GetOrders("我是不存在的订单号", Choice.ORDER_NUM);
#endif

            // 如果查询不存在的顾客
#if CUS_DEBUG
            service.GetOrders("我是不存在的顾客", Choice.CUSTOM_NAME);
#endif

            Console.Read();
        }
    }
}
