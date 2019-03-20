using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Order : IOrder
    {
        private List<IOrderDetail> _orderDetails;
        private string _customName; // 每一个订单有一个唯一的顾客
        private string _orderNum; // 每一个订单号唯一标识一个订单，并且订单号不可重复

        public Order(string customName, string orderNum)
        {
            Init(customName, orderNum);
        }

        public Order(string customName, string orderNum, params IOrderDetail[] details)
        {
            Init(customName, orderNum);
            foreach(IOrderDetail d in details)
            {
                _orderDetails.Add(d.Clone());
            }
        }

        private void Init(string customName, string orderNum)
        {
            _orderDetails = new List<IOrderDetail>();
            _customName = customName;
            _orderNum = orderNum;
        }

        public void AddOrderDetail(IOrderDetail detail)
        {
            _orderDetails.Add(detail.Clone());
        }

        public string GetOrderNum()
        {
            return _orderNum;
        }

        public bool IsCustomName(string customName)
        {
            return _customName.Equals(customName);
        }

        public bool IsOrderNum(string orderNum)
        {
            return _orderNum.Equals(orderNum);
        }

        public bool IsProductName(string productName)
        {
            return _orderDetails.Find((IOrderDetail od) => { return od.GetProductName().Equals(productName); }) != null;
        }

        public bool UpdateCustomName(string newCustomName)
        {
            _customName = newCustomName;
            return true;
        }

        public bool UpdateProductName(string oldName, string newProductName)
        {
            var list = _orderDetails.FindAll((IOrderDetail od) => { return od.GetProductName().Equals(oldName); });
            if(list.Count == 0)
            {
                Console.WriteLine("此订单无此名称所指定的商品");
                return false;
            }
            else
            {
                foreach(IOrderDetail od in list)
                {
                    od.UpdateProductName(newProductName);
                }
                return true;
            }
        }

        public void ShowOrderInfo()
        {
            Console.WriteLine("订单号:" + _orderNum);
            Console.WriteLine("顾客 : " + _customName);
            Console.WriteLine("商品信息: ");
            foreach(IOrderDetail detail in _orderDetails)
            {
                detail.ShowOrderDetail();
            }
        }

    }
}
