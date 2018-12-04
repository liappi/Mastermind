using System;
using System.Collections.Generic;

namespace Mastermind {
    public class SecretGenerator {
        public IEnumerable<Colours> GenerateSecret() {
            var secret = new List<Colours>();
            var secretLength = 4;
            
            var values = Enum.GetValues(typeof(Colours));
            var random = new Random();

            for (var i = 0; i < secretLength; i++) {
                var colour = (Colours) values.GetValue(random.Next(values.Length));
                secret.Add(colour);
            }

            return secret;
        }
    }
}