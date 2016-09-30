using Brockhaus.PraktikumZeugnisGenerator.Dialogs;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Presenter
{
    public class CriteriaEditorPresenter
    {
        public CriteriaEditorView view;

        public Criteria CurShowedCriteria;
        public Grade SelectedGrade;
        public Variation SelectedVariation;

        private Criteria CriteriaBackup;
        private Grade SelectedGradeBackup;
        private Variation SelectedVariationBackup;
        private ViewState Viewstate = ViewState.WaitingForInput;



        public string PredifinedText
        {
            set
            {
                if (SelectedVariation == null)
                {
                    throw new ArgumentException("Wenn diese Methode aufgerufen wird, kann die ausgewählte Varianten(Variation) nicht null sein.");
                }
                SelectedVariation.PredifinedText = value;
                view.RefreshView();
            }
            get
            {
                return SelectedVariation.PredifinedText;
            }
        }

        public string CriteriaName
        {
            get
            {
                return CurShowedCriteria.Name;
            }
            set
            {
                if (!(value == ""))
                {
                    CurShowedCriteria.Name = value;
                }
            }
        }

        public CriteriaEditorPresenter(CriteriaEditorView view, Criteria shownCriteria)
        {
            CurShowedCriteria = shownCriteria;
            CriteriaBackup = shownCriteria.CreateBackup();
            this.view = view;
        }

        public CriteriaEditorPresenter(CriteriaEditorView view, Criteria shownCriteria, int preselectedGrade, int preselectedVariation) :
            this(view, shownCriteria)
        {
            Viewstate = ViewState.IsRefreshing;
            if (preselectedGrade != -1)
            {
                SelectGrade(preselectedGrade);
                if (preselectedVariation != -1 && !(preselectedVariation >= SelectedGrade.Variations.Count))
                {
                    SelectVariation(preselectedVariation);
                }
            }
            Viewstate = ViewState.WaitingForInput;
        }

        public void SelectGrade(int selectIndex)
        {
            if (selectIndex == -1)
            {
                SelectedGrade = null;
                SelectedGradeBackup = null;
            }
            else if (selectIndex < 0 || selectIndex >= CurShowedCriteria.Grades.Length)
            {
                throw new IndexOutOfRangeException("Der Index liegt nicht in den auswählbaren Noten(Grade)");
            }
            else
            {
                SelectedGrade = CurShowedCriteria.Grades[selectIndex];
                SelectedGradeBackup = CurShowedCriteria.Grades[selectIndex].CreateBackup();
            }
            SelectedVariation = null;
            if (Viewstate != ViewState.IsRefreshing)
                view.RefreshView();
        }

        public void SelectVariation(int selectIndex)
        {
            if (SelectedGrade == null)
            {
                throw new ArgumentException("Wenn diese Methode aufgerufen wird, kann die ausgewählte Note(Grade) nicht null sein.");
            }
            if (selectIndex == -1)
            {
                SelectedVariation = null;
                SelectedVariationBackup = null;
            }
            else if (selectIndex < 0 || selectIndex >= SelectedGrade.Variations.Count)
            {
                throw new IndexOutOfRangeException("Der Index liegt nicht in den auswählbaren Varianten(Variation).");
            }
            else
            {
                SelectedVariation = SelectedGrade.Variations[selectIndex];
                SelectedVariationBackup = SelectedGrade.Variations[selectIndex].CreateBackup(); ;
            }
            if (Viewstate != ViewState.IsRefreshing)
                view.RefreshView();
        }

        public void AddVariation(string name)
        {
            if (SelectedGrade == null) return;
            if (SelectedGrade.Variations.FindAll(variation => variation.Name == name).Count == 0)
            {
                SelectedGrade.Variations.Add(new Variation(name));

                view.RefreshView();
                return;
            }
            view.InvalidNameChange();
        }

        public void RemoveVariation(int index)
        {
            SelectedGrade.Variations.RemoveAt(index);
            view.RefreshView();
        }

        public void RenameVariation(string name)
        {
            if (name == "") return;
            if (SelectedGrade.Variations.FindAll(v => v.Name == name && v != SelectedVariation).Count == 0)
            {
                SelectedVariation.Name = name;

                view.RefreshView();
                return;
            }
            else
            {
                view.InvalidNameChange();
            }
        }

        public void RestoreBackup()
        {
            CurShowedCriteria.Grades = CriteriaBackup.Grades;
            CurShowedCriteria.Name = CriteriaBackup.Name;
            if (SelectedGrade != null && SelectedGradeBackup != null)
            {
                SelectedGrade.Name = SelectedGradeBackup.Name;
                SelectedGrade.Variations = SelectedGradeBackup.Variations;
            }
            if (SelectedVariation != null && SelectedVariationBackup != null)
            {
                SelectedVariation.Name = SelectedVariationBackup.Name;
                SelectedVariation.PredifinedText = SelectedVariationBackup.PredifinedText;
            }
        }

        public void UpdateBackup()
        {
            CriteriaBackup = CurShowedCriteria.CreateBackup();
        }

    }
}
