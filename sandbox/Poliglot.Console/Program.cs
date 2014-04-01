using System;
using System.Collections.Generic;
using System.IO;
using Poliglot.Options;

namespace Poliglot
{
    internal class Program
    {
        private static string _namespace;
        private static string _source;
        private static string _out;
        private static GenerationType _type;
        private static string _typeStr;
        private static Platform _platform;
        private static string _platformStr;

        private static bool _showHelp;

        private static void Main(string[] args)
        {
            var lOptionsParser = PrepareOptionsParser();
            ParseStartupOptions(lOptionsParser, args);
            var analyzeRes = AnalyzeStartupOptions();

            if (!analyzeRes || _showHelp)
            {
                Console.WriteLine();
                Console.WriteLine(
                    @"Usage: Poliglot.Trans -s:""c:\temp\input.resx"" -o:""d:\temp\out.cs"" -t:accessors -n:TestApp.Droid -p:droid");
                Console.WriteLine();
                lOptionsParser.WriteOptionDescriptions(Console.Out);
                return;
            }

            if (String.IsNullOrEmpty(_out))
            {
                // write to console
                var pr = new Transformer()
                    {
                        Namespace = _namespace,
                        TargetPlatform = _platform,
                        WriteLine = Console.WriteLine
                    };
                pr.Transform(_source, _type);
            }
            else
            {
                using (TextWriter writer = File.CreateText(_out))
                {
                    var pr = new Transformer
                    {
                            Namespace = _namespace,
                            TargetPlatform = _platform,
                            WriteLine = writer.WriteLine
                        };
                    pr.Transform(_source, _type);
                }

            }
        }

        private static OptionSet PrepareOptionsParser()
        {
            var lParser = new OptionSet()
                {
                    {"s|source=", "source file with strings to process (.xml | .strings | .resx)", s => _source = s},
                    {"o|out=", "path to file to store generation output. If not defined, result will be printed in console", o => _out = o},
                    {"t|type=", "specifies type or generation result ('droid', 'touch', 'accessors' values are allowed)", t => _typeStr = t },
                    {"n|namespace=", "(for 'accessors' type) defines namespace for generated classes", pr => _namespace = pr},
                    {"p|platform=", "(for 'accessors' type) affects on what platform-specific keys to include or exclude", pl => _platformStr = pl},
                    {"h|?|help", "shows this help message and exit", h=> _showHelp = h != null}
                };
            return lParser;
        }

        private static void ParseStartupOptions(OptionSet lOptionsParser, IEnumerable<string> args)
        {
            _source = null;
            _out = null;
            _namespace = "Your.Namespace.Here";
            _type = GenerationType.Undefined;
            _platform = Platform.Undefined;
            _showHelp = false;

            List<string> extra;
            try
            {
                extra = lOptionsParser.Parse(args);
            }
            catch (OptionException e)
            {
                Console.WriteLine(e.Message);
                _showHelp = true;
            }
        }

        private static bool AnalyzeStartupOptions()
        {
            if (String.IsNullOrEmpty(_source))
            {
                Console.WriteLine("source file not provided");
                return false;
            }

            if (!File.Exists(_source))
            {
                Console.WriteLine("source file could not be found");
                return false;
            }

            if (String.IsNullOrEmpty(_typeStr))
            {
                Console.WriteLine("generation type not provided");
                return false;
            }

            _type = _typeStr == "droid" ? GenerationType.DroidResources :
                (_typeStr == "touch" ? GenerationType.DroidResources :
                    (_typeStr == "accessors" ? GenerationType.CSharpAccessors : GenerationType.Undefined));
            if (_type == GenerationType.Undefined)
            {
                Console.WriteLine("generation type '{0}' is invalid", _typeStr);
                return false;
            }
            else
            {
                if (_type == GenerationType.CSharpAccessors)
                {
                    _platform = _platformStr == "droid" ? Platform.Droid : (_platformStr == "touch" ? Platform.Touch : Platform.Undefined);
                    if (_platform == Platform.Undefined)
                    {
                        Console.WriteLine("platform '{0}' for accessors generation is invalid", _platformStr);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
