using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class PrimeFactor
    {
        static void Main(string[] args)
        {
            int num = 0;
            num = Convert.ToInt32(Console.ReadLine());

            foreach(int prime in GetPrimeFactor(num))
            {
                Console.Write(prime + " ");
            }

            Console.Read();
        }

        static List<int> GetPrimeFactor(int num)
        {
            List<int> primeFactorList = new List<int>();

            if (num == 1) return primeFactorList;
            if (IsPrime(num)) { primeFactorList.Add(num); return primeFactorList; }

            for(int i = 2; i <= (int)Math.Sqrt(num); i++)
            {
                if(num % i == 0 && IsPrime(i))
                {
                    primeFactorList.Add(i);
                }
            }

            return primeFactorList;
        }

        static bool IsPrime(int num)
        {
            if (num <= 2) return true;

            for(int i = 2; i <= (int)Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
