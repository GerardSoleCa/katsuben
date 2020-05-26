using System;
using Nikse.SubtitleEdit.Core;
using Nikse.SubtitleEdit.Core.SubtitleFormats;

namespace Katsuben
{
    public class SubtitleFormatFinder
    {
        public static SubtitleFormat FromName(string targetFormat)
        {
            foreach (var subtitleFormat in SubtitleFormat.AllSubtitleFormats)
            {
                if (subtitleFormat.IsTextBased && subtitleFormat.Name.RemoveChar(' ').Equals(targetFormat.RemoveChar(' '), StringComparison.OrdinalIgnoreCase))
                {
                    return subtitleFormat;
                }
            }
            throw new NotImplementedException($"Requested target format ({targetFormat}) is not implemented");
        }
    }
}
