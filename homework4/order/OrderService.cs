﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderService
    {
        private List<IOrder> orderList = new List<IOrder>();

        public List<IOrder> GetOrders(string info, Choice choice)
        {
            List<IOrder> list = null;
            switch(choice)
            {
                case Choice.CUSTOM_NAME:
                    list = orderList.FindAll((IOrder order) => { return order.IsCustomName(info); });
                    break;
                case Choice.ORDER_NUM:
                    list = orderList.FindAll((IOrder order) => { return order.IsOrderNum(info); });
                    break;
                case Choice.PRODUCT_NAME:
                    list = orderList.FindAll((IOrder order) => { return order.IsProductName(info); });
                    break;
                default:
                    break;
            }
            if (list.Count != 0) return list;
            else throw new Exception("无此订单");
        }

        public bool AddOrder(IOrder order)
        {
            if (orderList.Find((IOrder o) => { return o.IsOrderNum(order.GetOrderNum()); }) != null)
            {
                throw new Exception("订单号重复");
            }
            else
            {
                orderList.Add(order);
                return true;
            }
        }

        public bool UpdateOrder(string oldName, string newName, string orderNum, Choice choice)
        {
            // 如果没有找到则会发生异常,对异常捕获并返回false,其它情况下则返回true
            try
            {
                List<IOrder> m_orderList = GetOrders(orderNum, Choice.ORDER_NUM);

                switch (choice)
                {
                    // 判断是要修改订单的顾客名部分还是商品名部分等(其中订单号不可修改)
                    case Choice.CUSTOM_NAME:
                        m_orderList[0].UpdateCustomName(newName);
                        break;
                    case Choice.PRODUCT_NAME:
                        m_orderList[0].UpdateProductName(oldName, newName);
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void ShowOrderInfo()
        {
            foreach(IOrder order in orderList)
            {
                order.ShowOrderInfo();
            }
        }
    }
}
