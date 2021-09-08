using System;
using System.IO;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Xunit;

namespace Katsuben.UnitTests
{
    public class SubtitleLoaderTests
    {
        [Theory]
        [InlineData("srt", typeof(SubRip))]
        [InlineData("stl", typeof(Ebu))]
        [InlineData("vtt", typeof(WebVTT))]
        public void SubtitleLoader_FromFileWhenExists(string extension, Type expected)
        {
            var filePath = Path.GetRelativePath(AppContext.BaseDirectory,
                Path.Join(AppContext.BaseDirectory, "assets", extension, $"in.{extension}"));
            Assert.IsType<Subtitle>(SubtitleLoader.FromFile(filePath));
            Assert.IsType(expected, SubtitleLoader.FromFile(filePath).OriginalFormat);
        }

        [Theory]
        [InlineData("unknown")]
        [InlineData("missing")]
        public void SubtitleLoader_FromFileWhenMissingFile(string filePath)
        {
            var exception = Assert.Throws<Exception>(() => SubtitleLoader.FromFile(filePath));
            Assert.Equal($"{filePath} subtitle is not supported", exception.Message);
        }
    }
}
