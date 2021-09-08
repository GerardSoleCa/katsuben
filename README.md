![travis](https://app.travis-ci.com/GerardSoleCa/katsuben.svg?branch=master) [![Maintainability](https://api.codeclimate.com/v1/badges/237f9d502add4c35d2a2/maintainability)](https://codeclimate.com/github/GerardSoleCa/katsuben/maintainability) [![Test Coverage](https://api.codeclimate.com/v1/badges/237f9d502add4c35d2a2/test_coverage)](https://codeclimate.com/github/GerardSoleCa/katsuben/test_coverage)

# Katsuben

Benshi (弁士) were Japanese performers who provided live narration for silent films (both Japanese films and Western
films). Benshi are sometimes called katsudō-benshi (活動弁士) or katsuben (活弁). [wiki](https://en.wikipedia.org/wiki/Benshi)

This little cli-tool is based in [SubtitleEdit](https://github.com/SubtitleEdit/subtitleedit). Which at the release of
this software the CLI Converter was not totally platform-independant.

## Run this software

You can download a binary specific for your platform in the Releases page _(not yet there)_. Then you can just run `katsuben` like this:

__Windows__

```
katsuben -i input_subtitle.srt -o vtt
```

__MacOS and Linux__

```
./katsuben -i input_subtitle.srt -o vtt
```

The result of this command will leave in the same directory, used for the input, a new file with the converted subtitle.

Find more information on how to use the tool with the help command:

```
./katsuben -h

katsuben:
  Subtitle Converter using LibSE (Subtitle Edit)

Usage:
  katsuben [options]

Options:
  -i, --input <input> (REQUIRED)      The input subtitle to be converted
  -o, --output <output> (REQUIRED)    The output subtitle format extension to be converted
  -e, --encoding <encoding>           The encoding for the output file (default: utf-8) [default: utf-8]
  --version                           Show version information
  -?, -h, --help                      Show help and usage information
```

## Note for developers

Katsuben requires NET5.0 or higher for development and executions with platform dependant binaries.

You can contribute to this project by opening a Pull Requests or an Issue.
