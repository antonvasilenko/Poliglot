using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorTranstator.Localization
{
    interface ITranslator
    {
        string Translate(string key);
    }
}
