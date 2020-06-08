using Katsuben;
using Xunit;

namespace TestKastuben
{
    public class ProgramTests
    {

        [Theory]
        [InlineData("-i o")]
        public void Katsuben_FromArguments(string argument)
        {
            Program.Main(argument.Split(' '));
        }
    }
}
