using Brockhaus.PraktikumZeugnisGenerator.Model;
using DocumentFormat.OpenXml;
using Novacode;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Services
{
    public class StringEditor
    {
        public static string ReplaceDatesAndNames(InternDetails internDetails,string docText)
        {
            Regex regExTag = new Regex(@"(<<.*?>>)");

            Regex regExNachname = new Regex(@"(<<NACHNAME>>)", RegexOptions.IgnoreCase);
            Regex regExVorname = new Regex(@"(<<VORNAME>>)", RegexOptions.IgnoreCase);
            Regex regExGeburtsdatum = new Regex(@"(<<GEBURTSDATUM>>)", RegexOptions.IgnoreCase);
            Regex regExAnfangsdatum = new Regex(@"(<<ANFANGSDATUM>>)", RegexOptions.IgnoreCase);
            Regex regExEnddatum = new Regex(@"(<<ENDDATUM>>)", RegexOptions.IgnoreCase);
            Regex regExHeutigesDatum = new Regex(@"(<<HEUTIGESDATUM>>)", RegexOptions.IgnoreCase);

            MatchCollection mc = regExTag.Matches(docText);
            for (int i = 0; i < mc.Count; i++)
            {
                if (regExNachname.IsMatch(mc[i].ToString()))
                {
                    docText = docText.Replace(mc[i].ToString(), internDetails.LastName != null ? internDetails.LastName : "");
                }
                if (regExVorname.IsMatch(mc[i].ToString()))
                {
                    docText = docText.Replace(mc[i].ToString(), internDetails.FirstName != null ? internDetails.FirstName : "");
                }

                if (regExGeburtsdatum.IsMatch(mc[i].ToString()))
                {
                    docText = docText.Replace(mc[i].ToString(), internDetails.DateOfBirth.ToString("dd.MM.yyyy"));
                }

                if (regExAnfangsdatum.IsMatch(mc[i].ToString()))
                {
                    docText = docText.Replace(mc[i].ToString(), internDetails.FromDate.ToString("dd.MM.yyyy"));
                }

                if (regExEnddatum.IsMatch(mc[i].ToString()))
                {
                    docText = docText.Replace(mc[i].ToString(), internDetails.UntilDate.ToString("dd.MM.yyyy"));
                }

                if (regExHeutigesDatum.IsMatch(mc[i].ToString()))
                {
                    docText = docText.Replace(mc[i].ToString(), DateTime.Now.ToString("dd.MM.yyyy"));
                }
            }
            return docText;
        }

        public static void ReplaceDatesAndNames(DocX document, InternDetails internDetails,string path)
        {
            string text = document.Text;
            ReplaceDatesAndNames(document, internDetails);
            document.SaveAs(path);
        }

        public static void ReplaceDatesAndNames(DocX document, InternDetails internDetails)
        {
            Regex regExTag = new Regex(@"(<<.*?>>)");

            Regex regExNachname = new Regex(@"(<<NACHNAME>>)", RegexOptions.IgnoreCase);
            Regex regExVorname = new Regex(@"(<<VORNAME>>)", RegexOptions.IgnoreCase);
            Regex regExGeburtsdatum = new Regex(@"(<<GEBURTSDATUM>>)", RegexOptions.IgnoreCase);
            Regex regExAnfangsdatum = new Regex(@"(<<ANFANGSDATUM>>)", RegexOptions.IgnoreCase);
            Regex regExEnddatum = new Regex(@"(<<ENDDATUM>>)", RegexOptions.IgnoreCase);
            Regex regExHeutigesDatum = new Regex(@"(<<HEUTIGESDATUM>>)", RegexOptions.IgnoreCase);

            string text = document.Text.ToString();

            MatchCollection mc = regExTag.Matches(text);
            for (int i = 0; i < mc.Count; i++)
            {
                if (regExNachname.IsMatch(mc[i].ToString()))
                {
                    document.ReplaceText(mc[i].ToString(), internDetails.LastName != null ? internDetails.LastName : "");
                }

                if (regExVorname.IsMatch(mc[i].ToString()))
                {
                    document.ReplaceText(mc[i].ToString(), internDetails.FirstName != null ? internDetails.FirstName : "");
                }

                if (regExGeburtsdatum.IsMatch(mc[i].ToString()))
                {
                    document.ReplaceText(mc[i].ToString(), internDetails.DateOfBirth.ToString("dd.MM.yyyy"));
                }

                if (regExAnfangsdatum.IsMatch(mc[i].ToString()))
                {
                    document.ReplaceText(mc[i].ToString(), internDetails.FromDate.ToString("dd.MM.yyyy"));
                }

                if (regExEnddatum.IsMatch(mc[i].ToString()))
                {
                    document.ReplaceText(mc[i].ToString(), internDetails.UntilDate.ToString("dd.MM.yyyy"));
                }
                if (regExHeutigesDatum.IsMatch(mc[i].ToString()))
                {
                    document.ReplaceText(mc[i].ToString(), DateTime.Now.ToString("dd.MM.yyyy"));
                }
            }
        }

        public static void ReplaceWordsBasedOnGender(DocX document, InternDetails internDetails, string path)
        {
            string text = document.Text;
            ReplaceWordsBasedOnGender(document, internDetails);
            document.SaveAs(path);
        }

        public static void ReplaceWordsBasedOnGender(DocX document, InternDetails internDetails)
        {
            Regex replaceTag = new Regex(@"(<<[a-zA-Z]*\/.*?>>)");
            Regex reg_male = new Regex(@"(<<.*?\/)");
            Regex reg_female = new Regex(@"(\/.*?>>)");
            string word = "DUMMY/FEHLER";
            string text = document.Text.ToString();

            MatchCollection mc = replaceTag.Matches(text);
            var matches = new string[mc.Count];
            for (int i = 0; i < matches.Length; i++)
            {
                matches[i] = mc[i].ToString();

                if (internDetails.Sex == Sex.Male)
                {
                    string tempMale = reg_male.Match(matches[i].ToString()).ToString();
                    word = tempMale.Substring(2, tempMale.Length - 3);
                    document.ReplaceText(mc[i].ToString(), word);
                }
                else
                {
                    string tempFemale = reg_female.Match(matches[i].ToString()).ToString();
                    word = tempFemale.Substring(1, tempFemale.Length - 3);
                    document.ReplaceText(mc[i].ToString(), word);
                }
            }
        }

        public static string ReplaceWordsBasedOnGender(InternDetails internDetails, string doctText)
        {
            Regex replaceTag = new Regex(@"(<<[a-zA-Z]*\/.*?>>)");
            Regex reg_male = new Regex(@"(<<.*?\/)");
            Regex reg_female = new Regex(@"(\/.*?>>)");
            string word = "DUMMY/FEHLER";

            MatchCollection mc = replaceTag.Matches(doctText);
            var matches = new string[mc.Count];
            for (int i = 0; i < matches.Length; i++)
            {
                matches[i] = mc[i].ToString();

                if (internDetails.Sex == Sex.Male)
                {
                    string tempMale = reg_male.Match(matches[i]).ToString();
                    word = tempMale.Substring(2, tempMale.Length - 3);
                    doctText = doctText.Replace(mc[i].ToString(), word);
                }
                else
                {
                    string tempFemale = reg_female.Match(matches[i]).ToString();
                    word = tempFemale.Substring(1, tempFemale.Length - 3);
                    doctText = doctText.Replace(mc[i].ToString(), word);
                }
            }
            return doctText;
        }

        public static string GetNextGenderWord(string doctText)
        {
            Regex replaceTag = new Regex(@"(<<.*?\/.*?>>)");
            Match mc = replaceTag.Match(doctText);

            return mc.ToString();
        }

        public static string GetNextDateOrName(string doctText)
        {
            Regex replaceTag = new Regex(@"(<<[a-zA-Z]*\/.*?>>)");
            Match mc = replaceTag.Match(doctText);

            return mc.ToString();
        }

        private static string GetPlainText(OpenXmlElement element)
        {
            System.Text.StringBuilder PlainTextInWord = new StringBuilder();
            foreach (OpenXmlElement section in element.Elements())
            {
                switch (section.LocalName)
                {
                    // Text 
                    case "t":
                        PlainTextInWord.Append(section.InnerText);
                        break;
                    case "cr":                          // Carriage return 
                    case "br":                          // Page break 
                        PlainTextInWord.Append(System.Environment.NewLine);
                        break;
                    // Tab 
                    case "tab":
                        PlainTextInWord.Append("\t");
                        break;
                    // Paragraph 
                    case "p":
                        PlainTextInWord.Append(GetPlainText(section));
                        PlainTextInWord.AppendLine(System.Environment.NewLine);
                        break;
                    default:
                        PlainTextInWord.Append(GetPlainText(section));
                        break;
                }
            }
            return PlainTextInWord.ToString();
        }
    }
}
