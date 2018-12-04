using Mastermind;
using Xunit;

namespace MastermindTests {
    public class Tests {
        [Theory]
        [InlineData(new[] {Colours.Green, Colours.Green, Colours.Green, Colours.Green}, true)]
        [InlineData(new[] {Colours.Green, Colours.Green, Colours.Green}, false)]
        public void GivenGuessShouldReturnHasValidNumberOfColours(Colours[] guess, bool expected) {
            var actual = Game.HasValidNumberOfColours(guess);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange},
                    new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange}, 4)]
        
        [InlineData(new[] {Colours.Purple, Colours.Blue, Colours.Green, Colours.Orange},
                    new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange}, 3)]
        
        [InlineData(new[] {Colours.Purple, Colours.Purple, Colours.Purple, Colours.Purple},
                    new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange}, 0)]
        public void GivenGuessShouldReturnNumberOfBlacks(Colours[] secret, Colours[] guess, int expected) {
            var game = new Game(secret);
            var actual = game.GetNumberOfBlacks(guess);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange},
                    new[] {Colours.Blue, Colours.Green, Colours.Orange, Colours.Red}, 4)]
        
        [InlineData(new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange},
                    new[] {Colours.Purple, Colours.Red, Colours.Purple, Colours.Purple}, 1)]
        
        [InlineData(new[] {Colours.Red, Colours.Red, Colours.Green, Colours.Orange},
                    new[] {Colours.Purple, Colours.Red, Colours.Green, Colours.Orange}, 0)]
        
        [InlineData(new[] {Colours.Purple, Colours.Red, Colours.Green, Colours.Orange},
                    new[] {Colours.Red, Colours.Red, Colours.Green, Colours.Orange}, 0)]
        
        [InlineData(new[] {Colours.Red, Colours.Red, Colours.Red, Colours.Red},
                    new[] {Colours.Red, Colours.Red, Colours.Blue, Colours.Blue}, 0)]
        
        [InlineData(new[] {Colours.Red, Colours.Red, Colours.Red, Colours.Red},
                    new[] {Colours.Red, Colours.Blue, Colours.Blue, Colours.Blue}, 0)]
        
        [InlineData(new[] {Colours.Red, Colours.Red, Colours.Red, Colours.Red},
                    new[] {Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue}, 0)]
        
        [InlineData(new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange},
                    new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange}, 0)]
        
        [InlineData(new[] {Colours.Red, Colours.Blue, Colours.Green, Colours.Orange},
                    new[] {Colours.Red, Colours.Red, Colours.Purple, Colours.Purple}, 1)]
        public void GivenGuessShouldReturnNumberOfWhites(Colours[] secret, Colours[] guess, int expected) {
            var game = new Game(secret);
            var actual = game.GetNumberOfWhites(guess);
            Assert.Equal(expected, actual);
        }
    }
}