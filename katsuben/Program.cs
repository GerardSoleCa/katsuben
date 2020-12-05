using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace Katsuben
{
    public class Program
    {
        public static Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("Subtitle Converter using LibSE (Subtitle Edit)")
            {
                new Option<string>(
                    new[] { "-i", "--input" },
                    "The input subtitle to be converted") { IsRequired = true },
                new Option<string>(
                    new[] { "-o", "--output" },
                    "The output subtitle format extension to be converted") { IsRequired = true },
                new Option<string>(
                    new[] { "-e", "--encoding" },
                    () => "utf-8",
                    "The encoding for the output file (default: utf-8)")
            };
            rootCommand.Handler = CommandHandler.Create<string, string, string>(MainConverter);
            return rootCommand.InvokeAsync(args);
        }

        private static int MainConverter(string input, string output, string encoding)
        {
            try
            {
                new SubtitleConverter(SubtitleLoader.FromFile(input)).Convert(new OutputSubtitle(output, encoding));
                return 0;
            }
            catch (Exception exception)
            {
                return PrintExceptionAndExitCode(exception);
            }
        }

        private static int PrintExceptionAndExitCode(Exception exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
            return 1;
        }
    }
}
