using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.Services;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Exceptions;
using System.Security;

namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    public partial class MainWindowV : Form
    {
        private const string IOEXCEPTION_DIALOG_TITLE = "Ein Fehler ist Aufgetreten";
        private const string IOEXCEPTION_DIALOG_TEXT = "Die Datei konnte nicht erstellt werden. \n Bitte beachten Sie, dass die ausgewählte Datei nicht geöffnet sein darf.";
        private const string INVALIDE_FILE_FORMAT_TITLE = "Ungültiges Dateiformat";
        private const string INVALIDE_FILE_FORMAT_TEXT = "Bitte nur Dateien mit einem gültigen Dateiformat auswählen.";
        private const string FILE_NOT_FOUND_TITLE = "Datei nicht Gefunden";
        private const string FILE_NOT_FOUN_TEXT = "Die angegebene Datei konnte nicht gefunden werden.";
        private const string DEFAULT_TEMPLATE_NOT_FOUND_TEXT = "Die Standardvorlage wurde nicht gefunden.";
        private const string SAVE_NOTIFICATION_TITLE = "Daten sind nicht gespeichert";
        private const string SAVE_NOTIFICATION_TEXT = "Wollen sie die Daten voher speichern?";
        private const string CHOOSE_TEMPLATE_TITLE = "Vorlage ausgewählt";
        private const string CHOOSE_TEMPLATE_TEXT = "Die Vorlage wurde ausgwählt.";
        private const string INVALID_PATH_TITLE = "Fehler bei der Verzeichniswahl";
        private const string INVALID_PATH_TEXT = "Der Pfad konnte nicht gefunden werden.";
        private const string AUTHORIZATION_MISSING_TITLE = "Fehler mit der Berechtigung";
        private const string AUTHORIZATION_MISSING_TEXT = "Sie haben nicht genügend Berechtigungen.";
        private const string CREATE_NEW_DOC_TITLE = "Neues Dokument erstellen";
        private const string CREATE_NEW_DOC_TEXT = "Wollen Sie die Daten voher Speichern?";
        public MainWindowP Presenter;
        private ViewState ViewState;
        private List<Criteria> CriteriaList;
        public InternDetails InternDetails;

        private List<CriteriaTextSelectionV> textPartSelectionList;

        public MainWindowV(List<Criteria> criteriaList)
        {
            InitializeComponent();
            CriteriaList = criteriaList;
            Presenter = new MainWindowP(this);
            textPartSelectionList = new List<CriteriaTextSelectionV>();
            IdInternDetails.SetBasis(this);
            InternDetails = IdInternDetails.presenter.CurShowedInternDetails;
            RefreshToolStripMenu();
            ViewState = ViewState.WaitingForInput;
        }

        public void RefreshView()
        {
            InternDetails = IdInternDetails.presenter.CurShowedInternDetails;
            ViewState = ViewState.IsRefreshing;
            if (textPartSelectionList != null)
            {
                foreach (CriteriaTextSelectionV ctV in textPartSelectionList)
                {
                    ctV.RefreshView();
                }
            }
            RefreshToolStripMenu();

            ViewState = ViewState.WaitingForInput;
        }

        private void RefreshToolStripMenu()
        {
            if (IdInternDetails.presenter.emptyFile)
            {
                speichernToolStripMenuItem.Enabled = false;

            }
            else
            {
                speichernToolStripMenuItem.Enabled = true;
            }
        }

        #region Windows Forms Control EventHandler

        private void MainWindowView_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.IsRefreshing) return;
            if (!IdInternDetails.presenter.savedChanges)
            {
                ConfirmationDialog saveNotification = new ConfirmationDialog(SAVE_NOTIFICATION_TITLE, SAVE_NOTIFICATION_TEXT);
                if (saveNotification.ShowDialog() == DialogResult.Yes)
                {
                    speichernToolStripMenuItem_Click(sender, e);
                }

            }
            Dictionary<string, string> textParts = new Dictionary<string, string>();
            foreach (CriteriaTextSelectionV singleTextPartSelection in textPartSelectionList)
            {
                if (singleTextPartSelection.presenter.SelectedVariation != null)
                {
                    textParts[singleTextPartSelection.presenter.CurShowedCriteria.Name] = singleTextPartSelection.presenter.SelectedVariation.PredifinedText;
                }
                else
                {
                    textParts[singleTextPartSelection.presenter.CurShowedCriteria.Name] = "";
                }
            }
            try
            {
                Presenter.GenerateWordDocument(IdInternDetails.presenter.CurShowedInternDetails, textParts);
            }
            catch (FileNotFoundException)
            {
                OpenMessageDialog(FILE_NOT_FOUND_TITLE, DEFAULT_TEMPLATE_NOT_FOUND_TEXT);

            }
            catch (IOException)
            {
                OpenMessageDialog(IOEXCEPTION_DIALOG_TITLE, IOEXCEPTION_DIALOG_TEXT);

            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is PathTooLongException)
            {
                OpenMessageDialog(INVALID_PATH_TITLE, INVALID_PATH_TEXT + "(Datei.xml)");
            }



        }

        private void BtnAddCriteria_Click(object sender, EventArgs e)
        {
            ChooseCriteriaManagerV chooseCriteriaManager = new ChooseCriteriaManagerV(CriteriaList);

            if (chooseCriteriaManager.ShowDialog() == DialogResult.OK)
            {

                int criteriaIndex = chooseCriteriaManager.criteriaIndex;
                CriteriaTextSelectionV criteriaTextSelection = new CriteriaTextSelectionV(chooseCriteriaManager.presenter.SelectedCriteria, IdInternDetails.presenter.Sex, CriteriaList, criteriaIndex, this);
                criteriaTextSelection.DeleteButtonClicked += this.BtnRemoveCriteria_Click;
                FlpCriteriaContainer.Controls.Add(criteriaTextSelection);
                textPartSelectionList.Add(criteriaTextSelection);
            }
        }

        private void BtnRemoveCriteria_Click(object sender, EventArgs e)
        {
            if (sender is CriteriaTextSelectionV)
            {
                CriteriaTextSelectionV castedSender = (CriteriaTextSelectionV)sender;
                textPartSelectionList.Remove(castedSender);
                (castedSender).DeleteButtonClicked -= this.BtnRemoveCriteria_Click;
                FlpCriteriaContainer.Controls.Remove(castedSender);
            }
        }

        private void BtnChooseTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog newSavepath = new OpenFileDialog();
            newSavepath.Filter = "Word-Dokumente | *.docx;*.dotx";
            try
            {
                if (newSavepath.ShowDialog() != DialogResult.Cancel)
                {
                    if (Path.GetExtension(newSavepath.FileName) != ".docx" && Path.GetExtension(newSavepath.FileName) != ".dotx")
                    { throw new InvalidFileFormatException(); }

                    SavepathSerializer.Instance.SaveSavepath(newSavepath.FileName);
                    OpenMessageDialog(CHOOSE_TEMPLATE_TITLE, CHOOSE_TEMPLATE_TEXT);

                }
            }
            catch (FileNotFoundException)
            {
                OpenMessageDialog(FILE_NOT_FOUND_TITLE, FILE_NOT_FOUN_TEXT);
            }
            catch (InvalidFileFormatException)
            {
                OpenMessageDialog(INVALIDE_FILE_FORMAT_TITLE, INVALIDE_FILE_FORMAT_TEXT + " (Datei.docx/Datei.dotx)");
            }
        }

        private void OpenMessageDialog(string title, string text)
        {
            MessageDialog messagedialog = new MessageDialog(title, text);
            messagedialog.ShowDialog();
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdInternDetails.SaveDetails();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdInternDetails.LoadDetails();
            RefreshView();
        }

        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdInternDetails.SaveDetailsAs();
        }

        private void informationenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.GetFullPath(@"Files\Benutzerhilfe.htm"));
            }
            catch (FileNotFoundException)
            { }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (!IdInternDetails.presenter.savedChanges)
            {
                ConfirmationDialog saving = new ConfirmationDialog(CREATE_NEW_DOC_TITLE, CREATE_NEW_DOC_TEXT);
                if (saving.ShowDialog() == DialogResult.Yes)
                {
                    if (IdInternDetails.LoadedDataPath != "")
                    {
                        IdInternDetails.SaveDetailsAs();
                    }
                    else
                    {
                        IdInternDetails.SaveDetails();
                    }
                }
            }
            IdInternDetails.CleanUI();
            RefreshView();

        }

        private void datengrundlageErstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            try
            {
                if (folderBrowserDialog.SelectedPath != "" && folderBrowserDialog.SelectedPath != null)
                {
                    File.Copy(Path.GetFullPath(@"Files\Daten.xlsx"), folderBrowserDialog.SelectedPath + @"\Daten.xlsx");
                }
            }
            catch (SecurityException)
            {
                OpenMessageDialog(AUTHORIZATION_MISSING_TITLE, AUTHORIZATION_MISSING_TEXT);
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is PathTooLongException)
            {
                OpenMessageDialog(INVALID_PATH_TITLE, INVALID_PATH_TEXT + "(Datei.xml)");
            }

        }
       

        private void kriterienBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseCriteriaManagerV chooseCriteriaManager = new ChooseCriteriaManagerV(CriteriaList);
            chooseCriteriaManager.BtnOk.Enabled = true;
            chooseCriteriaManager.ShowDialog();
            RefreshView();
        }

        private void MainWindowV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (IdInternDetails.LoadedDataPath != "")
                {
                    IdInternDetails.SaveDetails();
                }
                else
                {
                    IdInternDetails.SaveDetailsAs();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (IdInternDetails.LoadedDataPath != "")
            {
                IdInternDetails.SaveDetails();
            }
            else
            {
                IdInternDetails.SaveDetailsAs();
            }

        }
        #endregion
    }
}
