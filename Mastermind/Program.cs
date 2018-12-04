using System;

namespace Mastermind {
    class Program {
        static void Main(string[] args) {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            var game = new Game(secret);
            game.Play();
        }
    }
}