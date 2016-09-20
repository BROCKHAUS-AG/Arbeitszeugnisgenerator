using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class InternDetails
    {
        private const string INVALID_FILE_TITLE = "Ungültige Datei";
        private const string INVALID_FILE_TEXT = "Bitte nur gültige Dateien auswählen.";

        public Sex Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }
        public string Exercises { get; set; }

        public string PracitcalExperience { get; set; }
        public List<Criteria> Criterias { get; set; }

        public InternDetails() {
            DateOfBirth = DateTime.Now;
            FromDate = DateTime.Now;
            UntilDate = DateTime.Now;
            Criterias = new List<Criteria>();
        }

        public void Serialize(string savePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InternDetails));

                using (Stream fileStream = new FileStream(savePath, FileMode.Create))
                { 
                    serializer.Serialize(fileStream, this.MemberwiseClone());
                }
            }
            catch (IOException)
           {
                OpenMessageDialog();
           }
        }

        public static InternDetails Deserialize(string loadPath)
        {
            InternDetails openedInternDetails = null;
            XmlSerializer serializer = new XmlSerializer(typeof(InternDetails));
            try
            {
                using (Stream fileStream = new FileStream(loadPath, FileMode.Open))
                { openedInternDetails = (InternDetails)serializer.Deserialize(fileStream); }
            }
            catch (IOException)
            {
                OpenMessageDialog();
            }
            catch (InvalidOperationException)
            {
                OpenMessageDialog();
            }
            return openedInternDetails;
        }

        private static void OpenMessageDialog()
        {
            MessageDialog messagedialog = new MessageDialog(INVALID_FILE_TITLE, INVALID_FILE_TEXT);
            messagedialog.ShowDialog();
        }
    }
    public enum Sex
    {
        Male,Female
    }
}
