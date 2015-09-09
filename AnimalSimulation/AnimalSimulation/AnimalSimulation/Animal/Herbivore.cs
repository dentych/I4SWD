using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimulation
{
    class Herbivore : IAnimal
    {
        /* Public variables/properties */
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public bool Alive { get; private set; }
        public int Energy { get; private set; }

        /* Private variables */
        private int[] coordinates;
        private Square currentSquare;

        /* Constructor */
        public Herbivore(string name, int weight)
        {
            Name = name;
            Weight = weight;
            Alive = true;
            Energy = 100;
            coordinates = Grid.GetInstance().GetStartCoords();
        }

        /* Public methods */
        public int[] GetPosition()
        {
            return coordinates;
        }

        public void NewDay()
        {
            Energy -= 5;
            if (Energy <= 0)
            {
                Alive = false;
                return;
            }

            Grid grid = Grid.GetInstance();
            currentSquare = grid.GetSquare(this);

            if (currentSquare.FoodAvailable())
            {
                Eat();
            }
        }

        /* Private methods */
        private void Eat()
        {
            int fullHealthNeed = (int)(Weight * 0.20);
            int currentNeed = (int)(((100 - (double)Energy) / 100) * fullHealthNeed);

            int energyBoost = (currentSquare.Eat(currentNeed)/fullHealthNeed)*100;
        }
    }
}