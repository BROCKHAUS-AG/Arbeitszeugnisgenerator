using System.Collections.Generic;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using System.IO;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.Services;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;


namespace Brockhaus.PraktikumZeugnisGenerator.Presenter

{
    public class MainWindowP
    {
        private const string UNGÜLTIGES_DATUM_TITLE = "Ungültiges Datum";
        private const string UNGÜLTIGES_GEBURTSDATUM_TEXT = "Das Geburtsdatum kann nicht nach dem Anfangsdatum sein.";
        private const string UNGÜLTIGES_ANFANGSDATUM_TEXT = "Das Anfangsdatum kann nicht nach dem Enddatum sein.";
        private const string VORLAGE_NICHT_GEFUNDEN_TITLE = "Vorlage nicht gefunden!";
        private const string VORLAGE_NICHT_GEFUNDEN_TEXT = "Die Vorlage konnte nicht gefunden werden. Es wird auf die Standardvorlage zurück gegriffen";
        private MainWindowV view;
        

        public MainWindowP(MainWindowV view)
        {
            this.view = view;
        }

        public void GenerateWordDocument(
            InternDetails internDetails,
            Dictionary<string, string> textParts)
        {
            if (internDetails.DateOfBirth > internDetails.FromDate)
            {
                MessageDialog messagedialog = new MessageDialog(UNGÜLTIGES_DATUM_TITLE, UNGÜLTIGES_GEBURTSDATUM_TEXT);
                messagedialog.ShowDialog();
                return;
            }
            if (internDetails.FromDate > internDetails.UntilDate)
            {
                MessageDialog messagedialog = new MessageDialog(UNGÜLTIGES_DATUM_TITLE, UNGÜLTIGES_ANFANGSDATUM_TEXT);
                messagedialog.ShowDialog();
                return;
            }
            try
            {
                WordDocumentManipulater.WordReplacerInterop( internDetails, textParts);
            }
            catch (FileNotFoundException)
            {
                MessageDialog message = new MessageDialog(VORLAGE_NICHT_GEFUNDEN_TITLE, VORLAGE_NICHT_GEFUNDEN_TEXT);
                message.ShowDialog();
                SavepathSerializer.Instance.SavePath = "";
                GenerateWordDocument(internDetails, textParts);
            }
        }
    }
}
