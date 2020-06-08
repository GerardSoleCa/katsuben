using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace Katsuben
{
    public class Program
    {
        public class Options
        {
            [Option('i', "input", Required = true, HelpText = "Specify the subtitle to convert")]
            public string InputSubtitle { get; set; }

            [Option('o', "output", Required = true, Separator = ' ',
                HelpText = "Specify the output extensions separated by spaces. Optionally you can select the output encoding by appending them with a colon (srt:utf-8)")]
            public IEnumerable<string> OutputSubtitles { get; set; }
        }

        public static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            return Parser.Default.ParseArguments<Options>(args).MapResult(
                options =>
                {
                    var converter = new SubtitleConverter(SubtitleLoader.FromFile(options.InputSubtitle));
                    options.OutputSubtitles.ToList().ForEach(o => converter.Convert(OutputSubtitle.FromArgument(o)));
                    return 0;
                },
                errors => 1);
        }

        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Error: {((Exception)e.ExceptionObject).Message}");
            Environment.Exit(1);
        }
    }
}
