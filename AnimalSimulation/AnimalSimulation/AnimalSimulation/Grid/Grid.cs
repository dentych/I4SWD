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

    public class Grid
    {
        private Square[,] grid;
        private int height, width;
        private static Grid instance;

        public Grid()
        {
            instance = this;
        }

        public static Grid GetInstance()
        {
            return instance;
        }

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new Square[width, height];
        }

        public bool CanMove(int x, int y)
        {
            if ((x >= 0 && x < width) && (y >= 0 && y < height))
            {
                return true;
            }

            return false;
        }

        public Square GetSquare(IAnimal a)
        {
            int[] position = a.GetPosition();

            return grid[position[0], position[1]];
        }

        public int[] GetStartCoords()
        {
            Random rand = new Random();
            int[] coords = { rand.Next(0, width), rand.Next(0, height) };

            return coords;
        }
    }
}
