using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace Katsuben
{
    class Katsuben
    {
        public class Options
        {
            [Option('i', "input", Required = true, HelpText = "Specify the subtitle to convert")]
            public string InputSubtitle { get; set; }

            [Option('o', "output", Required = true, Separator = ' ',
                HelpText = "Specify the output extensions separated by spaces. Optionally you can select the output encoding by appending them with a colon (srt:utf-8)")]
            public IEnumerable<string> OutputSubtitles { get; set;  }
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(options => {
                var subtitleConverter = new SubtitleConverter(SubtitleLoader.FromFile(options.InputSubtitle));
                options.OutputSubtitles.ToList().ForEach(output => {
                    subtitleConverter.Convert(OutputSubtitle.FromArgument(output));
                });
            });
        }

        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Error: {((Exception) e.ExceptionObject).Message}");
            Environment.Exit(0);
        }
    }
}
