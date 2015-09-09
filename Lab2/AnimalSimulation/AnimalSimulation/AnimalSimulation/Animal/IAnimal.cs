using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimulation
{
    public interface IAnimal
    {
        string Name { get; }
        int Weight { get; }
        bool Alive { get; }
        int Health { get; }

        /* Methods */
        int[] GetPosition();
        
        void NewDay();
    }
}
