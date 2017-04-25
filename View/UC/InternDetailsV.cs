using System.Windows.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using System.IO;
using System.Security;
using System;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using Brockhaus.PraktikumZeugnisGenerator.Exceptions;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.View.UC
{
    public partial class InternDetailsV : UserControl
    {
        private const string NAME_INCORRECT_TITLE = "Ungültiger Name";
        private const string NAME_INCORRECT_TEXT = "Es muss ein Name für die Datei vergeben werden.";
        private const string AUTHORIZATION_MISSING_TITLE = "Fehler mit der Berechtigung";
        private const string AUTHORIZATION_MISSING_TEXT = "Sie haben nicht genügend Berechtigungen.";
        private const string WRONG_PATH_TITLE = "Fehler bei der Verzeichniswahl";
        private const string WRONG_PATH_TEXT = "Der Pfad konnte nicht gefunden werden.";
        private const string INVALID_FILE_FORMAT_TITLE = "Ungültiges Dateiformat";
        private const string INVALID_FILE_FORMAT_TEXT = "Bitte nur Datein mit einem gültigen Dateiformat auswählen.";
        private const string SAVEDIALOG_TITLE = "Personendaten speichern untern";
        public InternDetailsPresenter presenter;
        private ViewState viewState;
        private MainWindowView Basis;
        public string LoadedDataPath;
        public bool BulletpointsPractExp;
        public bool BulletpointsExcercises;


        public InternDetailsV()
        {
            InitializeComponent();

            presenter = new InternDetailsPresenter(this);
            viewState = ViewState.WaitingForInput;
            BulletpointsExcercises = false;
            BulletpointsPractExp = false;
            LoadedDataPath = "";

        }

        //Dies ist mit absicht nicht im Constructor enthalten, weil dies dafür sorgt, dass der MainWindowV.cs Designer nicht richtig angezeigt wird.
        //Es muss trotzdem die Basis gesetzt werden, damit das Updaten richtig funktioniert
        public void SetBasis(MainWindowView basis)
        {
            Basis = basis;
        }

        public void RefreshView()
        {
            if (viewState == ViewState.IsRefreshing) return;
            Model.InternDetails curShowedInternDetails = presenter.CurShowedInternDetails;
            if (curShowedInternDetails == null) return;
            viewState = ViewState.IsRefreshing;


            TxtFirstName.Text = curShowedInternDetails.FirstName;
            TxtLastName.Text = curShowedInternDetails.LastName;
            DtpDateOfBirth.Value = curShowedInternDetails.DateOfBirth;
            TxtDepartment.Text = curShowedInternDetails.Department;
            DtpFromDate.Value = curShowedInternDetails.FromDate;
            DtpUntilDate.Value = curShowedInternDetails.UntilDate;
            RtxtExercises.Text = curShowedInternDetails.Exercises;
            RtxtPracticalExperience.Text = curShowedInternDetails.PracitcalExperience;
            if (curShowedInternDetails.Sex == Sex.Male)
            {
                RbtnMale.Checked = true;
            }
            if (curShowedInternDetails.Sex == Sex.Female)
            {
                RbtnFemale.Checked = true;
            }
            if (Basis != null)
            {
                Basis.RefreshView();
            }
            viewState = ViewState.WaitingForInput;
        }

        private void ShowMessageDialog(string title, string message)
        {
            MessageDialog messageDialog = new MessageDialog(title, message);
            messageDialog.ShowDialog();
        }
        internal void CleanUI()
        {
            LoadedDataPath = "";
            presenter.FirstName = "";
            presenter.LastName = "";
            presenter.Sex = Sex.Male;
            presenter.DateOfBirth = DateTime.Now;
            presenter.Department = "";
            presenter.FromDate = DateTime.Now;
            presenter.UntilDate = DateTime.Now;
            presenter.PracticalExperience = "";
            presenter.Exercises = "";
            presenter.emptyFile = true;

            RbtnMale.Checked = true;
            RbtnFemale.Checked = false;
            TxtFirstName.Text = "";
            TxtLastName.Text = "";
            DtpDateOfBirth.Value = DateTime.Now;
            DtpFromDate.Value = DateTime.Now;
            DtpUntilDate.Value = DateTime.Now;
            TxtDepartment.Text = "";
            RtxtExercises.Text = "";
            RtxtPracticalExperience.Text = "";
            presenter.savedChanges = false;
            ChbxBulletPointsExcercises.Checked = false;
            BulletpointsExcercises = false;
            ChbxBulletPointsPractExp.Checked = false;
            BulletpointsPractExp = false;

        }

        #region Windows Forms Control EvenHandler

        public void SaveDetailsAs()
        {
            if (viewState == ViewState.IsRefreshing) return;
            UpdatePresenter();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = SAVEDIALOG_TITLE;
            saveFileDialog.Filter = "XML Files|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;
                LoadedDataPath = saveFileDialog.FileName;
                try
                {

                    if (Path.GetExtension(savePath) != ".xml")
                    {
                        throw new InvalidFileFormatException();
                    }
                    if (!savePath.Contains(".xml") && savePath != "")
                    {
                        savePath += ".xml";
                    }
                    presenter.SaveInternDetails(savePath);
                }
                catch (ArgumentException)
                {
                    ShowMessageDialog(NAME_INCORRECT_TITLE, NAME_INCORRECT_TEXT);
                }
                catch (SecurityException)
                {
                    ShowMessageDialog(AUTHORIZATION_MISSING_TITLE, AUTHORIZATION_MISSING_TEXT);
                }
                catch (InvalidFileFormatException)
                {
                    ShowMessageDialog(INVALID_FILE_FORMAT_TITLE, INVALID_FILE_FORMAT_TEXT);
                }
                catch (Exception ex) when (ex is DirectoryNotFoundException || ex is PathTooLongException)
                {
                    ShowMessageDialog(WRONG_PATH_TITLE, WRONG_PATH_TEXT);
                }
            }

        }

        public void LoadDetails()
        {
            if (viewState == ViewState.IsRefreshing)
            {
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Personendaten Öffnen";
            openFileDialog.Filter = "XML Files|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string loadPath = openFileDialog.FileName;
                LoadedDataPath = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(loadPath) != ".xml")
                    {
                        throw new InvalidFileFormatException();
                    }
                    presenter.LoadInternDetails(loadPath);
                    ChbxBulletPointsExcercises.Checked = false;
                    BulletpointsExcercises = false;
                    ChbxBulletPointsPractExp.Checked = false;
                    BulletpointsPractExp = false;
                }
                catch (SecurityException)
                {
                    ShowMessageDialog(AUTHORIZATION_MISSING_TITLE, AUTHORIZATION_MISSING_TEXT);
                }
                catch (InvalidFileFormatException)
                {
                    ShowMessageDialog(INVALID_FILE_FORMAT_TITLE, INVALID_FILE_FORMAT_TEXT);
                }
                catch (Exception ex) when (ex is DirectoryNotFoundException || ex is PathTooLongException)
                {
                    ShowMessageDialog(WRONG_PATH_TITLE, WRONG_PATH_TEXT);
                }
            }

        }
        internal void SaveDetails()
        {
            if (LoadedDataPath == "")
            {
                SaveDetailsAs();
            }

            if (viewState == ViewState.IsRefreshing) return;
            UpdatePresenter();
            string savePath = LoadedDataPath;
            try
            {

                if (Path.GetExtension(savePath) != ".xml")
                {
                    throw new InvalidFileFormatException();
                }
                if (!savePath.Contains(".xml") && savePath != "")
                {
                    savePath += ".xml";
                }

                presenter.SaveInternDetails(savePath);
            }
            catch (ArgumentException)
            {
                ShowMessageDialog(NAME_INCORRECT_TITLE, NAME_INCORRECT_TEXT);
            }
            catch (SecurityException)
            {
                ShowMessageDialog(AUTHORIZATION_MISSING_TITLE, AUTHORIZATION_MISSING_TEXT);
            }
            catch (InvalidFileFormatException)
            {
                ShowMessageDialog(INVALID_FILE_FORMAT_TITLE, INVALID_FILE_FORMAT_TEXT);
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is PathTooLongException)
            {
                ShowMessageDialog(WRONG_PATH_TITLE, WRONG_PATH_TEXT);
            }
        }

        private void UpdatePresenter()
        {
            viewState = ViewState.IsRefreshing;

            string firstname = TxtFirstName.Text;
            presenter.FirstName = firstname;
            string lastname = TxtLastName.Text;
            presenter.LastName = lastname;
            DateTime dateofbirth = DtpDateOfBirth.Value;
            presenter.DateOfBirth = dateofbirth;
            string department = TxtDepartment.Text;
            presenter.Department = department;
            DateTime fromdate = DtpFromDate.Value;
            presenter.FromDate = fromdate;
            DateTime untildate = DtpUntilDate.Value;
            presenter.UntilDate = untildate;
            string exercises = RtxtExercises.Text;
            presenter.Exercises = exercises;
            string practicalexperience = RtxtPracticalExperience.Text;
            presenter.PracticalExperience = practicalexperience;
            Sex sex;
            if (RbtnMale.Checked)
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }
            presenter.Sex = sex;
            viewState = ViewState.WaitingForInput;
        }

        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.FirstName = TxtFirstName.Text;
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.LastName = TxtLastName.Text;
        }

        private void DtpDateOfBirth_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.DateOfBirth = DtpDateOfBirth.Value;
        }

        private void TxtDepartment_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.Department = TxtDepartment.Text;
        }

        private void DtpFromDate_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.FromDate = DtpFromDate.Value;
        }

        private void DtpUntilDate_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.UntilDate = DtpUntilDate.Value;
        }

        private void RtxtExercises_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.Exercises = RtxtExercises.Text;
        }

        private void RtxtPracticalExperience_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.PracticalExperience = RtxtPracticalExperience.Text;
        }

        private void RBtnsSex_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnMale.Checked)
            {
                presenter.Sex = Sex.Male;
            }
            else
            {
                presenter.Sex = Sex.Female;
            }
        }

        private void All_KeyDown(object sender, KeyEventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (LoadedDataPath != "")
                {
                    SaveDetails();
                }
                else
                {
                    SaveDetailsAs();

                }
            }
        }

        private void ChbxBulletPointsExcercises_CheckedChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            RtxtExercises.SelectAll();
            if (ChbxBulletPointsExcercises.Checked)
            {
                RtxtExercises.SelectionBullet = true;
                BulletpointsExcercises = true;
            }
            else
            {
                RtxtExercises.SelectionBullet = false;
                BulletpointsExcercises = false;
            }
            RtxtExercises.DeselectAll();
        }

        private void ChbxBulletPointsPractExp_CheckedChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            RtxtPracticalExperience.SelectAll();
            if (ChbxBulletPointsPractExp.Checked)
            {
                RtxtPracticalExperience.SelectionBullet = true;
                BulletpointsPractExp = true;
            }
            else
            {
                RtxtPracticalExperience.SelectionBullet = false;
                BulletpointsPractExp = false;
            }
            RtxtPracticalExperience.DeselectAll();
        }
        #endregion


    }
    public enum ViewState
    {
        IsRefreshing, WaitingForInput
    }
}
