using System;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Xunit;

namespace Katsuben.UnitTests
{
    public class SubtitleFormatFinderTests
    {
        [Theory]
        [InlineData("WebVTT", typeof(WebVTT))]
        [InlineData("vtt", typeof(WebVTT))]
        [InlineData("SubRip", typeof(SubRip))]
        [InlineData("srt", typeof(SubRip))]
        [InlineData("TimedText1.0", typeof(TimedText10))]
        public void SubtitleFormatFinder_FromName(string format, Type expected)
        {
            Assert.IsType(expected, SubtitleFormatFinder.FromName(format));
        }
    }
}
