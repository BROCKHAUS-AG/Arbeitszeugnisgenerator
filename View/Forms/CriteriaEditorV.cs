using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using Brockhaus.PraktikumZeugnisGenerator.Services;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    public partial class CriteriaEditorV : Form
    {
        private const string ADD_VARIATION_DIALOG_TITLE = "Variantennamen vergeben";
        private const string ADD_VARIATION_DIALOG_TEXT = "Bitte einen Variantennamen eingeben.";
        private const string INVALID_NAME_TITLE = "Ungültiger Name";
        private const string INVALID_NAME_TEXT = "Es dürfen keine Namen doppelt vergeben werden.";
        private const string RENAME_VARIATION_TITLE = "Variation Umbennen";
        private const string RENAME_VARIATION_TEXT = "Bitte neuen Namen eingeben.";
        private const string REMOVE_VARIATION_TITLE = "Variation löschen";
        private const string REMOVE_VARIATION_TEXT = "Wollen sie diese Variation wirklich löschen?";
        public CriteriaEditorP presenter;
        private ViewState viewState;


        public CriteriaEditorV(Criteria shownCriteria, List<Criteria> criteriaList, int criteriaIndex) : this(shownCriteria, criteriaList, criteriaIndex, 0,0)
        {
        }

        public CriteriaEditorV(Criteria shownCriteria, List<Criteria> criteriaList, int criteriaIndex, int preselectedGrade, int preselectedVar)
        {
            InitializeComponent();
            presenter = new CriteriaEditorP(this, shownCriteria, criteriaList, criteriaIndex, preselectedGrade, preselectedVar);
           
            RefreshView();
        }

        public void InvalidNameChange()
        {
            MessageDialog InvalidName = new MessageDialog(INVALID_NAME_TITLE, INVALID_NAME_TEXT);
            InvalidName.ShowDialog();
        }

        public void RefreshView()
        {
            viewState = ViewState.IsRefreshing;
            RefreshLbxGrade();
            RefreshLbxVariation();
            RefreshRtxtPredefinedText();
            RefreshTxtCriteriaName();
            RefreshBtnAddVariation();
            RefreshBtnRemoveVariation();
            RefreshBtnRenameVariation();
            viewState = ViewState.WaitingForInput;
        }

        #region Refresh Methoden
        private void RefreshTxtCriteriaName()
        {
            TxtCriteriaName.Text = presenter.CriteriaName;
        }

        private void RefreshLbxGrade()
        {
            LbxGrade.Items.Clear();
            foreach (Grade grade in presenter.CurShowedCriteria.Grades)
            {
                LbxGrade.Items.Add(grade.Name);
            }
            if (presenter.SelectedGrade != null)
            {
                LbxGrade.SelectedItem = presenter.SelectedGrade.Name;
            }
        }

        private void RefreshLbxVariation()
        {
            LbxVariation.Items.Clear();
            if (presenter.SelectedGrade != null)
            {
                LbxVariation.Enabled = true;
                foreach (Variation variation in presenter.SelectedGrade.Variations)
                {
                    LbxVariation.Items.Add(variation.Name);
                }
                if (presenter.SelectedVariation != null)
                {
                    LbxVariation.SelectedItem = presenter.SelectedVariation.Name;
                }
            }
            else
            {
                LbxVariation.Enabled = false;
            }
        }

        private void RefreshRtxtPredefinedText()
        {
            if (LbxVariation.SelectedIndex != -1)
            {
                RtxtPredefinedText.Enabled = true;
                RtxtPredefinedText.Text = presenter.PredifinedText;            }
            else
            {
                RtxtPredefinedText.Enabled = false;
                RtxtPredefinedText.Text = "Keine Note/Variante Ausgewählt";
            }
        }

        private void RefreshBtnAddVariation()
        {
            if (presenter.SelectedGrade == null)
            {
                BtnAddVariation.Enabled = false;
            }
            else
            {
                BtnAddVariation.Enabled = true;
            }
        }

        private void RefreshBtnRemoveVariation()
        {
            if (LbxVariation.SelectedIndex == -1)
            {
                BtnRemoveVariation.Enabled = false;
            }
            else
            {
                BtnRemoveVariation.Enabled = true;
            }
        }

        private void RefreshBtnRenameVariation()
        {
            if (LbxVariation.SelectedIndex == -1)
            {
                BtnRenameVariation.Enabled = false;
            }
            else
            {
                BtnRenameVariation.Enabled = true;
            }
        }
        #endregion

        #region Windows Froms Control EventHandler        

        private void TxtCriteriaName_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.CriteriaName = TxtCriteriaName.Text;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            CriteriasWrapper.Instance.SaveCriteriaWrapper();
            DialogResult = DialogResult.OK;

            Close();
        }

        private void LbxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            presenter.SelectGrade(LbxGrade.SelectedIndex);
        }

        private void LbxVariation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            presenter.SelectVariation(LbxVariation.SelectedIndex);
        }

        private void BtnAddVariation_Click(object sender, EventArgs e)
        {
            
            InputDialog variationsInput = new InputDialog(ADD_VARIATION_DIALOG_TITLE, ADD_VARIATION_DIALOG_TEXT);

            if(variationsInput.ShowDialog() != DialogResult.Cancel && variationsInput.InputText != "")
            presenter.AddVariation(variationsInput.InputText);
            presenter.SelectVariation(presenter.SelectedGrade.Variations.Count - 1);
            RtxtPredefinedText.Focus();
        }

        private void RtxtPredefinedText_Leave(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.PredifinedText = RtxtPredefinedText.Text;
        }

        private void BtnRenameVariation_Click(object sender, EventArgs e)
        {
            InputDialog NameChange = new InputDialog(RENAME_VARIATION_TITLE, RENAME_VARIATION_TEXT);
            if (NameChange.ShowDialog() == DialogResult.OK)
            {
                presenter.RenameVariation(NameChange.InputText);
            }
        }

        private void BtnRemoveVariation_Click(object sender, EventArgs e)
        {
            ConfirmationDialog removeConfirmation = new ConfirmationDialog(REMOVE_VARIATION_TITLE, REMOVE_VARIATION_TEXT);
            if (removeConfirmation.ShowDialog() == DialogResult.Yes)
            {
                presenter.RemoveVariation(LbxVariation.SelectedIndex);
                
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            presenter.RestoreBackup();
            DialogResult = DialogResult.Cancel;
            
            Close();
        }

        private void CriteriaEditorV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                BtnCancel_Click(sender, e);
            }
        }

        private void BtnTake_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.UpdateBackup();
            CriteriasWrapper.Instance.SaveCriteriaWrapper();
        }

        #endregion
    }
}
