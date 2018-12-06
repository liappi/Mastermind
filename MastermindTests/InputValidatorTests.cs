using Mastermind;
using Xunit;

namespace MastermindTests {
    public class InputValidatorTests {
        [Theory]
        [InlineData(new[] {Colours.GREEN, Colours.GREEN, Colours.GREEN, Colours.GREEN}, true)]
        [InlineData(new[] {Colours.GREEN, Colours.GREEN, Colours.GREEN}, false)]
        public void GivenGuessShouldReturnHasValidNumberOfColours(Colours[] guess, bool expected) {
            var inputValidator = new InputValidator();
            var actual = inputValidator.HasValidNumberOfColours(guess);
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