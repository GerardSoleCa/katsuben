using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katsuben;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Xunit;

namespace TestKastuben
{
    public class OutputSubtitleTests
    {

        [Theory]
        [InlineData("SubRip", typeof(SubRip), "utf-8")]
        [InlineData("SubRip:utf-8", typeof(SubRip), "utf-8")]
        public void OutputSubtitle_FromArguments(string argument, Type type, string encoding)
        {
            var outputSubtitle = OutputSubtitle.FromArgument(argument);
            Assert.IsType(type, outputSubtitle.SubtitleFormat);
            Assert.Equal(Encoding.GetEncoding(encoding), outputSubtitle.Encoding);
        }
    }
}
