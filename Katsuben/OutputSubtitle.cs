using System.Linq;
using System.Text;
using Nikse.SubtitleEdit.Core.SubtitleFormats;

namespace Katsuben
{
    public class OutputSubtitle
    {
        public SubtitleFormat SubtitleFormat { get; internal set; }
        public Encoding Encoding { get; internal set; }

        public OutputSubtitle(string extension, string encoding = "utf-8")
        {
            SubtitleFormat = SubtitleFormatFinder.FromName(extension);
            Encoding = Encoding.GetEncoding(encoding);
        }

        public static OutputSubtitle FromArgument(string output)
        {
            var splitted = output.Split(":");
            return new OutputSubtitle(splitted[0], splitted.ElementAtOrDefault(1) ?? "utf-8");
        }
    }
}
