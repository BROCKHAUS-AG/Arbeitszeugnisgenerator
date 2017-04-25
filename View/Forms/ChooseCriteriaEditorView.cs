using Brockhaus.Arbeitszeugnisgenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Brockhaus.Arbeitszeugnisgenerator.View.Forms
{
    public partial class ChooseCriteriaEditorView : Form
    {
        private const string NAME_WÄHLEN_MESSAGE = "Name des Kriteriums:";
        private const string NAME_WÄHLEN_TITLE = "Kriteriumsnamen eingeben";
        private const string KRITERIUM_LOESCHEN_TITLE = "Löschen des Kriteriums bestätigen";
        private const string KRITERIUM_LOESCHEN_MESSAGE = "Wollen sie das Kriterium wirklich löschen?";

        private List<Criteria> CriteriaList;
        public ChooseCriteriaEditorPresenter presenter;
        private ViewState viewState;
        public int criteriaIndex;

        public ChooseCriteriaEditorView(List<Criteria> criteriaList)
        {
            InitializeComponent();
            CriteriaList = criteriaList;
            presenter = new ChooseCriteriaEditorPresenter(this, criteriaList);
            RefreshView();
        }

        public void RefreshView()
        {
            viewState = ViewState.IsRefreshing;
            RefreshLbxCriteria();
            RefreshBtnEditCriteria();
            RefreshBtnRemoveCriteria();
            //RefreshBtnOk();
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

        private void RefreshBtnEditCriteria()
        {
            if (LbxCriteria.SelectedIndex == -1)
            {
                BtnEditCriteria.Enabled = false;
            }
            else
            {
                BtnEditCriteria.Enabled = true;
            }
        }

        private void RefreshBtnRemoveCriteria()
        {
            if (LbxCriteria.SelectedIndex == -1)
            {
                BtnRemoveCriteria.Enabled = false;
            }
            else
            {
                BtnRemoveCriteria.Enabled = true;
            }
        }

        /*private void RefreshBtnOk()
        {
            if (LbxCriteria.SelectedIndex == -1)
            {
                BtnOk.Enabled = true;
            }
            else
            {
                BtnOk.Enabled = true;
            }
        }*/

        #endregion

        #region Windows Forms Control EventHandler

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            criteriaIndex = LbxCriteria.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnAddCriteria_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            InputDialog chooseCriteriaName = new InputDialog(NAME_WÄHLEN_TITLE, NAME_WÄHLEN_MESSAGE);
            if (chooseCriteriaName.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    presenter.AddCriteria(chooseCriteriaName.InputText);
                }
                catch (ArgumentException)
                {
                    return;
                }
                BtnEditCriteria_Click(sender, e);
            }
        }

        private void BtnRemoveCriteria_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            ConfirmationDialog confirmation = new ConfirmationDialog(KRITERIUM_LOESCHEN_TITLE, KRITERIUM_LOESCHEN_MESSAGE);
            if (confirmation.ShowDialog() == DialogResult.Yes)
            {
                presenter.RemoveCriteria(LbxCriteria.SelectedIndex);
            }
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

        private void LbxCriteria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LbxCriteria.SelectedIndex != -1)
                BtnEditCriteria_Click(sender, e);
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {

                BtnCancel_Click(sender, e);
            }
        }
        #endregion
    }

}
