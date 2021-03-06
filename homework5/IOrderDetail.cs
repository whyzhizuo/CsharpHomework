﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    interface IOrderDetail
    {
        string GetProductName();
        int GetOrderDetailMoney();
        bool UpdateProductName(string newName);
        void ShowOrderDetail();
        IOrderDetail Clone();
    }
}
