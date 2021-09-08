using System;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;

namespace Katsuben
{
    public static class SubtitleFormatFinder
    {
        public static SubtitleFormat FromName(string targetFormat)
        {
            foreach (var subtitleFormat in SubtitleFormat.AllSubtitleFormats)
            {
                if (subtitleFormat.Extension.Contains(targetFormat, StringComparison.OrdinalIgnoreCase))
                    return subtitleFormat;

                if (subtitleFormat.Name.RemoveChar(' ').Contains(targetFormat.RemoveChar(' '),
                    StringComparison.OrdinalIgnoreCase))
                    return subtitleFormat;
            }

            throw new NotImplementedException($"Requested target format ({targetFormat}) is not implemented");
        }
    }
}
