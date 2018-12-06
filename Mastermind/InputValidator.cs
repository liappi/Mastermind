using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class InputValidator {
        public bool HasValidNumberOfColours(IEnumerable<Colours> guess) {
            return guess.Count() == 4;
        }

        public bool IsValidColour(string input) {
            return Enum.IsDefined(typeof(Colours), input);
        }
        
    }
}