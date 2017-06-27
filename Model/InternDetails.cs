using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using Brockhaus.Arbeitszeugnisgenerator.Model;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class InternalDetails
    {
        private const string INVALID_FILE_TITLE = "Ungültige Datei";
        private const string INVALID_FILE_TEXT = "Bitte nur gültige Dateien auswählen.";

        public Sex Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateNow { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }
        public string Exercises { get; set; }
        public string PracitcalExperience { get; set; }
        public GuidList SavedVariations { get; set; }
        public GuidList SavedCriterias { get; set; }

        public InternalDetails()
        {
            DateNow = DateTime.Now;
            DateOfBirth = DateTime.Now;
            FromDate = DateTime.Now;
            UntilDate = DateTime.Now;
            SavedVariations = new GuidList();
            SavedCriterias = new GuidList();
        }

        public void Serialize(string savePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InternalDetails));

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

        public List<Criteria> GetLastSessionCriterias(List<Criteria> allCriterias)
        {
            List<Criteria> crits = new List<Criteria>();
            foreach (GuidId sCrit in SavedCriterias)
            {
                foreach (Criteria c in allCriterias)
                {
                    if (sCrit.Guid == c.guid)
                    {
                        crits.Add(c);
                    }
                }
            }
            return crits;
            //return allCriterias.Where(criteria => SavedCriterias.Contains(criteria.guid)).ToList();
        }

        public static InternalDetails Deserialize(string loadPath)
        {
            InternalDetails openedInternDetails = null;
            XmlSerializer serializer = new XmlSerializer(typeof(InternalDetails));
            try
            {
                using (Stream fileStream = new FileStream(loadPath, FileMode.Open))
                {
                    openedInternDetails = (InternalDetails)serializer.Deserialize(fileStream);
                    openedInternDetails.SavedCriterias.Sort(openedInternDetails.SavedCriterias.SortDelegate);
                }
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

        internal void ChangeIndex(int index, View.Forms.Direction dir)
        {
            switch (dir)
            {
                case View.Forms.Direction.Up:
                    SwitchGuid(SavedCriterias, index, index - 1);
                    break;
                case View.Forms.Direction.Down:
                    SwitchGuid(SavedCriterias, index, index + 1);
                    break;
            }
        }

        private void SwitchGuid(List<GuidId> source, int one, int two)
        {
            Guid oneGuid = SavedCriterias[one].Guid;
            SavedCriterias[one].Guid = SavedCriterias[two].Guid;
            SavedCriterias[two].Guid = oneGuid;
        }
    }

    public enum Sex
    {
        Male, Female
    }

    [Serializable]
    public class GuidId
    {
        public GuidId()
        {
            Guid = Guid.Empty;
            Id = 0;
        }

        public GuidId(Guid guid)
        {
            Guid = guid;
            Id = 0;
        }

        public GuidId(Guid guid, int id)
        {
            Guid = guid;
            Id = id;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
