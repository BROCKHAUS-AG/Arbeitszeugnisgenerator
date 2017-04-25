using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    public partial class ChooseCriteriaManagerView : Form
    {
        private const string NAME_WÄHLEN_MESSAGE = "Name des Kriteriums:";
        private const string NAME_WÄHLEN_TITLE = "Eingabe für Kriteriumsname";
        private const string KRITERIUM_LOESCHEN_TITLE = "Löschen des Kriteriums bestätigen";
        private const string KRITERIUM_LOESCHEN_MESSAGE = "Wollen Sie die ausgewählten Elemente wirklich löschen?";

        private List<Criteria> CriteriaList;
        public ChooseCriteriaManagerPresenter presenter;
        private ViewState viewState;
        public List<int> SelectedItemsIndexes = new List<int>();
        private CheckListboxWorkState Checkstate = CheckListboxWorkState.isWaiting;



        public ChooseCriteriaManagerView(List<Criteria> criteriaList)
        {
            InitializeComponent();
            CriteriaList = criteriaList;
            presenter = new ChooseCriteriaManagerPresenter(this, criteriaList);
            RefreshView();
        }

        public void RefreshView()
        {
            viewState = ViewState.IsRefreshing;
            RefreshLbxCriteria();
            viewState = ViewState.WaitingForInput;
        }

        #region Refresh Methoden

        private void RefreshLbxCriteria()
        {
            LbxCriteria.Items.Clear();
            foreach (Criteria criteria in presenter.Criterias)
            {
                LbxCriteria.Items.Add(criteria.Name);
            }
            if (presenter.SelectedCriteria != null)
            {
                LbxCriteria.SelectedItem = presenter.SelectedCriteria.Name;
            }
        }

        #endregion

        #region Windows Forms Control EventHandler

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            foreach (int index in LbxCriteria.CheckedIndices)
            {
                SelectedItemsIndexes.Add(index);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnEditCriteria_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            int criteriaIndex = CriteriaList.IndexOf(presenter.SelectedCriteria);
            CriteriaEditorView criteriaEditorV = new CriteriaEditorView(presenter.SelectedCriteria);
            criteriaEditorV.ShowDialog();
            RefreshView();
        }

        private void LbxCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.SelectCriteria(LbxCriteria.SelectedIndex);
        }

        private void ChooseCriteriaManagerV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {

                BtnCancle_Click(sender, e);
            }
        }

        private void ChbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (Checkstate == CheckListboxWorkState.IsWorking) return;
            if (ChbxAll.Checked)
            {
                for (int i = 0; i < LbxCriteria.Items.Count; i++)
                {
                    LbxCriteria.SetItemCheckState(i, CheckState.Checked);
                }
            }
            else
            {
                for (int i = 0; i < LbxCriteria.Items.Count; i++)
                {
                    LbxCriteria.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void LbxCriteria_MouseUp(object sender, MouseEventArgs e)
        {
            if (Checkstate == CheckListboxWorkState.IsWorking) return;
            Checkstate = CheckListboxWorkState.IsWorking;
            if (LbxCriteria.CheckedIndices.Count == 0)
            {
                ChbxAll.Checked = false;
            }
            if (LbxCriteria.CheckedIndices.Count == LbxCriteria.Items.Count && LbxCriteria.Items.Count >0)
            {
                ChbxAll.Checked = true;
            }
            else
            {
                ChbxAll.Checked = false;
            }
            LbxCriteria.ClearSelected();
            Checkstate = CheckListboxWorkState.isWaiting;
        }
        #endregion
    }
    public enum CheckListboxWorkState { IsWorking, isWaiting }
}