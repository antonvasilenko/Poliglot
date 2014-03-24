using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Poliglot
{
    class Translator
    {
        private List<string> _sourceDirs;

        public Translator(IEnumerable<string> sourceDirs)
        {
            _sourceDirs = sourceDirs.ToList();
        }

        private string getRootPath()
        {
            if (!String.IsNullOrEmpty(_rootPath))
                return _rootPath;

            var root = AppDomain.CurrentDomain.BaseDirectory.Replace(@"Mobile\Core\Swissphone.SOne.Mobile.Core.IntTests\bin\Debug", "");
            return root;
        }

        public void Run()
        {
            var words = getWordsForTranslate();

            var languages = new[] { "en", "de", "ru" };
            foreach (var language in languages)
            {
                updateLanguage(language, words);
            }
        }

        private List<string> getWordsForTranslate()
        {
            var root = getRootPath();
            var rootMessages = getWordsFromFolder(root);

            var rawList = rootMessages.Distinct().ToList();

            //from droid
            var path = Path.Combine(getPathToDroidResource(), "values\\strings.xml");
            var document = XDocument.Load(path);
            var droidStrings = document.Descendants("resources").First().Descendants("string");
            foreach (var droidString in droidStrings)
            {
                var key = droidString.Attribute("name").Value;
                if (!rawList.Contains(key))
                {
                    rawList.Add(key);
                }
            }

            var list = new List<string>();
            foreach (var word in rawList.OrderBy(x => x))
            {
                if (word.Contains("?") || word.Contains(" ") || word.Contains("!") || word.Contains(".") || word.Contains(","))
                {
                    Console.WriteLine("WARNING - " + word);
                }
                else
                {
                    list.Add(word);
                }
            }

            return list;
        }

        private string getPathToDroidResource()
        {
            var path = Path.Combine(getRootPath(), @"Mobile\Droid\Swissphone.SOne.Mobile.Droid.Ui\Resources");
            return path;
        }

        private void updateLanguage(string language, IEnumerable<string> words)
        {
            var fullList = updateIosDictionary(language, words);
            replicateToAndroidDictionary(language, fullList);
        }

        private Dictionary<string, string> updateIosDictionary(string language, IEnumerable<string> words)
        {
            var path = Path.Combine(getRootPath(), @"Mobile\Touch\Swissphone.SOne.Mobile.Touch.Ui\Resources");
            path = Path.Combine(path, language + @".lproj\Localizable.strings");

            var lines = File.ReadAllLines(path, Encoding.UTF8).ToList();
            var before = lines.Count;
            foreach (var word in words.OrderBy(x => x))
            {
                var left = "\"" + word + "\"";
                if (lines.Any(x => x.Contains(left)))
                {
                    continue;
                }
                lines.Add(left + "=\"" + createTranslate(word) + "\";");
            }

            if (lines.Count > before)
            {
                File.WriteAllLines(path, lines.OrderBy(x => x).ToArray());
            }

            var dictionary = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { "\"=\"" }, StringSplitOptions.None);
                var key = parts[0].Trim().Substring(1);
                var value = parts[1].Trim().Substring(0, parts[1].Length - 2);
                dictionary.Add(key, value);
            }
            return dictionary;
        }

        private void replicateToAndroidDictionary(string language, Dictionary<string, string> words)
        {
            if (language == "en")
            {
                language = "";
            }
            else
            {
                language = "-" + language;
            }
            var path = Path.Combine(getPathToDroidResource(), "values" + language + @"\strings.xml");

            var document = XDocument.Load(path);
            var resource = document.Descendants("resources").First();

            foreach (var pair in words)
            {
                var element = resource.XPathSelectElement("string[@name = \"" + pair.Key + "\"]");
                if (element == null)
                {
                    element = new XElement("string", "");
                    element.SetAttributeValue("name", pair.Key);
                    resource.Add(element);
                }
                element.SetValue(pair.Value.Replace("'", "\\'"));
            }

            document.Save(path);
        }

        private string createTranslate(string val)
        {
            return "-" + RemoveSpecialCharacters(val, true);
        }

        private IEnumerable<string> getWordsFromFolder(string path)
        {
            return Directory
                .GetFiles(path, "*.cs", SearchOption.AllDirectories)
                .Select(getWordsFromFile)
                .SelectMany(x => x)
                .ToList();
        }

        private List<string> getWordsFromFile(string path)
        {
            var text = File.ReadAllText(path);
            var matches = Regex.Matches(text, "\"t_(.*?)\"");

            var list = new List<string>();
            for (var i = 0; i < matches.Count; i++)
            {
                var val = matches[i].Value;
                if (val.Length > 10)
                {
                    val = val.Replace("\"", "");
                    list.Add(val);
                }
            }

            return list;
        }

        public static string RemoveSpecialCharacters(string text, bool skipLogger = false)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= 3)
            {
                return text;
            }

            var prefixEndPos = text.IndexOf('_', 2);
            if (prefixEndPos >= 0)
            {
                if (!skipLogger)
                {
                    Console.WriteLine("Text [{0}] doesn't have translate.", text);
                }

                return text.Substring(prefixEndPos + 1, text.Length - 1 - prefixEndPos).Replace("_", " ");
            }

            return text;
        }

    }
}
