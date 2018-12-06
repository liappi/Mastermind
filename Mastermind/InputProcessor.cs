using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class InputProcessor {
        public IEnumerable<Colours> ProcessInput(string userInput) {
            var inputs = userInput.Split(',').ToList();
            var guess = new List<Colours>();
            
            foreach (var input in inputs) {
                Enum.TryParse(input, out Colours colour);
                guess.Add(colour);
            }

            return guess;
        }
    }
}