using System;
using Katsuben;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Xunit;

namespace TestKatsuben
{
    public class SubtitleFormatFinderTests
    {
        [Theory]
        [InlineData(typeof(SubRip), "SubRip")]
        [InlineData(typeof(AdvancedSubStationAlpha), "Advanced Sub Station Alpha")]
        [InlineData(typeof(AdvancedSubStationAlpha), "AdvancedSubStationAlpha")]
        [InlineData(typeof(WebVTT), "WebVTT")]
        [InlineData(typeof(WebVTT), "Web VTT")]
        [InlineData(typeof(WebVTT), "web vTT")]
        [InlineData(typeof(TimedText10), "Timed Text 1.0")]
        [InlineData(typeof(TimedText10), "TimedText1.0")]
        public void SubtitleFormatFinder_FromName_WhenExistingSubtitleName(Type type, string subtitleName)
        {
            Assert.IsType(type, SubtitleFormatFinder.FromName(subtitleName));
        }

        [Theory]
        [InlineData("unknown")]
        [InlineData("invalid")]
        public void SubtitleFormatFinder_FromName_WhenInvalidSubtitleName(string subtitleName)
        {
            var exception = Assert.Throws<NotImplementedException>(() => SubtitleFormatFinder.FromName(subtitleName));
            Assert.Equal($"Requested target format ({subtitleName}) is not implemented", exception.Message);
        }
    }
}
