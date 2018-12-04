using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class Game {
        private IEnumerable<Colours> secret;

        public Game(IEnumerable<Colours> secret) {
            this.secret = secret;
        }
        
        public static bool HasValidNumberOfColours(IEnumerable<Colours> guess) {
            return guess.Count() == 4;
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
    }
}