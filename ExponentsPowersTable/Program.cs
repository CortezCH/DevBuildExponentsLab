using System;
using System.Collections.Generic;

namespace ExponentsPowersTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialisze variables for userInteger (holds user input),
            //maxInputAllowed (max cube that an int can hold),
            //int array to hold the number range,
            //int array to hold the square's array,
            //int array to hold the cubed array,
            int userinteger;
            int maxInputAllowed = Convert.ToInt32( Math.Floor( Math.Cbrt(Int32.MaxValue) ) );

            // Ask the user for an integer
            Console.Write("Please enter an integer: ");
            // Parse their answer into userInteger
            int.TryParse(Console.ReadLine(), out userinteger);



            //Iitialize conatiners to hold the number range, the squares, and the cubes
            List<int> numberRange = new List<int>(userinteger);
            List<int> numberSquared = new List<int>(userinteger);
            List<int> numberCubed = new List<int>(userinteger);

            //Iterate through the containers to set the squares and cubes
            for (int i = 0; i < userinteger; i++)
            {
                numberRange.Add(i+1);
                numberSquared.Add(numberRange[i] * numberRange[i]);
                numberCubed.Add(numberRange[i] * numberRange[i] * numberRange[i]);
            }

            //Display full table of inputs
            Console.WriteLine("Number        Squared       Cubed");
            Console.WriteLine("=======       =======       ======");

            for (int j = 0; j < userinteger; j++)
            {
                Console.Write( numberRange[j] );
                Console.Write("       ");
                Console.Write( numberSquared[j] );
                Console.Write("       ");
                Console.Write( numberCubed[j] );
                Console.WriteLine();
            }

            //Validate that the entered number isn't 0 or negative,
            //and keep prompting for new number
            //
            //
            //
            //

            

        }
    }
}
