using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class InputProcessor {
        public IEnumerable<Colours> ProcessInput(IEnumerable<string> userInput) {
            var guess = new List<Colours>();
            
            foreach (var input in userInput) {
                Enum.TryParse(input, out Colours colour);
                guess.Add(colour);
            }

            return guess;
        }
    }
}