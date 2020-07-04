using Katsuben;
using Moq;
using Nikse.SubtitleEdit.Core;
using Pose;
using Xunit;

namespace TestKatsuben
{
    public class ProgramTests
    {

        [Theory]
        [InlineData("-i a -o b")]
        public void Katsuben_FromArguments(string argument)
        {
            var mock = new Mock<SubtitleConverter>();
            Shim ctorShim = Shim.Replace(() => new SubtitleConverter(Is.A<Subtitle>())).With(() => mock.Object);

            PoseContext.Isolate(() => { 
                var mock = new Mock<SubtitleConverter>();
                Assert.Equal(0, Program.Main(argument.Split(' ')));
            }, ctorShim);
        }
    }
}
