using System.Linq;
using Mastermind;
using Xunit;

namespace MastermindTests {
    public class SecretGeneratorTests {
        [Fact]
        public void SecretGeneratedShouldHaveLengthOfFour() {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            var expected = secret.Count();
            var actual = 4;
            Assert.Equal(expected, actual);
        }
    }
}