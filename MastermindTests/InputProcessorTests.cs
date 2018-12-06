using System.Collections.Generic;
using Mastermind;
using Xunit;

namespace MastermindTests {
    public class InputProcessorTests {
        [Theory]
        [InlineData("RED,GREEN,BLUE,ORANGE",
            new[] {Colours.RED, Colours.GREEN, Colours.BLUE, Colours.ORANGE})]
        [InlineData("RED,RED,RED,RED",
            new[] {Colours.RED, Colours.RED, Colours.RED, Colours.RED})]
        [InlineData("RED,GREEN,BLUE,YELLOW",
            new[] {Colours.RED, Colours.GREEN, Colours.BLUE, Colours.YELLOW})]
        public void GivenUserInputShouldReturnFormattedGuess(string userInput, IEnumerable<Colours> expected) {
            var inputProcessor = new InputProcessor();
            var actual = inputProcessor.ProcessInput(userInput);
            Assert.Equal(expected, actual);
        }
    }
}