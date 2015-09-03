using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Square s = new Square();
            s.Eat(50);

            Random rand = new Random();
            rand.Next(2);
        }
    }
}