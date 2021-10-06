using System;
using System.Collections.Generic;

namespace ExponentsPowersTable
{
    class Program
    {
        /*---------------------------------------------LAB SUMMARY----------------------------------------------------------
        * Prompt: Tell us what kind of loop you used and describe how your solution would have changed if you had used a different type of loop.
        * 
        * Answer: For my lab I decided to use a for loop for it's ease of use of dealing with containers. If I had used a different type of loop
        *         I would have had to implement a counter variable to keep track of how many times the loop has run so I know what index I would
        *         be on. This variablr would also be what I used to make sure the loop ended eventually.
        *         
        *
        *
        *
        */

        static void Main(string[] args)
        {
            //Initialisze variables for userInteger (holds user input),
            //maxInputAllowed (max cube that an int can hold),
            int userinteger;
            int maxInputAllowed = Convert.ToInt32( Math.Floor( Math.Cbrt(Int32.MaxValue) ) );

            //Create a while loop to control whether to keep asking them for numbers
            bool keepGoing = true;

            while (keepGoing)
            {

                // Ask the user for an integer
                // Parse their answer into userInteger
                // Validate their input is valid 
                int.TryParse(ValidateUserInput(GetUserInput("Please enter an integer between 1 and 1290: "),
                    "Please enter an integer between 1 and 1290: ", maxInputAllowed), out userinteger);

                //Iitialize conatiners to hold the number range, the squares, and the cubes
                List<int> numberRange = new List<int>(userinteger);
                List<int> numberSquared = new List<int>(userinteger);
                List<int> numberCubed = new List<int>(userinteger);

                //Iterate through the containers to set the squares and cubes
                SetRange(ref numberRange);
                CalculateSquares(ref numberSquared);
                CalculateCubes(ref numberCubed);

                //Display full table of inputs
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Number", "Squared", "Cubed");
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", "=======", "=======", "======");
                DisplayTable(numberRange, numberSquared, numberCubed);

                keepGoing = Continue();

            }


        }

        public static string ValidateUserInput(string input, string prompt, int maxValue)
        {
            // Make sure the users input meets these criterium
            //      Is a number
            //      Is not less than or equal to 0
            //      Is not larger than the largest allowed int value
            if (!int.TryParse(input, out int number)
                || number <= 0
                || number > maxValue)
            {//If it fails any of the tests we want the user to try again and then revalidate their new input
                Console.WriteLine("That was an invalid input.");
                return ValidateUserInput(GetUserInput(prompt), prompt, maxValue);
            }

            return input;
        }

        public static string GetUserInput(string prompt)
        {
            //Display a prompt to the user and take in their answer to the prompt
            Console.Write(prompt);
            string output = Console.ReadLine().Trim().ToLower();

            return output;
        }

        public static void SetRange(ref List<int> numRange)
        {
            //Iterate through the Range and just set each index to the number it matches
            for (int i = 0; i < numRange.Capacity; i++)
            {
                numRange.Add(i + 1);
            }
        }

        public static void CalculateSquares(ref List<int> squares)
        {
            //Iterate through each index and square that index value
            for (int i = 1; i <= squares.Capacity; i++)
            {
                squares.Add(i * i);
            }
        }

        public static void CalculateCubes(ref List<int> cubes)
        {
            //Iterate through each index and assign the cube to each 
            for (int i = 1; i <= cubes.Capacity; i++)
            {
                cubes.Add(i * i * i);
            }
        }

        public static void DisplayTable(List<int> numberRange, 
            List<int> numberSquared, List<int> numberCubed)
        {
            //Iterate from 1 until the value the user entered and display the number, square of that number, and cube of that number.
            for (int j = 0; j < numberRange.Capacity; j++)
            {
                Console.WriteLine("{0,-20:n0}{1,-20:n0}{2,-20:n0}", numberRange[j], numberSquared[j], numberCubed[j]);
            }
        }

        public static bool Continue()
    {
        string answer = GetUserInput("Continue? (y/n): ");

        if (answer.ToLower() == "y")
        {
            return true;
        }
        else if (answer.ToLower() == "n")
        {
            Console.WriteLine("Goodbye!");
            return false;
        }
        else
        {
            Console.WriteLine("Please enter either Y or N to continue.");
            return Continue();
        }
    }
    }
}