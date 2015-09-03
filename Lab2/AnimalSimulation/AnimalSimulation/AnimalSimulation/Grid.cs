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
    };

    /// <summary>
    /// Grid interface.
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// Checks if the animal can move in the requested direction.
        /// </summary>
        bool CanMove(IAnimal animal, Direction dir);

        /// <summary>
        /// Get the square the animal is currently standing on.
        /// </summary>
        Square GetSquare(IAnimal animal);
    }

    public class Grid : IGrid
    {
        private Square[,] squares;
        private int lengthX, lengthY;

        public Grid(int x, int y)
        {
            if (x < 1 || y < 1)
            {
                x = 10;
                y = 10;
            }

            squares = new Square[x, y];
        }

        /// <summary>
        /// Checks if the animal can move in the requested direction.
        /// </summary>
        public bool CanMove(IAnimal animal, Direction dir)
        {
            int posX = animal.GetPosition()[0];
            int posY = animal.GetPosition()[1];

            switch (dir) {
                case Direction.UP:
                    if (posY > 0)
                        return true;
                    break;
                case Direction.DOWN:
                    if (posY < lengthX)
                        return true;
                    break;
                case Direction.LEFT:
                    if (posX > 0)
                        return true;
                    break;
                case Direction.RIGHT:
                    if (posX < lengthX)
                        return true;
                    break;
            }

            return false;
        }

        /// <summary>
        /// Get the square the animal is currently standing on.
        /// </summary>
        public Square GetSquare(IAnimal animal)
        {
            int[] position = animal.GetPosition();
            int posX = position[0];
            int posY = position[1];

            return squares[posX, posY];
        }
    }

    /// <summary>
    /// A square class for the grid that animals live on.
    /// </summary>
    public class Square
    {
        private List<IAnimal> animalsOnSquare;
        public int PlantMass { get; private set; }

        public Square()
        {
            animalsOnSquare = new List<IAnimal>();
        }

        /// <summary>
        /// Initializes the square with a n amount of plant for animals to eat. 
        /// </summary>
        /// <param name="plantMass">Amount of plant available on the square. If zero or below, an automatic value will be generated.</param>
        public Square(int plantMass = 0)
        {
            if (plantMass > 0)
            {
                PlantMass = plantMass;
            }
            else
            {
                Random rand = new Random();
                PlantMass = rand.Next(200, 2000);
            }
        }

        /// <summary>
        /// Request an amount of food to eat.
        /// Returns the actual amount the animal is allowed to eat.
        /// </summary>
        /// <param name="reqEatSize">The amount of food the animal wants to eat.</param>
        public int Eat(int reqEatSize)
        {
            if (PlantMass > reqEatSize)
            {
                PlantMass -= reqEatSize;
            }
            else
            {
                reqEatSize = PlantMass;
                PlantMass = 0;
            }

            return reqEatSize;
        }

        /// <summary>
        /// Indicates the arrival of a new animal.
        /// </summary>
        public void Enter(IAnimal animal)
        {
            animalsOnSquare.Add(animal);
        }

        /// <summary>
        /// Indicates the departure of an animal.
        /// </summary>
        public void Leave(IAnimal animal)
        {
            animalsOnSquare.Remove(animal);
        }
    }
}
