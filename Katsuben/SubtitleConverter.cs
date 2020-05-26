using System;
using System.IO;
using Nikse.SubtitleEdit.Core;

namespace Katsuben
{
    public class SubtitleConverter
    {
        private Subtitle SourceSubtitle { get; set; }

        public SubtitleConverter(Subtitle subtitle)
        {
            SourceSubtitle = subtitle;
        }

        public void Convert(OutputSubtitle output)
        {
            using (var file = new StreamWriter(OutputFile(output.SubtitleFormat.Extension), false, output.Encoding))
            {
                file.Write(SourceSubtitle.ToText(output.SubtitleFormat));
            }
            Console.WriteLine($"Subtitle converted to {output.SubtitleFormat.Name}");
        }

        private string OutputFile(string extension)
        {
            return Path.Join(
                Path.GetDirectoryName(SourceSubtitle.FileName),
                $"{Path.GetFileNameWithoutExtension(SourceSubtitle.FileName)}{extension}");
        }
    }
}
