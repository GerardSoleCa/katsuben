using System;
using System.Text;
using Nikse.SubtitleEdit.Core.Common;

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
            var subtitle = new Subtitle();
            if (subtitle.LoadSubtitle(filename, out _, null, true) == null)
            {
                throw new Exception($"{filename} subtitle is not supported");
            }

            return subtitle;
        }
    }
}
