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
using Brockhaus.Arbeitszeugnisgenerator.View.Forms;

namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    public partial class MainWindowView : Form
    {
        private const string IOEXCEPTION_DIALOG_TITLE = "Ein Fehler ist Aufgetreten";
        private const string IOEXCEPTION_DIALOG_TEXT = "Fehler: Die Datei konnte nicht erstellt werden.";
        private const string INVALIDE_FILE_FORMAT_TITLE = "Ungültiges Dateiformat";
        private const string INVALIDE_FILE_FORMAT_TEXT = "Bitte nur Dateien mit einem gültigen Dateiformat auswählen.";
        private const string FILE_NOT_FOUND_TITLE = "Datei nicht Gefunden";
        private const string FILE_NOT_FOUND_TEXT = "Die angegebene Datei konnte nicht gefunden werden.";
        private const string DEFAULT_TEMPLATE_NOT_FOUND_TEXT = "Die Standardvorlage wurde nicht gefunden. Bitte wählen Sie eine Vorlage aus.";
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
        private const string TOOLTIP_TEXT = "Es wird eine Excel Datei erstellt, die Sie benötigen um Zugriff auf die Seriendruckfelder in Word zu bekommen."
                                              + "\nMehr Informationen finden Sie, wenn sie F1 Drücken, unter dem Punkt \"2.1 die Vorlage erstellen.\"";
        public MainWindowPresenter Presenter;
        private ViewState ViewState;
        private List<Criteria> CriteriaList;
        public InternDetails InternDetails;

        private List<CriteriaTextSelectionView> textPartSelectionList;

        public MainWindowView(List<Criteria> criteriaList)
        {
            InitializeComponent();
            CriteriaList = criteriaList;
            Presenter = new MainWindowPresenter(this);
            textPartSelectionList = new List<CriteriaTextSelectionView>();
            IdInternDetails.SetBasis(this);
            InternDetails = IdInternDetails.presenter.CurShowedInternDetails;
            FlpCriteriaContainer.HorizontalScroll.Enabled = false;
            FlpCriteriaContainer.VerticalScroll.Enabled = true;
            RefreshToolStripMenu();
            ViewState = ViewState.WaitingForInput;
        }

        public void RefreshView()
        {
            InternDetails = IdInternDetails.presenter.CurShowedInternDetails;
            ViewState = ViewState.IsRefreshing;
            if (textPartSelectionList != null)
            {
                foreach (CriteriaTextSelectionView ctV in textPartSelectionList)
                {
                    ctV.RefreshView();
                }
            }
            RefreshToolStripMenu();

            ViewState = ViewState.WaitingForInput;
        }

        private void RefreshToolStripMenu()
        {
            speichernToolStripMenuItem.Enabled = !IdInternDetails.presenter.emptyFile;
        }

        public void SwitchElements(CriteriaTextSelectionView cri, Direction direction)
        {

            int count = FlpCriteriaContainer.Controls.Count;
            int index = FlpCriteriaContainer.Controls.IndexOf(cri);


            /* Kleiner als 2 == Kein Bewegen möglich */
            if (count < 2) return;

            switch (direction)
            {
                case Direction.Up:
                    /* Den ersten View nicht nach oben verschieben */
                    if(index > 0)
                    {
                        FlpCriteriaContainer.Controls.SetChildIndex(cri, FlpCriteriaContainer.Controls.IndexOf(cri) - 1);
                    }
                    break;
                case Direction.Down:
                    /* Den letzen View nicht nach unten verschieben */
                    FlpCriteriaContainer.Controls.SetChildIndex(cri, FlpCriteriaContainer.Controls.IndexOf(cri) + 1);
                    break;
            }
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
            foreach (CriteriaTextSelectionView singleTextPartSelection in textPartSelectionList)
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
                Presenter.GenerateWordDocument(IdInternDetails.presenter.CurShowedInternDetails, textParts, IdInternDetails.BulletpointsPractExp, IdInternDetails.BulletpointsExcercises);
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
                OpenMessageDialog(INVALID_PATH_TITLE, INVALID_PATH_TEXT);
            }
        }

        private void BtnAddCriteria_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChooseCriteriaManagerView chooseCriteriaManager = new ChooseCriteriaManagerView(CriteriaList);

            if (chooseCriteriaManager.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < chooseCriteriaManager.SelectedItemsIndexes.Count; i++)
                {
                    int criteriaIndex = chooseCriteriaManager.SelectedItemsIndexes[i];
                    CriteriaTextSelectionView criteriaTextSelection = new CriteriaTextSelectionView(CriteriaList[criteriaIndex], IdInternDetails.presenter.Sex, this, FlpCriteriaContainer.Controls.Count, null);
                    if(criteriaTextSelection.presenter.SelectedVariation != null)
                    {
                        InternDetails.SavedVariations.Add(criteriaTextSelection.presenter.SelectedVariation.guid);
                    }
                    InternDetails.SavedCriterias.Add(CriteriaList[criteriaIndex].guid);
                    criteriaTextSelection.DeleteButtonClicked += this.BtnRemoveCriteria_Click;
                    FlpCriteriaContainer.Controls.Add(criteriaTextSelection);
                    textPartSelectionList.Add(criteriaTextSelection);
                }
            }
            this.ResumeLayout();
        }

        private void AddCriteriaOnLoad()
        {
            this.SuspendLayout();
            List<Criteria> tempList = InternDetails.GetLastSessionCriterias(CriteriaList);
            foreach (Criteria criteria in tempList)
            {
                CriteriaTextSelectionView criteriaTextSelection = new CriteriaTextSelectionView(criteria, IdInternDetails.presenter.Sex, this, FlpCriteriaContainer.Controls.Count, InternDetails.SavedVariations);
                criteriaTextSelection.DeleteButtonClicked += this.BtnRemoveCriteria_Click;
                FlpCriteriaContainer.Controls.Add(criteriaTextSelection);
                textPartSelectionList.Add(criteriaTextSelection);
            }

            this.ResumeLayout();
        }

        private void RemoveCriteria(CriteriaTextSelectionView removedCriteria)
        {
            if(removedCriteria.presenter.SelectedVariation != null)
            {
                InternDetails.SavedVariations.Remove(removedCriteria.presenter.SelectedVariation.guid);

            }
            InternDetails.SavedCriterias.Remove(removedCriteria.presenter.CurShowedCriteria.guid);
            removedCriteria.DeleteButtonClicked -= this.BtnRemoveCriteria_Click;
            FlpCriteriaContainer.Controls.Remove(removedCriteria);
        }

        private void RemoveAllCriterias()
        {
            foreach(CriteriaTextSelectionView removedCriteria in textPartSelectionList)
            {
                RemoveCriteria(removedCriteria);
            }
            textPartSelectionList.Clear();
        }

        private void BtnRemoveCriteria_Click(object sender, EventArgs e)
        {
            if (sender is CriteriaTextSelectionView)
            {
                RemoveCriteria((CriteriaTextSelectionView)sender);
            }
            textPartSelectionList.Remove((CriteriaTextSelectionView)sender);
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
                OpenMessageDialog(FILE_NOT_FOUND_TITLE, FILE_NOT_FOUND_TEXT);
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
            RemoveAllCriterias();
            IdInternDetails.LoadDetails();
            AddCriteriaOnLoad();
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
            catch (System.ComponentModel.Win32Exception)
            {
                OpenMessageDialog(FILE_NOT_FOUND_TITLE, FILE_NOT_FOUND_TEXT);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            RemoveAllCriterias();

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
            SaveFileDialog folderBrowserDialog = new SaveFileDialog();
            folderBrowserDialog.Filter = "Excel Dateien | *xlsx";
            folderBrowserDialog.ShowDialog();
            try
            {
                if (folderBrowserDialog.FileName != "" && folderBrowserDialog.FileName != null)
                {
                    if (Path.GetExtension(folderBrowserDialog.FileName) != ".xlsx")
                    {
                        folderBrowserDialog.FileName += ".xlsx";
                    }
                    try
                    {
                        File.Copy(Path.GetFullPath(@"Files\Daten.xlsx"), folderBrowserDialog.FileName);
                    }
                    catch (FileNotFoundException)
                    {
                        OpenMessageDialog(FILE_NOT_FOUND_TITLE, FILE_NOT_FOUND_TEXT);
                    }
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
            ChooseCriteriaEditorView chooseCriteriaManager = new ChooseCriteriaEditorView(CriteriaList);
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
            if (e.KeyCode == Keys.F1)
            {
                informationenToolStripMenuItem_Click(sender, e);
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

        private void seriendruckfeldDateiErstellenToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            IWin32Window win = menuStrip1;
            ToolTipMailmerge.Show(TOOLTIP_TEXT, win);
        }

        private void seriendruckfeldDateiErstellenToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            IWin32Window win = menuStrip1;
            ToolTipMailmerge.Hide(win);
        }

        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            MainWindowV_KeyDown(sender, e);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }

    public enum Direction { Up, Down }
}
