using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Poliglot.Transformer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var myCIintl = new CultureInfo("en", false); // neutral, no parent
            CultureInfo myCItrad = new CultureInfo("en-US", false); // parent - en
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "PROPERTY", "Short", "long");
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "CompareInfo", myCIintl.CompareInfo, myCItrad.CompareInfo);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "DisplayName", myCIintl.DisplayName, myCItrad.DisplayName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "EnglishName", myCIintl.EnglishName, myCItrad.EnglishName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsNeutralCulture", myCIintl.IsNeutralCulture,
                              myCItrad.IsNeutralCulture);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsReadOnly", myCIintl.IsReadOnly, myCItrad.IsReadOnly);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "LCID", myCIintl.LCID, myCItrad.LCID);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Name", myCIintl.Name, myCItrad.Name);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "NativeName", myCIintl.NativeName, myCItrad.NativeName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Parent", myCIintl.Parent, myCItrad.Parent);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TextInfo", myCIintl.TextInfo, myCItrad.TextInfo);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterISOLanguageName", myCIintl.ThreeLetterISOLanguageName,
                              myCItrad.ThreeLetterISOLanguageName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterWindowsLanguageName",
                              myCIintl.ThreeLetterWindowsLanguageName, myCItrad.ThreeLetterWindowsLanguageName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TwoLetterISOLanguageName", myCIintl.TwoLetterISOLanguageName,
                              myCItrad.TwoLetterISOLanguageName);
            Console.WriteLine();


            var pr = new Poliglot() { Namespace = "RazorTranstator.Localization", TargetPlatform = Platform.Droid, WriteLine = Console.WriteLine};
            pr.Transform(@"d:\Work\binary\src\trunk\Mobile\Touch\Swissphone.SOne.Mobile.Touch.Ui\Resources\de.lproj\Localizable.strings", GenerationMode.CSharpAccessors);

            //pr.Transform(@"d:\Work\subwork\git\Transformer\sandbox\RazorTranstator\Strings.en.resx");
            //pr.GenerateAccessors(@"d:\Work\subwork\git\Transformer\sandbox\RazorTranstator\Strings.en.resx", "RazorTranstator.Localization", Platform.Droid);
            
            Console.ReadLine();
        }
    }
}
