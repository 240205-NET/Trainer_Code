using System;

namespace GuessingGame
{
    public class GG
    {
        public static void Main(string[] args)
        {
            // Greet the player
            Console.WriteLine("Welcome to the Guessing Game!");

            // randomly generated number (for the player to try to guess)
            //var rand = new Random();
            Random rand = new Random();
            // uint (unsigned int) 0 - 2 Bill
            // int (signed int ) -1 Bill - 1 Bill
            int target = rand.Next(21); // generate an integer value between 0 and 20

            // remove for production!
            Console.WriteLine(target);

            // something to remember if the player has won
            // boolean value to represent the yes or no
            bool win = false;

            // create the variable i, which we'll use to track how many attemps the player has made
            int i = 0;

            // loop to keep guessing until the player guesses the correct number
            while( !win ) // C# comparison operators: ==, > , <, >=, <=, !=
            {
                // accept players guess
                Console.WriteLine("Please guess a number between 0 and 20: ");
                // accept user input as a sting, convert it, and store it in a numerical variable
                
                // declare and set a default guess value
                // int guess = -1;
                // handle the possibility of bad input
                try
                {
                    int guess = Int32.Parse(Console.ReadLine());

                        // check if the guess value is still the default, or if the players guess was valid
                    if ( guess >= 0 && guess <= 20 ) // C# Logical Operators: &&, || (AND , OR)
                    {
                        // check if the player has guessed the correct number
                        if ( guess == target )
                        {
                            Console.WriteLine("ayoo! Yay! Congratulations, you got it right!");
                            win = true;
                        }
                        // if too high
                        else if ( guess > target )
                        {
                            Console.WriteLine("Whoops, too high!");
                        }
                        // if too low
                        else
                        {
                            Console.WriteLine("Nope, too low!");
                        }

                        i++;
                        Console.WriteLine("Attempt #: " + i);
                    }
                    else
                    {
                        Console.WriteLine("Your guess was out of range, please try again.");
                    }
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( ex.Message );
                    Console.WriteLine("The value you entered was not valid, please try again.");
                }
            }

            Console.WriteLine("Congratulations, you've won! It took you " + i + " attempts!");

            // promt to play again
                // if no, exit the progam
                // if yes, play again
        }
    }
}