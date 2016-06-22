using Brockhaus.PraktikumZeugnisGenerator.Model;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Brockhaus.PraktikumZeugnisGenerator.Services
{
    class StringEditor
    {

        public static string ReplaceSexDependendWordsRegex(InternDetails internDetails, string text)
        {
            if (internDetails.Sex == Sex.Female)
            {

                Regex er_small = new Regex(@"\bEr\b");
                Regex er_big = new Regex(@"\ber\b");
                Regex herr_big = new Regex(@"\bHerr\b");
                Regex ihm_small = new Regex(@"\bihm\b");
                Regex ihm_Big = new Regex(@"\bIhm\b");
                Regex seiner_small = new Regex(@"\bseiner\b");
                Regex seiner_big = new Regex(@"\bsSeiner\b");
                Regex herrn_big = new Regex(@"\bHerrn\b");
                Regex seine_small = new Regex(@"\bseine\b");
                Regex seine_big = new Regex(@"\bSeine\b");
                Regex Praktikan_big = new Regex(@"\bPraktikant\b");
                Regex Arbeiter_big = new Regex(@"\bArbeiter\b");
                Regex sein_small = new Regex(@"\bsein\b");
                Regex sein_big = new Regex(@"\bSein\b");
                Regex seinem_small = new Regex(@"\bseinem\b");
                Regex seinem_big = new Regex(@"\bSeinem\b");

                text = er_small.Replace(text, "Sie");
                text = er_big.Replace(text, "sie");
                text = herr_big.Replace(text, "Frau");
                text = ihm_small.Replace(text, "ihr");
                text = ihm_Big.Replace(text, "Ihr");
                text = seiner_small.Replace(text, "ihrer");
                text = seiner_big.Replace(text, "Ihrer");
                text = herrn_big.Replace(text, "Frau");
                text = seine_small.Replace(text, "ihre");
                text = seine_big.Replace(text, "Ihre");
                text = Praktikan_big.Replace(text, "Praktikantin");
                text = Arbeiter_big.Replace(text, "Arbeiterin");
                text = sein_small.Replace(text, "ihr");
                text = seinem_small.Replace(text, "ihrem");
                text = seinem_big.Replace(text, "Ihrem");
                text += " ";
            }

            return text;

        }

        public static string replaceMuster(InternDetails internDetails, string docText)
        {
            Regex replaceMuster = new Regex("Muster");
            docText = replaceMuster.Replace(docText, internDetails.LastName != null ? internDetails.LastName : "");
            return docText;
        }

        public static string replaceCommaWithSemicolon(string text)
        {
            Regex replaceComma = new Regex(",");
            text = replaceComma.Replace(text, ";");
            return text;
        }
    }
}
