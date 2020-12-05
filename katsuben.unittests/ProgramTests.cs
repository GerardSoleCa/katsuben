using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Katsuben.UnitTests
{
    public class ProgramTests
    {
        [Fact]
        public async Task Program_MainWhenArgsAreParseable()
        {
            var args = new[]
            {
                "-i", Path.GetRelativePath(AppContext.BaseDirectory,
                    Path.Join(AppContext.BaseDirectory, "assets", "srt", "in.srt")),
                "-o", "vtt"
            };
            Assert.Equal(0, await Program.Main(args));
        }

        [Fact]
        public async Task Program_MainWhenArgsAreNotParseable()
        {
            Assert.Equal(1, await Program.Main(new[] { "unparseable" }));
        }

        [Fact]
        public async Task Program_WhenError()
        {
            var args = new[]
            {
                "-i", Path.GetRelativePath(AppContext.BaseDirectory,
                    Path.Join(AppContext.BaseDirectory, "assets", "abc", "in.abc")),
                "-o", "vtt"
            };
            Assert.Equal(1, await Program.Main(args));
        }
    }
}
