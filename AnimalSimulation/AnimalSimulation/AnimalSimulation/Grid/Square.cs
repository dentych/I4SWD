using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSimulation
{
    public class Square
    {
        private List<IAnimal> animals = new List<IAnimal>();

        public int FoodAmount { get; private set; }

        public int Eat(int amount)
        {
            if (FoodAmount > amount)
            {
                FoodAmount -= amount;
            }
            else
            {
                amount = FoodAmount;
                FoodAmount = 0;
            }

            return amount;
        }

        public void Arrive(IAnimal a)
        {
            animals.Add(a);
        }

        public void Depart(IAnimal a)
        {
            animals.Remove(a);
        }

        public bool FoodAvailable()
        {
            if (FoodAmount > 0)
            {
                return true;
            }

            return false;
        }
    }
}
