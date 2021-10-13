using System;
using System.IO;
using System.Text;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.ContainerFormats.MaterialExchangeFormat;
using Nikse.SubtitleEdit.Core.SubtitleFormats;

namespace Katsuben
{
    public static class SubtitleLoader
    {
        static SubtitleLoader()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static Subtitle FromFile(string filename)
        {
            if (Path.GetExtension(filename) == ".mxf")
                return ParseMxf(filename);

            return Subtitle.Parse(filename) ?? throw new Exception($"{filename} subtitle is not supported");
        }

        private static Subtitle ParseMxf(string filename)
        {
            var subtitle = new Subtitle { FileName = filename };
            subtitle.ReloadLoadSubtitle(new MxfParser(filename).GetSubtitles(), filename, new TimedText10());
            return subtitle;
        }
    }
}
