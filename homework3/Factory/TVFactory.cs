using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class TVFactory
    {
        public static TV ProduceTV(string brandName)
        {
            if(brandName.ToLower().Equals("haier"))
            {
                return new HaierTV();
            }
            else if(brandName.ToLower().Equals("hisense"))
            {
                return new HisenseTV();
            }
            else
            {
                throw new Exception("没有这种类型的电视");
            }
        }
    }
}
