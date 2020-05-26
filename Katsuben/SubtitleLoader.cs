using System;
using System.Collections.Generic;
using Nikse.SubtitleEdit.Core;

namespace Katsuben
{
    public class SubtitleLoader
    {
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
