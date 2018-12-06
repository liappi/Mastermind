using System.Collections.Generic;
using Mastermind;
using Xunit;

namespace MastermindTests {
    public class InputProcessorTests {
        [Theory]
        [InlineData(new[] {"RED", "GREEN", "BLUE", "ORANGE"},
            new[] {Colours.RED, Colours.GREEN, Colours.BLUE, Colours.ORANGE})]
        [InlineData(new[] {"RED", "RED", "RED", "RED"},
            new[] {Colours.RED, Colours.RED, Colours.RED, Colours.RED})]
        [InlineData(new[] {"RED", "GREEN", "BLUE", "YELLOW"},
            new[] {Colours.RED, Colours.GREEN, Colours.BLUE, Colours.YELLOW})]
        public void GivenUserInputShouldReturnFormattedGuess(IEnumerable<string> userInput, IEnumerable<Colours> expected) {
            var inputProcessor = new InputProcessor();
            var actual = inputProcessor.ProcessInput(userInput);
            Assert.Equal(expected, actual);
        }
    }
}