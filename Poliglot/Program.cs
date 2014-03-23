using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDesk.Options;

namespace Poliglot
{
    class Program
    {
        private static string _projectPath;
        private static bool _deleteOldKeys;
        private static bool _promptBeforeDelete;
        private static bool _showHelp;

        static void Main(string[] args)
        {
            Console.WriteLine("Poliglot");
            Console.WriteLine("Copyright antonv 2014");

            var lOptionsParser = PrepareOptionsParser();
            ParseStartupOptions(lOptionsParser, args);
            AnalyzeStartupOptions();

            if (_showHelp)
            {
                Console.WriteLine("Usage: Poliglot TODO: add usage sample");
                lOptionsParser.WriteOptionDescriptions(Console.Out);
                return;
            }
        }

        private static OptionSet PrepareOptionsParser()
        {
            var lParser = new OptionSet()
                {
                    {"pr|projects=", "path to file where project directories to check are stored", pr => _projectPath = pr},
                    {"d|delkeys", "removes keys from localization files, that no longer present in sources", d => _deleteOldKeys = d != null},
                    {"y|prompt", "prompts to confirm you want to remove this specific old key", y => _promptBeforeDelete = y != null},
                    {"h|?|help", "shows this help message nad exit", h=> _showHelp = h != null}
                };
            return lParser;
        }

        private static void ParseStartupOptions(OptionSet lOptionsParser, string[] args)
        {
        }

        private static void AnalyzeStartupOptions()
        {
        }
    }
}
