using System;
using System.Collections.Generic;

namespace Mastermind {
    public class InputProcessor {
        public IEnumerable<Colours> ProcessInput(IEnumerable<string> inputs) {
            var guess = new List<Colours>();
            
            foreach (var input in inputs) {
                Enum.TryParse(input, out Colours colour);
                guess.Add(colour);
            }

            return guess;
        }
    }
}