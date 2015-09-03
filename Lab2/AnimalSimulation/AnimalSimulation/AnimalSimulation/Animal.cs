using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimulation
{
    public interface IAnimal
    {
        /* Properties */
        /// <summary>
        /// Name of the animal.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The weight of the animal in kg.
        /// </summary>
        int Weight { get; }
        /// <summary>
        /// The animal's state. True if alive, false if dead.
        /// </summary>
        bool Alive { get; }
        /// <summary>
        /// Health status of the animal in percent.
        /// </summary>
        int Health { get; }

        /* Methods */
        /// <summary>
        /// Gets the position of the animal on the grid.
        /// </summary>
        int[] GetPosition();

        /// <summary>
        /// Tells the animal that a new day has commenced, which will trigger it's AI-like behaviour.
        /// </summary>
        void NewDay();

        /// <summary>
        /// Try to eat.
        /// </summary>
        void Eat();
    }

    public class Herbivore : IAnimal
    {
        /* Attributes */
        private int coordX, coordY;
        private IGrid grid;

        public string Name { get; private set; }
        public int Weight { get; private set; }
        public bool Alive { get; private set; }
        public int Health { get; private set; }

        /* Constructor */
        public Herbivore(IGrid grid)
        {
            this.grid = grid;
        }

        /* Methods */
        public int[] GetPosition()
        {
            int[] position = { coordX, coordY };
            return position;
        }

        public void NewDay()
        {
            Square currentSquare = grid.GetSquare(this);
            if (currentSquare.PlantMass > 0)
            {
                Eat();
            }
            else
            {
                Move();
            }
        }

        public void Eat()
        {
            // Eating
        }

        public void TakeDamage(int dmg)
        {
            Health -= dmg;
            if (Health <= 0)
                Alive = false;
        }

        private void Move()
        {
            Direction dir;
            bool moved = false;

            while (!moved)
            {
                dir = (Direction) AnimalSim.rand.Next(4);
                if (grid.CanMove(this, dir))
                {
                    Move(dir);
                    moved = true;
                }
            }
        }

        private void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.UP:
                    coordY--;
                    break;
                case Direction.DOWN:
                    coordY++;
                    break;
                case Direction.LEFT:
                    coordX--;
                    break;
                case Direction.RIGHT:
                    coordX++;
                    break;
            }
        }
    }

    public class Carnivore : IAnimal
    {

    }
}
