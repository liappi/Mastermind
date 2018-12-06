using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind {
    public class InputValidator {
        public bool HasValidNumberOfColours(IEnumerable<string> guess) {
            return guess.Count() == 4;
        }

        public bool HasValidColours(IEnumerable<string> guess) {
            foreach (var colour in guess) {
                if (!IsValidColour(colour)) {
                    return false;
                }
            }

            return true;
        }
        
        public bool IsValidColour(string colour) {
            return Enum.IsDefined(typeof(Colours), colour);
        }
    }
}