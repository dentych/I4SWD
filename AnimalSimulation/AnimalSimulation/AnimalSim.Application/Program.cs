using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSim.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int Weight = 1234;
            int Energy = 75;

            int fullHealthEatAmount = (int)(Weight * 0.20);
            int need = (int)(((100 - (double)Energy) / 100) * fullHealthEatAmount);

            Console.WriteLine("Need: {0}.", need);

            int received = 100;
            int boost = (int)((double)received / fullHealthEatAmount * 100);

            Console.WriteLine("Boost: {0}.", boost);
        }
    }
}