using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OrderManage
{
    interface IOrder
    {
        void AddOrderDetail(IOrderDetail detail);

        bool IsCustomName(string customName);
        bool IsOrderNum(string orderNum);
        bool IsProductName(string productName);

        string GetOrderNum(); // 获取订单号，订单号是唯一的

        bool UpdateCustomName(string newCustomName);
        bool UpdateProductName(string oldName, string newProductName);

        int GetAllMoney();
        void ShowOrderInfo();
    }
}
