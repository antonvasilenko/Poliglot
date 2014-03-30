using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RazorTranstator
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCIintl = new CultureInfo("en", false); // neutral, no parent
            CultureInfo myCItrad = new CultureInfo("en-US", false); // parent - en
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "PROPERTY", "Short", "long");
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "CompareInfo", myCIintl.CompareInfo, myCItrad.CompareInfo);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "DisplayName", myCIintl.DisplayName, myCItrad.DisplayName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "EnglishName", myCIintl.EnglishName, myCItrad.EnglishName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsNeutralCulture", myCIintl.IsNeutralCulture, myCItrad.IsNeutralCulture);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsReadOnly", myCIintl.IsReadOnly, myCItrad.IsReadOnly);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "LCID", myCIintl.LCID, myCItrad.LCID);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Name", myCIintl.Name, myCItrad.Name);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "NativeName", myCIintl.NativeName, myCItrad.NativeName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Parent", myCIintl.Parent, myCItrad.Parent);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TextInfo", myCIintl.TextInfo, myCItrad.TextInfo);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterISOLanguageName", myCIintl.ThreeLetterISOLanguageName, myCItrad.ThreeLetterISOLanguageName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterWindowsLanguageName", myCIintl.ThreeLetterWindowsLanguageName, myCItrad.ThreeLetterWindowsLanguageName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TwoLetterISOLanguageName", myCIintl.TwoLetterISOLanguageName, myCItrad.TwoLetterISOLanguageName);
            Console.WriteLine();


            var pr = new Program();

            
            pr.Run(@"d:\Work\subwork\git\Poliglot\sandbox\RazorTranstator\Strings.en.resx");
            
            Console.WriteLine("=========== generatinc string accessor classes ===========");
            pr.ProcessAccessors(@"d:\Work\subwork\git\Poliglot\sandbox\RazorTranstator\Strings.en.resx", "RazorTranstator.Localization", Platform.Droid);

        }

        private const string KEY_PREFIX_GENERAL = "t_";
        private const string KEY_PREFIX_DROID = "td_";
        private const string KEY_PREFIX_TOUCH = "tt_";

        public enum Platform
        {
            Droid,
            Touch
        }

        private class LocaleNode
        {
            public string Name;
            public string KeyValue;
            public bool IsClass = false;
            public IDictionary<string, LocaleNode> Childs = new SortedDictionary<string, LocaleNode>();
        }

        public void Run(string filePath)
        {
            IDictionary<String, String> words;
            try
            {
                words = FetchPhrazes(filePath);

            }
            catch (FileNotFoundException)
            {
                WriteLine("<!-- File not found: " + filePath + " -->");
            }
        }

        private IDictionary<string, string> FetchPhrazes(string filePath)
        {
            if (Path.GetExtension(filePath) == "resx")
            {
                return FetchFromResx(filePath);
            }
            return null;
        }

        private IDictionary<string, string> FetchFromResx(string filePath)
        {
            var result = new Dictionary<string, string>();
            XDocument document;
            try
            {
                document = XDocument.Load(filePath);
            }
            catch (FileNotFoundException)
            {
                WriteLine("<!-- File not found: " + filePath + " -->");
                WriteLine("</resources>");
                return result;
            }

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

        public void Process(string resxRelativePath)
        {
            WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            WriteLine("<resources>");

            XDocument document;
            try
            {
                document = XDocument.Load(resxRelativePath);
            }
            catch (FileNotFoundException)
            {
                WriteLine("<!-- File not found: " + resxRelativePath + " -->");
                WriteLine("</resources>");
                return;
            }

            IEnumerable<XElement> dataElements = document.XPathSelectElements("//root/data");

            foreach (XElement element in dataElements)
            {
                string elementName = element.Attribute("name").Value;
                string elementValue;

                if (!elementName.StartsWith(KEY_PREFIX_GENERAL) && !elementName.StartsWith(KEY_PREFIX_DROID))
                {
                    continue;
                }

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

                WriteLine(string.Format("    <string name=\"{0}\">{1}</string>", elementName, cleanedValue));
            }

            WriteLine("</resources>");
        }

        public void ProcessAccessors(string resxRelativePath, string namespaceName, Platform platform)
        {
            WriteLine("namespace " + namespaceName);
            WriteLine("{");
            XDocument document;
            try
            {
                document = XDocument.Load(resxRelativePath);
            }
            catch (FileNotFoundException)
            {
                WriteLine("<!-- File not found: " + resxRelativePath + " -->");
                WriteLine("}}");
                return;
            }

            var root = new LocaleNode() { IsClass = true, Name = "L" };

            IEnumerable<XElement> dataElements = document.XPathSelectElements("//root/data");

            foreach (XElement element in dataElements)
            {
                string elementName = element.Attribute("name").Value;

                AddToTree(root, elementName, platform);
            }

            var builder = new StringBuilder();
            GenerateAccessors(builder, root, 1);

            WriteLine(builder.ToString());
            WriteLine("}");
        }

        private void GenerateAccessors(StringBuilder builder, LocaleNode node, int indentLevel)
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
            }
            else
            {
                builder.AppendFormat("{0}public static string {1}\n", il, node.Name);
                builder.AppendLine(il + "{");
                builder.AppendFormat("{0}get {{ return Ioc.Get<ITranslator>().Translate(\"{1}\"); }};\n",Indent(indentLevel + 1), node.KeyValue);
                builder.AppendLine(il + "}");
            }
        }

        private string ValidateKey(string key, Platform platform)
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
                Console.WriteLine(err);
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
            classNode.Childs[realKey] = new LocaleNode() { KeyValue = key, Name = realKey };
        }

        private string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private string Indent(int level)
        {
            return new String(' ', level * 4);
        }

        void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }

}
