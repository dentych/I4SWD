using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimulation
{
    public enum Direction
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    public interface IGrid
    {
        bool CanMove(IAnimal animal, Direction dir);

        Square GetSquare(IAnimal animal);
    }
}
