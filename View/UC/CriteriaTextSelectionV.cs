using System;
using System.Drawing;
using System.Windows.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using System.Collections.Generic;
using Brockhaus.PraktikumZeugnisGenerator.Services;

namespace Brockhaus.PraktikumZeugnisGenerator.View.UC
{
    public partial class CriteriaTextSelectionV : UserControl
    {
        private const string KEINE_AUSWAHL = "";
        private bool isExtended = false;
        private List<Criteria> CriteriaList;
        public CriteriaTextSelectionP presenter;
        ViewState viewState;
        Sex sex;
        private int CriteriaIndex;
        MainWindowV View;
        private bool GradeSelectedByUser;
        private bool VariationSelectedByUser;
        public int Position;

        public EventHandler DeleteButtonClicked;

        public CriteriaTextSelectionV(Criteria selectedCriteria, Sex sex, List<Criteria> criteriaList, int criteriaIndex , MainWindowV view, int position)
        {
            InitializeComponent();
            CriteriaList = criteriaList;
            CriteriaIndex = criteriaIndex;
            presenter = new CriteriaTextSelectionP(this, selectedCriteria);
            viewState = ViewState.WaitingForInput;
            this.sex = sex;
            GradeSelectedByUser = false;
            VariationSelectedByUser = false;
            View = view;
            Position = position;
            RefreshView();
        }

        public void RefreshView()
        {
            if (viewState == ViewState.IsRefreshing) return;
            viewState = ViewState.IsRefreshing;
            
            RefreshSelectedGrade();
            RefreshVariations();
            RefreshPredefinedText();
            RefreshBtnExtend();

            viewState = ViewState.WaitingForInput;
        }

        #region Refresh Methoden

        private void RefreshSelectedGrade()
        {
            Criteria curShowedCriteria = presenter.CurShowedCriteria;

            LblCurEvaluationCriteria.Text = curShowedCriteria.Name;
            CbxGrade.Items.Clear();
            foreach (Grade grade in curShowedCriteria.Grades)
            {
                CbxGrade.Items.Add(grade.Name);
            }
            if (!GradeSelectedByUser && CbxGrade.Items.Count > 0)
            {
                presenter.SelectGrade(0);
            }
                if (presenter.SelectedGrade != null)
                {
                    CbxGrade.SelectedItem = presenter.SelectedGrade.Name;
                }
            
        }

        private void RefreshVariations()
        {
            if (presenter.SelectedGrade != null && presenter.SelectedGrade.Variations.Count >0)
            {
                CbxVariation.Enabled = true;
                CbxVariation.Items.Clear();
                foreach (Variation variation in presenter.SelectedGrade.Variations)
                {
                    CbxVariation.Items.Add(variation.Name);
                }
                if (!VariationSelectedByUser && CbxVariation.Items.Count > 0)
                {
                    presenter.SelectVariationByIndex(0);
                }

                if (presenter.SelectedVariation != null)
                {
                    CbxVariation.SelectedItem = presenter.SelectedVariation.Name;
                }
                else
                {
                    CbxVariation.Text = "";
                }
            }
            else
            {
                CbxVariation.Items.Clear();
                CbxVariation.SelectedItem = "";
                CbxVariation.Text = "";
                CbxVariation.Enabled = false;
            }
        }

        private void RefreshPredefinedText()
        {
            if (presenter.SelectedVariation != null)
            {
                string showText = presenter.SelectedVariation.PredifinedText != null ? presenter.SelectedVariation.PredifinedText.Replace("Muster", View.InternDetails.LastName) : "";

                showText = StringEditor.ReplaceSexDependendWordsRegex(View.InternDetails, showText);
                LblPredefinedText.Text = showText;
            }
            else
            {
                LblPredefinedText.Text = KEINE_AUSWAHL;
            }
        }

        private void RefreshBtnExtend()
        {

            if (presenter.SelectedVariation != null && CheckLabelHeightToSmall() )
            {
                BtnExtend.Enabled = true;
            }
            else
            {
                BtnExtend.Enabled = false;
            }
        }

        private bool CheckLabelHeightToSmall()
        {
            Image fakeImage = new Bitmap(1, 1); //Da wir kein Graphics Objekt haben, welches wir für MeasureString brauchen, erstellen wir ein Dummy
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(LblPredefinedText.Text, LblPredefinedText.Font, LblPredefinedText.Width);
            if (extent.Height > LblPredefinedText.Height)
            {
               return true;
            }
            else
            {
                return false;
            }

            
        }

        #endregion

        #region WinForms Control EventHandler

        private void CbxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            GradeSelectedByUser = true;
            VariationSelectedByUser = false;
            presenter.SelectGrade(CbxGrade.SelectedIndex);
        }

        private void CbxVariation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            GradeSelectedByUser = true;
            VariationSelectedByUser = true;
          presenter.SelectVariationByReference(CbxVariation.SelectedItem.ToString());
        }

        private void BtnExtend_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;

            if (!isExtended)
            {
                LblPredefinedText.MaximumSize = new Size(250, 0);
                BtnExtend.Text = @"/\";
            }
            else
            {
                LblPredefinedText.MaximumSize = new Size(250, 70);
                BtnExtend.Text = @"\/";
            }
            isExtended = !isExtended;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked(this, e);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string selectedVar = null;
            if (CbxVariation != null && CbxVariation.SelectedItem != null)
            {
                selectedVar = CbxVariation.SelectedItem.ToString();
            }

            int selectedGrade = CbxGrade.SelectedIndex;
            int selectedVariation = CbxVariation.SelectedIndex;

            CriteriaEditorV criteriaEditor = new CriteriaEditorV(presenter.CurShowedCriteria, CriteriaList, CriteriaIndex,selectedGrade,selectedVariation);
            
            criteriaEditor.ShowDialog();
            
            
            CbxGrade_SelectedIndexChanged(sender, e);

            if(selectedVar != null)
            presenter.SelectVariationByReference(selectedVar);

            Refresh();
           
        }





        private void BtnUp_Click(object sender, EventArgs e)
        {
            View.SwitchElements(presenter.view, Direction.Up);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            View.SwitchElements(presenter.view, Direction.Down);
        }
        #endregion
    }
}
