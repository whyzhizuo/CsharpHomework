using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Singleton
    {
        private static Singleton instance;
        public static Singleton Instance {get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void ShowMessage()
        {
            Console.WriteLine("我是单例");
        }

        private Singleton()
        {
            ;
        }
    }
}
