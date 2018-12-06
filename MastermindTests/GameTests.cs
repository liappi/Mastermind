using System.Collections.Generic;
using System.Linq;
using Mastermind;
using Xunit;

namespace MastermindTests {
    public class GameTests {
        [Theory]
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE}, 4)]
        
        [InlineData(new[] {Colours.PURPLE, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE}, 3)]
        
        [InlineData(new[] {Colours.PURPLE, Colours.PURPLE, Colours.PURPLE, Colours.PURPLE},
                    new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE}, 0)]
        public void GivenGuessShouldReturnNumberOfBlacks(Colours[] secret, Colours[] guess, int expected) {
            var game = new Game(secret);
            var actual = game.GetNumberOfBlacks(guess);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.BLUE, Colours.GREEN, Colours.ORANGE, Colours.RED}, 4)]
        
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.PURPLE, Colours.RED, Colours.PURPLE, Colours.PURPLE}, 1)]
        
        [InlineData(new[] {Colours.RED, Colours.RED, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.PURPLE, Colours.RED, Colours.GREEN, Colours.ORANGE}, 0)]
        
        [InlineData(new[] {Colours.PURPLE, Colours.RED, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.RED, Colours.GREEN, Colours.ORANGE}, 0)]
        
        [InlineData(new[] {Colours.RED, Colours.RED, Colours.RED, Colours.RED},
                    new[] {Colours.RED, Colours.RED, Colours.BLUE, Colours.BLUE}, 0)]
        
        [InlineData(new[] {Colours.RED, Colours.RED, Colours.RED, Colours.RED},
                    new[] {Colours.RED, Colours.BLUE, Colours.BLUE, Colours.BLUE}, 0)]
        
        [InlineData(new[] {Colours.RED, Colours.RED, Colours.RED, Colours.RED},
                    new[] {Colours.BLUE, Colours.BLUE, Colours.BLUE, Colours.BLUE}, 0)]
        
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE}, 0)]
        
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.RED, Colours.PURPLE, Colours.PURPLE}, 0)]
        public void GivenGuessShouldReturnNumberOfWhites(Colours[] secret, Colours[] guess, int expected) {
            var game = new Game(secret);
            var actual = game.GetNumberOfWhites(guess);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.RED, Colours.PURPLE, Colours.PURPLE}, 
                    new[] {0})]
        [InlineData(new[] {Colours.RED, Colours.BLUE, Colours.GREEN, Colours.ORANGE},
                    new[] {Colours.RED, Colours.BLUE, Colours.PURPLE, Colours.PURPLE}, 
                    new[] {0, 1})]
        public void GivenGuessShouldReturnIndexesOfBlacks(Colours[] secret, Colours[] guess, IEnumerable<int> expected) {
            var game = new Game(secret);
            var actual = game.GetIndexesOfBlacks(guess);
            Assert.Equal(expected, actual);
        }
    }
}