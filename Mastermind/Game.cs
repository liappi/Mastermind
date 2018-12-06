using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class Game {
        private IEnumerable<Colours> secret;
        private bool gameOver;
        private Renderer renderer;
        private InputProcessor inputProcessor;
        private InputValidator inputValidator;
        private int numberOfGuessesMade;

        public Game(IEnumerable<Colours> secret) {
            this.secret = secret;
            gameOver = false;
            renderer = new Renderer();
            inputProcessor = new InputProcessor();
            inputValidator = new InputValidator();
            numberOfGuessesMade = 0;
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
            renderer.PrintWelcomeMessage();

            while (!gameOver) {
                var guess = ElicitValidInput();
                var numberOfBlacks = GetNumberOfBlacks(guess);
                var numberOfWhites = GetNumberOfWhites(guess);
                renderer.PrintNumberOfBlacksAndWhites(numberOfBlacks, numberOfWhites);
                
                numberOfGuessesMade++;
                
                if (numberOfGuessesMade > 60) {
                    gameOver = true;
                    renderer.PrintLossDueToTooManyGuessesMessage();
                }

                if (numberOfBlacks == 4) {
                    gameOver = true;
                    renderer.PrintWinMessage();
                }
            }
        }

        private IEnumerable<Colours> ElicitValidInput() {
            renderer.PrintEnterFirstGuessMessage();
            var input = renderer.GetInput().Split(',');

            while (!inputValidator.HasValidNumberOfColours(input) || !inputValidator.HasValidColours(input)) {
                PrintApplicableErrorMessages(input);
                
                renderer.PrintEnterAnotherGuessMessage();
                input = renderer.GetInput().Split(',');
            }

            return inputProcessor.ProcessInput(input);
        }

        private void PrintApplicableErrorMessages(IEnumerable<string> input) {
            if (!inputValidator.HasValidNumberOfColours(input)) {
                renderer.PrintHasInvalidNumberOfColoursInGuessMessage();
            }

            if (!inputValidator.HasValidColours(input)) {
                renderer.PrintHasInvalidColourInGuessMessage();
            }
        }
    }
}