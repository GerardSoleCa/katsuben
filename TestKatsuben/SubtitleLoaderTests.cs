using System;
using System.Collections.Generic;
using System.IO;
using Katsuben;
using Nikse.SubtitleEdit.Core;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Xunit;

namespace TestKatsuben
{
    public class SubtitleLoaderTests
    {
        [Theory]
        [MemberData(nameof(FilesToLoad))]
        public void SubtitleLoader_FromFileWhenExists(Type type, string filePath)
        {
            Assert.IsType<Subtitle>(SubtitleLoader.FromFile(filePath));
            Assert.IsType(type, SubtitleLoader.FromFile(filePath).OriginalFormat);
        }

        public static IEnumerable<object[]> FilesToLoad =>
            new List<object[]>
            {
                new object[]
                {
                    typeof(WebVTT),
                    Path.GetRelativePath(AppContext.BaseDirectory,
                        Path.Join(AppContext.BaseDirectory, "assets", "sample.vtt"))
                },
                new object[] {typeof(WebVTT), Path.Join(AppContext.BaseDirectory, "assets", "sample.vtt")},
            };

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