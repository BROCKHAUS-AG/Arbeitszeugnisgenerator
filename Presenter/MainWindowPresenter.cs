using System.Collections.Generic;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using System.IO;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.Services;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;


namespace Brockhaus.PraktikumZeugnisGenerator.Presenter

{
    public class MainWindowPresenter
    {
        private const string UNGÜLTIGES_DATUM_TITLE = "Ungültiges Datum";
        private const string UNGÜLTIGES_GEBURTSDATUM_TEXT = "Das Geburtsdatum kann nicht nach oder an dem Anfangsdatum sein.";
        private const string UNGÜLTIGES_ANFANGSDATUM_TEXT = "Das Anfangsdatum kann nicht nach dem Enddatum sein.";
        private const string VORLAGE_NICHT_GEFUNDEN_TITLE = "Vorlage nicht gefunden!";
        private const string VORLAGE_NICHT_GEFUNDEN_TEXT = "Die Vorlage konnte nicht gefunden werden. Es wird auf die Standardvorlage zurück gegriffen";
        private const string UNGÜLTIGES_ANFANGSDATUM_ZUKUNFT_TEXT = "Das Praktikum darf nicht in der Zukunft beginnen";
        private MainWindowView view;

        

        public MainWindowPresenter(MainWindowView view)
        {
            this.view = view;
        }



        public void GenerateWordDocument(
            InternDetails internDetails,
            Dictionary<string, string> textParts,
        bool PractExpBulletpoints, bool ExcercisesBulletPoints)
        {
            //Anfangsdautm muss kleiner als jetztigesdatum sein
            if(internDetails.DateNow < internDetails.FromDate)
            {
                MessageDialog messagedialog = new MessageDialog(UNGÜLTIGES_DATUM_TITLE, UNGÜLTIGES_ANFANGSDATUM_ZUKUNFT_TEXT);
                messagedialog.ShowDialog();
                return;
            }
            // Geburtsdatum darf nicht Größer oder gleich Anfang sein 
            if (internDetails.DateOfBirth >= internDetails.FromDate)
            {
                MessageDialog messagedialog = new MessageDialog(UNGÜLTIGES_DATUM_TITLE, UNGÜLTIGES_GEBURTSDATUM_TEXT);
                messagedialog.ShowDialog();
                return;
            }
            //Startdatum darf nicht größer Enddatum sein
            if (internDetails.FromDate > internDetails.UntilDate)
            {
                MessageDialog messagedialog = new MessageDialog(UNGÜLTIGES_DATUM_TITLE, UNGÜLTIGES_ANFANGSDATUM_TEXT);
                messagedialog.ShowDialog();
                return;
            }
            try
            {
                WordDocumentManipulater.WordReplacerInterop( internDetails, textParts, PractExpBulletpoints, ExcercisesBulletPoints);
            }
            catch (FileNotFoundException)
            {
                SavepathSerializer.Instance.SaveSavepath("");
                MessageDialog message = new MessageDialog(VORLAGE_NICHT_GEFUNDEN_TITLE, VORLAGE_NICHT_GEFUNDEN_TEXT);
                message.ShowDialog();
                SavepathSerializer.Instance.SavePath = "";
                WordDocumentManipulater.WordReplacerInterop(internDetails, textParts, PractExpBulletpoints, ExcercisesBulletPoints);
            }
        }
    }
}
