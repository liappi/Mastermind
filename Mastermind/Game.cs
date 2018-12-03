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
    }
}