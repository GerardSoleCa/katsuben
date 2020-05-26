using System.IO;
using Katsuben;
using Nikse.SubtitleEdit.Core;
using TestKastuben.Utils;
using Xunit;

namespace TestKastuben
{
    public class SubtitleConverterTests
    {

        [Theory]
        [InlineData("assets/vtt/source.vtt", "SubRip")]
        public void SubtitleConverter_WhenConvert(string source, string outputFormat, string encoding = "utf-8")
        {
            var subtitle = SubtitleLoader.FromFile(FileUtil.CreateTempFileForResource(source));
            var output = new OutputSubtitle(outputFormat, encoding);

            new SubtitleConverter(subtitle).Convert(output);

            FileAssert.Equal(ExpectedFilePath(source, output), ConvertedFilePath(subtitle, output));
        }

        public string ExpectedFilePath(string source, OutputSubtitle output)
        {
            return FileUtil.ResourcePath(Path.Join(Path.GetDirectoryName(source), $"result{output.SubtitleFormat.Extension}"));
        }

        private string ConvertedFilePath(Subtitle subtitle, OutputSubtitle output)
        {
            return subtitle.FileName.Replace(subtitle.OriginalFormat.Extension, output.SubtitleFormat.Extension);
        }
    }
}
