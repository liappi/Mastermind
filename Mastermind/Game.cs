using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class Game {
        private IEnumerable<Colours> secret;
        private bool gameOver;

        public Game(IEnumerable<Colours> secret) {
            this.secret = secret;
            gameOver = false;
        }
        

        public int GetNumberOfBlacks(IEnumerable<Colours> guess) {
            var numberOfBlacks = 0;

            for (var i = 0; i < guess.Count(); i++) {
                if (guess.ElementAt(i) == secret.ElementAt(i)) {
                    numberOfBlacks++;
                }
            }
            
            return numberOfBlacks;
        }

        public IEnumerable<int> GetIndexesOfBlacks(IEnumerable<Colours> guess) {
            var indexesOfBlacks = new List<int>();
            
            for (var i = 0; i < guess.Count(); i++) {
                if (guess.ElementAt(i) == secret.ElementAt(i)) {
                    indexesOfBlacks.Add(i);
                }
            }

            return indexesOfBlacks;
        }

        public int GetNumberOfWhites(IEnumerable<Colours> guess) {
            var numberOfWhites = 0;
            var indexesOfBlacks = GetIndexesOfBlacks(guess);

            for (var i = 0; i < guess.Count(); i++) {
                for (var j = 0; j < secret.Count(); j++) {
                    if (!indexesOfBlacks.Contains(i) && !indexesOfBlacks.Contains(j) && guess.ElementAt(i) == secret.ElementAt(j)) {
                        numberOfWhites++;
                    }
                }
            }

            return numberOfWhites;
        }

        public void Play() {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Here's an example guess: RED,GREEN,BLUE,YELLOW");

            while (!gameOver) {
                var guess = ElicitValidInput();
                var numberOfBlacks = GetNumberOfBlacks(guess);
                var numberOfWhites = GetNumberOfWhites(guess);
                Console.WriteLine("The number of Blacks is: " + numberOfBlacks);
                Console.WriteLine("The number of Whites is: " + numberOfWhites);

                if (numberOfBlacks == 4) {
                    gameOver = true;
                }
            }

            Console.WriteLine("WON!");
        }

        private IEnumerable<Colours> ElicitValidInput() {
            var inputValidator = new InputValidator();
            var inputProcessor = new InputProcessor();
            
            Console.WriteLine("Please enter your guess.");
            var input = Console.ReadLine().Split(',');

            while (!inputValidator.HasValidNumberOfColours(input) || !inputValidator.HasValidColours(input)) {
                Console.WriteLine("Please enter another guess.");
                input = Console.ReadLine().Split(',');
            }

            return inputProcessor.ProcessInput(input);
        }
    }
}