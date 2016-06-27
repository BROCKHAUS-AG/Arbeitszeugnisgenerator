using Brockhaus.PraktikumZeugnisGenerator.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using System.Linq;
using System.Threading;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;

namespace Brockhaus.PraktikumZeugnisGenerator.Services
{

    class WordDocumentManipulater
    {
        public static void WordReplacerInterop(InternDetails internDetails, Dictionary<string, string> textParts)
        {

            //Erstelle nötige Pfade
            string csvFileName = "csvTempFile.csv";
            string fullCsvFilePath = Path.GetFullPath(csvFileName);
            string tempTemplatePath = CreateDocumentWithSexDependendwords(internDetails.Sex, internDetails);
            string fullTemplatePath = Path.GetFullPath(tempTemplatePath);

            //Erstelle nötige Strings
            string lastname = internDetails.LastName != null ? internDetails.LastName : "";
            string firstname = internDetails.FirstName != null ? internDetails.FirstName : "";
            string dateOfBirth = internDetails.DateOfBirth.Date.ToString().Replace(" 00:00:00", "");
            string department = internDetails.Department != null ? internDetails.Department : "";
            string fromDate = internDetails.FromDate.Date.ToString().Replace(" 00:00:00", "");
            string untilDate = internDetails.UntilDate.Date.ToString().Replace(" 00:00:00", "");
            string exercises = internDetails.Exercises != null ? internDetails.Exercises : "";
            string praticalExp = internDetails.PracitcalExperience != null ? internDetails.PracitcalExperience : "";
            string today = DateTime.Now.Date.ToString().Replace(" 00:00:00", "");
            string criteriaEvaluation = "";
            foreach (KeyValuePair<string, string> text in textParts)
            {
                criteriaEvaluation += text.Value + " ";
            }
            criteriaEvaluation = StringEditor.replaceMuster(internDetails, criteriaEvaluation);
            criteriaEvaluation = StringEditor.ReplaceSexDependendWordsRegex(internDetails, criteriaEvaluation);
            Regex backSlashN = new Regex(@"\n");
            criteriaEvaluation = backSlashN.Replace(criteriaEvaluation, " ");

            //Überschreibe MailMergeField "PraktischeErfahrung" und "Aufgaben" damit diese Mehrzeilig sind
            try
            {
                using (WordprocessingDocument wrdProssesDoc = WordprocessingDocument.Open(tempTemplatePath, true))
                {
                    Document document = wrdProssesDoc.MainDocumentPart.Document;
                    IEnumerable<FieldCode> allMailMergeFields = document.Body.Descendants<FieldCode>();

                    foreach (FieldCode mm in allMailMergeFields)
                    {
                        if (mm.InnerText == " MERGEFIELD PraktischeErfahrung ")
                        {
                            OpenXmlElement refParagraph;
                            for (refParagraph = mm; !(refParagraph is Paragraph) && !(refParagraph is Body); refParagraph = refParagraph.Parent) ;
                            if (refParagraph is Body) { continue; }
                            ParagraphProperties prp = (ParagraphProperties)refParagraph.GetFirstChild<ParagraphProperties>().CloneNode(true);
                            OverrideMailmergefield(refParagraph, praticalExp, prp);
                            wrdProssesDoc.MainDocumentPart.Document.Save();
                        }
                        if (mm.InnerText == " MERGEFIELD Aufgaben ")
                        {
                            OpenXmlElement refParagraph;
                            for (refParagraph = mm; !(refParagraph is Paragraph) && !(refParagraph is Body); refParagraph = refParagraph.Parent) ;
                            if (refParagraph is Body) { continue; }
                            ParagraphProperties prp = (ParagraphProperties)refParagraph.GetFirstChild<ParagraphProperties>();
                            OverrideMailmergefield(refParagraph, exercises, prp);
                            wrdProssesDoc.MainDocumentPart.Document.Save();
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("Fehler", "Es ist ein Fehler aufgetreten. Bitte beachten Sie, dass die Vorlage eine Serienbriefvorlage ist.");
            }



            //Erstelle .csv Datei für Serienbrief
            using (FileStream csvFileStream = new FileStream(csvFileName, FileMode.Create))
            {

                using (StreamWriter streamWriter = new StreamWriter(csvFileStream))
                {
                    streamWriter.WriteLine("Name; Vorname; Geburtsdatum; Abteilung; Anfangsdatum; Enddatum; Aufgaben; PraktischeErfahrung; HeutigesDatum; Benotung");
                    streamWriter.WriteLine(lastname + ";" + firstname + ";" + dateOfBirth + ";" + department + ";" + fromDate + ";" + untilDate + ";" + " " + ";" + " " + ";" + today + ";" + criteriaEvaluation);
                }
            }

            //Mailmerge ausführen
            Word.Application wrdApp = new Word.Application();
            Word._Document wrdDoc = null;
            wrdApp.Visible = true;
            try
            {
                wrdDoc = wrdApp.Documents.Open(fullTemplatePath);
                wrdDoc.MailMerge.OpenDataSource(fullCsvFilePath);

                wrdDoc.MailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
                wrdDoc.MailMerge.Execute();
            }

            finally
            {

                if (wrdDoc != null)
                    wrdDoc.Close(false);
                wrdApp = null;
            }

            DeleteUsedFiles(csvFileName, tempTemplatePath);

        }

        private static void DeleteUsedFiles(string csvFileName, string tempTemplatePath)
        {
            File.Delete(tempTemplatePath);
            File.Delete(csvFileName);
        }

        private static string CreateDocumentWithSexDependendwords(Sex s, InternDetails internDetails)
        {
            string tempTemplatePath = @"Files\Vorlage.docx";
            string docText = "";
            if (SavepathSerializer.Instance.SavePath != "")
            {
                File.Copy(SavepathSerializer.Instance.SavePath, tempTemplatePath, true);
            }
            else
            {}

            if (s == Sex.Female)
            {
                using (WordprocessingDocument wrdProssesDoc = WordprocessingDocument.Open(tempTemplatePath, true))
                {
                    using (StreamReader sr = new StreamReader(wrdProssesDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                        docText = StringEditor.ReplaceSexDependendWordsRegex(internDetails, docText);
                    }
                    using (StreamWriter sw = new StreamWriter(wrdProssesDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                }
            }
            Thread.Sleep(100);
            return tempTemplatePath;
        }

        private static void OverrideMailmergefield(OpenXmlElement mailMergeField, string text, ParagraphProperties prp)
        {
            Regex splitter1 = new Regex("\n\r");
            Regex splitter2 = new Regex("\n");
            text = splitter1.Replace(text, "*");
            text = splitter2.Replace(text, "*");

            String[] splittedString = text.Split('*');
            
            foreach (String s in splittedString.Reverse())
            {
                mailMergeField.InsertAfterSelf<OpenXmlElement>(OpenXmlElementCreator.CreateNewParagraph(s, prp));
            }
        }
    }
}

