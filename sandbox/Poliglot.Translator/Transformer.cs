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
    public enum Platform
    {
        Undefined,
        Droid,
        Touch
    }

    public enum GenerationType
    {
        Undefined,
        DroidResources,
        TouchStrings,
        CSharpAccessors
    }

    public class Transformer
    {
        private const string KEY_PREFIX_GENERAL = "t_";
        private const string KEY_PREFIX_DROID = "td_";
        private const string KEY_PREFIX_TOUCH = "tt_";
        private string _commentTemplate;

        private class LocaleNode
        {
            public string Name;
            public string KeyValue;
            public bool IsClass;
            public readonly IDictionary<string, LocaleNode> Childs = new SortedDictionary<string, LocaleNode>();
        }

        public string Namespace { get; set; }
        public Platform TargetPlatform { get; set; }
        public Action<string> WriteLine { get; set; }

        public void Transform(string filePath, GenerationType type)
        {
            switch (type)
            {
                case GenerationType.CSharpAccessors:
                    _commentTemplate = "//{0}";
                    break;
                case GenerationType.DroidResources:
                    _commentTemplate = "<!--{0}-->";
                    break;
                case GenerationType.TouchStrings:
                    _commentTemplate = "/*{0}*/";
                    break;
                default:
                    _commentTemplate = "{0}";
                    break;
            }

            try
            {
                var words = FetchPhrazes(filePath);
                words = words.OrderBy(kvp => kvp.Key).ToDictionary(kp => kp.Key, kp => kp.Value);
                Generate(words, type);

                IntWriteCommentLine(string.Format("cur dir is: {0}", Environment.CurrentDirectory));
            }
            catch (Exception ex)
            {
                IntWriteCommentLine( ex.Message);
                IntWriteCommentLine(ex.StackTrace);
            }
        }

        private IDictionary<string, string> FetchPhrazes(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath", "filePath path can't be null");
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("File {0} was not found", filePath));

            var ext = Path.GetExtension(filePath);
            if (ext == ".resx")
            {
                return FetchFromResx(filePath);
            }
            if (ext == ".xml")
            {
                return FetchFromDriodResources(filePath);
            }
            if (ext == ".strings")
            {
                return FetchFromTouchStrings(filePath);
            }

            throw new FileNotFoundException(string.Format("Unknown file format {0} - supported formats are *.resx, *.strings or android strings.xml", ext));
        }

        private IDictionary<string, string> FetchFromResx(string filePath)
        {
            var result = new Dictionary<string, string>();
            XDocument document = XDocument.Load(filePath);

            IEnumerable<XElement> dataElements = document.XPathSelectElements("//root/data");

            foreach (XElement element in dataElements)
            {
                string elementName = element.Attribute("name").Value;
                string elementValue;

                XElement valueElement = element.Element("value");

                if (valueElement != null)
                {
                    elementValue = valueElement.Value;
                }
                else
                {
                    continue;
                }

                string cleanedValue = elementValue.Replace("'", "\\'");

                result.Add(elementName, cleanedValue);
            }
            return result;
        }

        private IDictionary<string, string> FetchFromDriodResources(string filePath)
        {
            var result = new Dictionary<string, string>();
            var document = XDocument.Load(filePath);
            var droidStrings = document.Descendants("resources").First().Descendants("string");
            foreach (var record in droidStrings)
            {
                var key = record.Attribute("name").Value;
                var value = record.Value;
                result.Add(key, value);
            }
            return result;
        }

        private IDictionary<string, string> FetchFromTouchStrings(string filePath)
        {
            var result = new Dictionary<string, string>();

            var lines = File.ReadAllLines(filePath, Encoding.UTF8).ToList();
            var before = lines.Count;
            var regex = new Regex(@"\s*""(\S+)""\s*=\s*""([\S ]+)""\s*;");
            foreach (var line in lines)
            {
                var m = regex.Match(line);
                if (m.Success && m.Groups.Count == 3)
                {
                    result.Add(m.Groups[1].Value, m.Groups[2].Value);
                }
            }
            return result;
        }

        private void Generate(IDictionary<string, string> words, GenerationType type)
        {
            switch (type)
            {
                case GenerationType.CSharpAccessors:
                    GenerateAccessors(words);
                    return;
                case GenerationType.DroidResources:
                    GenerateDroidResources(words);
                    return;
                case GenerationType.TouchStrings:
                    GenerateTouchStrings(words);
                    return;
            }
        }

        private void GenerateTouchStrings(IDictionary<string, string> words)
        {
            throw new NotImplementedException();
        }

        public void GenerateDroidResources(IDictionary<string, string> words)
        {
            IntWriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            IntWriteLine("<resources>");

            foreach (var kvp in words)
            {
                if (!kvp.Key.StartsWith(KEY_PREFIX_GENERAL) && !kvp.Key.StartsWith(KEY_PREFIX_DROID))
                {
                    continue;
                }

                string cleanedValue;
                if (!String.IsNullOrEmpty(kvp.Value))
                {
                    cleanedValue = kvp.Value.Replace("'", "\\'");
                }
                else
                {
                    cleanedValue = string.Format("-{0}", kvp.Key);
                }

                IntWriteLine(string.Format("    <string name=\"{0}\">{1}</string>", kvp.Key, cleanedValue));
            }
            IntWriteLine("</resources>");
        }

        public void GenerateAccessors(IDictionary<string, string> words)
        {
            IntWriteLine("namespace " + Namespace);
            IntWriteLine("{");

            var root = new LocaleNode { IsClass = true, Name = "L" };

            foreach (var kvp in words)
            {
                AddToTree(root, kvp.Key, TargetPlatform);
            }

            var builder = new StringBuilder();
            GenerateAccessors(builder, root, 1);

            IntWriteLine(builder.ToString());
            IntWriteLine("}");
        }

        private static void GenerateAccessors(StringBuilder builder, LocaleNode node, int indentLevel)
        {
            var il = Indent(indentLevel);
            if (node.IsClass)
            {
                builder.AppendFormat("{0}public static class {1}\n", il, node.Name);
                builder.AppendLine(il + "{");
                foreach (var childNode in node.Childs)
                {
                    GenerateAccessors(builder, childNode.Value, indentLevel + 1);
                }
                builder.AppendLine(il + "}");
                builder.AppendLine(il);
            }
            else
            {
                builder.AppendFormat("{0}public static string {1}\n", il, node.Name);
                builder.AppendLine(il + "{");
                builder.AppendFormat("{0}get {{ return Ioc.Get<ITranslator>().Translate(\"{1}\"); }}\n", Indent(indentLevel + 1), node.KeyValue);
                builder.AppendLine(il + "}");
            }
        }

        private static string ValidateKey(string key, Platform platform)
        {
            if (key == null)
                return "key is null";
            if (key.IndexOfAny(new[] { ' ', '?', '!', '.', ',' }) >= 0)
                return String.Format("key {0} contains preserved symbols", key);
            if (!key.StartsWith(KEY_PREFIX_GENERAL) &&
                (platform == Platform.Droid && !key.StartsWith(KEY_PREFIX_DROID)) &&
                (platform == Platform.Touch && !key.StartsWith(KEY_PREFIX_TOUCH)))
                return String.Format("key {0} has wrong prefix", key);

            var parts = key.Split('_');
            if (parts.Length < 3)
                return String.Format("key {0} should have at least 2 separator characters", key);
            return null;
        }

        private void AddToTree(LocaleNode root, string key, Platform platform)
        {
            var err = ValidateKey(key, platform);
            if (err != null)
            {
                IntWriteLine(err);
                return;
            }
            var parts = key.Split('_');
            var className = FirstLetterToUpper(parts[1]);
            var classAlias = "_" + className;
            LocaleNode classNode = null;
            if (!root.Childs.TryGetValue(classAlias, out classNode))
            {
                root.Childs.Add(classAlias, classNode = new LocaleNode() { IsClass = true, Name = className });
            }
            var realKey = String.Join("", parts.Skip(2).Select(FirstLetterToUpper));
            if (realKey == className)
            {
                realKey = realKey + "String";
            }
            classNode.Childs[realKey] = new LocaleNode() { KeyValue = key, Name = realKey };
        }

        private static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private static string Indent(int level)
        {
            return new String(' ', level * 4);
        }

        public void IntWriteCommentLine(string line)
        {
            WriteLine(string.Format(_commentTemplate, line));
        }

        public void IntWriteLine(string line)
        {
            WriteLine(line);
        }
    }
}