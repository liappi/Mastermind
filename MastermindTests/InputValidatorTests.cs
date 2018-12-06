using Mastermind;
using Xunit;

namespace MastermindTests {
    public class InputValidatorTests {
        [Theory]
        [InlineData(new[] {"GREEN", "GREEN", "GREEN", "GREEN"}, true)]
        [InlineData(new[] {"GREEN", "GREEN", "GREEN"}, false)]
        public void GivenGuessShouldReturnHasValidNumberOfColours(string[] guess, bool expected) {
            var inputValidator = new InputValidator();
            var actual = inputValidator.HasValidNumberOfColours(guess);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {"RED", "BLUE", "GREEN", "GREEN"}, true)]
        [InlineData(new[] {"PINK", "BLUE", "GREEN", "GREEN"}, false)]
        [InlineData(new[] {"RED", "something", "GREEN", "GREEN"}, false)]
        [InlineData(new[] {"red", "BLUE", "GREEN", "GREEN"}, false)]
        public void GivenGuessShouldReturnHasValidColours(string[] guess, bool expected) {
            var inputValidator = new InputValidator();
            var actual = inputValidator.HasValidColours(guess);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("PURPLE", true)]
        [InlineData("BLUE", true)]
        [InlineData("RED", true)]
        [InlineData("GREEN", true)]
        [InlineData("green", false)]
        [InlineData("pink", false)]
        [InlineData("something", false)]
        [InlineData("SOMETHING", false)]
        public void GivenColourShouldReturnIfValidColour(string input, bool expected) {
            var inputValidator = new InputValidator();
            var actual = inputValidator.IsValidColour(input);
            Assert.Equal(expected, actual);
        }
    }
}