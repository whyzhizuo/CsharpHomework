using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class HaierTV : TV
    {
        public void Play()
        {
            Console.WriteLine("海尔TV正在播放");
        }
    }
}
