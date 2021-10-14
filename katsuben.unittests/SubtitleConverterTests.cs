using System;
using System.IO;
using Katsuben.UnitTests.Utils;
using Xunit;

namespace Katsuben.UnitTests
{
    public class SubtitleConverterTests
    {
        [Theory]
        [InlineData("stl", "vtt")]
        [InlineData("stl", "srt")]
        [InlineData("stl", "itt")]
        [InlineData("stl", "smi")]

        [InlineData("vtt", "srt")]
        [InlineData("vtt", "itt")]
        [InlineData("vtt", "smi")]

        [InlineData("srt", "vtt")]
        [InlineData("srt", "itt")]
        [InlineData("srt", "smi")]

        [InlineData("smi", "vtt")]
        [InlineData("smi", "itt")]
        [InlineData("smi", "srt")]

        [InlineData("mxf", "vtt")]
        [InlineData("mxf", "itt")]
        [InlineData("mxf", "srt")]
        public void SubtitleConverter(string inputExtension, string extension, string encoding = "utf-8")
        {
            var inputFilePath = Path.GetRelativePath(AppContext.BaseDirectory,
                Path.Join(AppContext.BaseDirectory, "assets", inputExtension, $"in.{inputExtension}"));

            new SubtitleConverter(SubtitleLoader.FromFile(inputFilePath))
                .Convert(new OutputSubtitle(extension, encoding));

            var outputFilePath = Path.GetRelativePath(AppContext.BaseDirectory,
                Path.Join(AppContext.BaseDirectory, "assets", inputExtension, $"in.{extension}"));
            var expectedFilePath = Path.GetRelativePath(AppContext.BaseDirectory,
                Path.Join(AppContext.BaseDirectory, "assets", inputExtension, $"reference.{extension}"));

            FileAssert.Equal(expectedFilePath, outputFilePath);
        }
    }
}
