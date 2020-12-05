using System;
using System.IO;
using Nikse.SubtitleEdit.Core;

namespace Katsuben
{
    public class SubtitleConverter
    {
        private readonly Subtitle _sourceSubtitle;

        public SubtitleConverter(Subtitle subtitle)
        {
            _sourceSubtitle = subtitle;
        }

        public void Convert(OutputSubtitle output)
        {
            using var file = new StreamWriter(OutputFile(output.SubtitleFormat.Extension), false, output.Encoding);
            file.Write(_sourceSubtitle.ToText(output.SubtitleFormat));
            file.Flush();

            Console.WriteLine($"Subtitle converted to {output.SubtitleFormat.Name}");
        }

        private string OutputFile(string extension)
        {
            return Path.Join(
                Path.GetDirectoryName(_sourceSubtitle.FileName),
                $"{Path.GetFileNameWithoutExtension(_sourceSubtitle.FileName)}{extension.ToLower()}");
        }
    }
}
