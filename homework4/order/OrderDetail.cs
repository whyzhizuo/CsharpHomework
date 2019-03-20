using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderDetail : IOrderDetail
    {
        private string _productName;
        // 此处如果对商品的其它属性有需要还可以继续添加

        public OrderDetail(string name)
        {
            _productName = name;
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
            OrderDetail newDetail = new OrderDetail(this._productName);
            return newDetail;
        }
    }
}
