using System;
using System.Text;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Xunit;

namespace Katsuben.UnitTests
{
    public class OutputSubtitleTests
    {
        [Theory]
        [InlineData("vtt", "utf-8", typeof(WebVTT))]
        [InlineData("WebVTT", "utf-8", typeof(WebVTT))]
        [InlineData("srt", "utf-8", typeof(SubRip))]
        [InlineData("SubRip", "utf-8", typeof(SubRip))]
        [InlineData("EBU", "utf-8", typeof(Ebu))]
        [InlineData("stl", "utf-8", typeof(DvdStudioPro))]
        public void OutputSubtitle_SubtitleFormat(string format, string encoding, Type expectedFormat)
        {
            var output = new OutputSubtitle(format, encoding);
            Assert.IsType(expectedFormat, output.SubtitleFormat);
        }

        [Theory]
        [InlineData("WebVTT", "utf-8", typeof(UTF8Encoding))]
        [InlineData("WebVTT", "utf-16", typeof(UnicodeEncoding))]
        [InlineData("WebVTT", "utf-32", typeof(UTF32Encoding))]
        [InlineData("WebVTT", "ascii", typeof(ASCIIEncoding))]
        public void OutputSubtitle_Encoding(string format, string encoding, Type expectedEncoding)
        {
            var output = new OutputSubtitle(format, encoding);
            Assert.IsAssignableFrom(expectedEncoding, output.Encoding);
        }
    }
}
