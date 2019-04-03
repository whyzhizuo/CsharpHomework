using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    [Serializable]
    class OrderDetail : IOrderDetail
    {
        private string _productName;
        private int _money; // 用来描述这个订单明细的金额
        // 此处如果对商品的其它属性有需要还可以继续添加

        public OrderDetail(string name, int money)
        {
            _productName = name;
            _money = money;
        }

        public string GetProductName()
        {
            return _productName;
        }

        public bool UpdateProductName(string newName)
        {
            _productName = newName;
            return true;
        }

        public void ShowOrderDetail()
        {
            Console.WriteLine("商品:" + _productName);
        }

        public IOrderDetail Clone()
        {
            OrderDetail newDetail = new OrderDetail(this._productName, this._money);
            return newDetail;
        }

        public override bool Equals(object obj)
        {
            OrderDetail detail = obj as OrderDetail;
            if(detail != null)
            {
                return detail._productName.Equals(this._productName);
            }
            return false;
        }

        public override string ToString()
        {
            return "商品:" + _productName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int GetOrderDetailMoney()
        {
            return _money;
        }
    }
}
