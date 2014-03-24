using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NDesk.Options;

namespace Poliglot
{
    class Program
    {
        private static string _projectPath;
        private static string _reportPath;
        private static bool _deleteOldKeys;
        private static bool _promptBeforeDelete;
        private static string _keyPrefix;
        private static string _skipMarker;
        private static int _maxKeyLength;
        private static bool _showHelp;

        static void Main(string[] args)
        {
            Console.WriteLine("Poliglot");
            Console.WriteLine("Copyright antonv 2014");

            var lOptionsParser = PrepareOptionsParser();
            ParseStartupOptions(lOptionsParser, args);
            var analyzeRes = AnalyzeStartupOptions();

            if (!analyzeRes || _showHelp)
            {
                Console.WriteLine();
                Console.WriteLine("Usage: Poliglot --projects:\"C:\\work\\projects.config\" --lang:en,de,ru -d -y -f:\"t__\" -o:out.txt");
                Console.WriteLine();
                lOptionsParser.WriteOptionDescriptions(Console.Out);
                return;
            }

            Console.WriteLine("Searching strings in project(s) folders");
        }

        private static OptionSet PrepareOptionsParser()
        {
            var lParser = new OptionSet()
                {
                    {"p|projects=", "path to file where project directories to check are stored (file should exist and contain list of paths to folders, one path per line)", pr => _projectPath = pr},
                    {"l|lang=", "comma-separated string of supported language abbreviations, i.e. en,de,es,ru", d => _deleteOldKeys = d != null},
                    {"d|delkeys", "removes keys from localization files, that no longer present in sources", d => _deleteOldKeys = d != null},
                    {"y|prompt", "prompts to confirm you want to remove this specific old key", y => _promptBeforeDelete = y != null},
                    {"f|prefix=", "prefix to be added to the key (also a sign whether the string is a key or not)", pr => _keyPrefix = pr},
                    {"s|skipmarker=", "marker that should be placed before string to ignore it", sm => _skipMarker = sm},
                    {"m|maxkeylength=", "maximum length of suggested key (generated from original string)", (int len) => _maxKeyLength = len},
                    {"o|outreport=", "path to file where report will be stored", rep => _reportPath = rep},
                    {"h|?|help", "shows this help message and exit", h=> _showHelp = h != null}
                };
            return lParser;
        }

        private static void ParseStartupOptions(OptionSet lOptionsParser, IEnumerable<string> args)
        {
            _projectPath = "projects.config";
            _deleteOldKeys = false;
            _promptBeforeDelete = true;
            _keyPrefix = "t_";
            _skipMarker = "/*skip*/";
            _maxKeyLength = 50;
            _showHelp = false;

            List<string> extra;
            try
            {
                extra = lOptionsParser.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("greet: ");
                Console.WriteLine(e.Message);
                _showHelp = true;
            }
        }

        private static bool AnalyzeStartupOptions()
        {
            if (_showHelp)
                return true;

            if (String.IsNullOrEmpty(_projectPath))
            {
                Console.WriteLine("path to *.config file not provided, use '-p' or '--projects' option");
                return false;
            }
            if (!File.Exists(_projectPath))
            {
                Console.WriteLine("File '{0}' doesn't exists. Check path in '--projects'", _projectPath);
                return false;
            }

            if (String.IsNullOrEmpty(_keyPrefix))
            {
                Console.WriteLine("Key prefix not set, use '-f' or '--prefix' to define it");
                return false;
            }

            if (_maxKeyLength < 20)
            {
                Console.WriteLine("Maximum key length ('-m' or '--maxkeylength') cannot be less than 20");
                return false;
            }
            return true;
        }
    }
}
