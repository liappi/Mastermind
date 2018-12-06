using System;

namespace Mastermind {
    public class Renderer {
        public void PrintWelcomeMessage() {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Here's an example guess: RED,GREEN,BLUE,YELLOW");
        }

        public void PrintNumberOfBlacksAndWhites(int numberOfBlacks, int numberOfWhites) {
            Console.WriteLine("The number of Blacks is: " + numberOfBlacks);
            Console.WriteLine("The number of Whites is: " + numberOfWhites);
        }

        public string GetInput() {
            return Console.ReadLine();
        }

        public void PrintHasInvalidNumberOfColoursInGuessMessage() {
            Console.WriteLine("Error: You must enter four colours!");
        }

        public void PrintHasInvalidColourInGuessMessage() {
            Console.WriteLine("Error: You have given an invalid colour!");
        }

        public void PrintEnterAnotherGuessMessage() {
            Console.WriteLine("Please enter another guess.");
        }

        public void PrintEnterFirstGuessMessage() {
            Console.WriteLine("Please enter your guess.");
        }
        
        public void PrintWinMessage() {
            Console.WriteLine("WON!");
        }

        public void PrintLossDueToTooManyGuessesMessage() {
            Console.WriteLine("Sorry, you've made too many guesses. Better luck next time!");
        }
    }
}