using System.Text;
using Nikse.SubtitleEdit.Core.SubtitleFormats;

namespace Katsuben
{
    public class OutputSubtitle
    {
        public SubtitleFormat SubtitleFormat { get; }
        public Encoding Encoding { get; }

        public OutputSubtitle(string format, string encoding)
        {
            SubtitleFormat = SubtitleFormatFinder.FromName(format);
            Encoding = Encoding.GetEncoding(encoding);
        }
    }
}
