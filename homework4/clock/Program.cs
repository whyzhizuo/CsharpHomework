using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            Console.Write("请输入定时时间(单位为秒) : \n");
            float seconds = Convert.ToSingle(Console.ReadLine());

            while(seconds <= 0)
            {
                Console.WriteLine("请输入大于0的时间");
                seconds = Convert.ToSingle(Console.ReadLine());
            }

            ClockRegister register = new ClockRegister(seconds, "用户");
            clock.Register(register);
            clock.Notify();

            Console.Read();
        }
    }

    class Clock
    {
        private delegate void ClockEvent();
        private event ClockEvent _clockEvent;

        public void Register(ClockRegister register)
        {
            _clockEvent += register.Notify;
        }

        public void Notify()
        {
            _clockEvent();
        }
    }

    class ClockRegister
    {
        private float _time;
        private string _name;

        public ClockRegister(float time, string name)
        {
            _time = time;
            _name = name;
        }

        public async void  Notify()
        {
            await Task.Delay(TimeSpan.FromSeconds(_time));
            Console.WriteLine(_name + "时间到了, 一共" + _time + "秒");
        }
    }
}
