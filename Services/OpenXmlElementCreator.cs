using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Brockhaus.PraktikumZeugnisGenerator.Services
{
    class OpenXmlElementCreator
    {
        public static OpenXmlElement CreateNewTextPart(string text)
        {
            Run run = new Run(new Text(text));
            return run;
        }

        public static OpenXmlElement CreateNewParagraph(string text, ParagraphProperties prp)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.PrependChild < ParagraphProperties >((ParagraphProperties)prp.CloneNode(true));
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new Text(text));

            return paragraph;
        }
    }
}
