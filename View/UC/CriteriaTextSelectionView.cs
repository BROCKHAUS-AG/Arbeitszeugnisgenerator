using System;
using System.Drawing;
using System.Windows.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Presenter;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Services;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.View.UC
{
    public partial class CriteriaTextSelectionView : UserControl
    {
        private const string KEINE_AUSWAHL = "";
        private bool isNotExtended = false;
        public CriteriaTextSelectionPresenter presenter;
        ViewState viewState;
        Sex sex;
        MainWindowView View;
        private bool GradeSelectedByUser;
        private bool VariationSelectedByUser;
        public EventHandler DeleteButtonClicked;

        public CriteriaTextSelectionView(Criteria selectedCriteria, Sex sex, MainWindowView view, int position, List<Guid> savedVariations)
        {
            InitializeComponent();

            if(savedVariations == null)
            {
                presenter = new CriteriaTextSelectionPresenter(this, selectedCriteria);
                GradeSelectedByUser = false;
                VariationSelectedByUser = false;
            }
            else
            {
                presenter = new CriteriaTextSelectionPresenter(this, selectedCriteria, savedVariations);
                GradeSelectedByUser = true;
                VariationSelectedByUser = true;
            }

            viewState = ViewState.WaitingForInput;
            this.sex = sex;
            View = view;
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
            foreach (Grade grade in curShowedCriteria.GetUsedGrades())
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
                string showText = presenter.SelectedVariation.PredifinedText != null ? presenter.SelectedVariation.PredifinedText.Replace("<<Name>>", View.InternDetails.LastName) : "";
                showText = StringEditor.ReplaceWordsBasedOnGender(View.InternDetails, showText);
                showText = StringEditor.ReplaceDatesAndNames(View.InternDetails, showText);
                LblPredefinedText.Text = showText;
            }
            else
            {
                LblPredefinedText.Text = KEINE_AUSWAHL;
            }
        }

        private void RefreshBtnExtend()
        {

            if ((presenter.SelectedVariation != null && CheckLabelHeightToSmall()))
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
            if (extent.Height > LblPredefinedText.Height-15)
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
            if(presenter.SelectedVariation != null)
            {
                View.InternDetails.SavedVariations.Remove(presenter.SelectedVariation.guid);
            }
            presenter.SelectGrade(CbxGrade.SelectedIndex);

            if(presenter.SelectedVariation != null)
            {
                View.InternDetails.SavedVariations.Add(presenter.SelectedVariation.guid);
            }
        }

        private void CbxVariation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            GradeSelectedByUser = true;
            VariationSelectedByUser = true;
            if (presenter.SelectedVariation != null)
            {
                View.InternDetails.SavedVariations.Remove(presenter.SelectedVariation.guid);
            }
            presenter.SelectVariationByReference(CbxVariation.SelectedItem.ToString());
            View.InternDetails.SavedVariations.Add(presenter.SelectedVariation.guid);

            //reset extended labels
            LblPredefinedText.MaximumSize = new Size(250, 70);
            isNotExtended = false;
            BtnExtend.Text = @"\/";
            if (CheckLabelHeightToSmall())
            {
                BtnExtend.Enabled = true;
            }
        }


        private void BtnExtend_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing)return;
        

            if (!isNotExtended)
            {
                LblPredefinedText.MaximumSize = new Size(250, 0);
                BtnExtend.Text = @"/\";
            }
            else
            {
                LblPredefinedText.MaximumSize = new Size(250, 70);
                BtnExtend.Text = @"\/";
            }
            isNotExtended = !isNotExtended;
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

            CriteriaEditorView criteriaEditor = new CriteriaEditorView(presenter.CurShowedCriteria,selectedGrade,selectedVariation);
            
            criteriaEditor.ShowDialog();
            
            
            CbxGrade_SelectedIndexChanged(sender, e);

            if(selectedVar != null)
            presenter.SelectVariationByReference(selectedVar);

            Refresh();
           
        }

        private void CbxGrade_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void CbxVariation_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }




        private void BtnUp_Click(object sender, EventArgs e)
        {
            View.SwitchElements(this, Direction.Up);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            View.SwitchElements(this, Direction.Down);
        }
        #endregion
    }
}
