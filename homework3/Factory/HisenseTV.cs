using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class HisenseTV : TV
    {
        public void Play()
        {
            Console.WriteLine("海信TV正在播放");
        }
    }
}
