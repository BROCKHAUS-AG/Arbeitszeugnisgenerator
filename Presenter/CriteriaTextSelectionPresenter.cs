using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.Presenter
{
    public class CriteriaTextSelectionPresenter
    {
        private readonly Criteria curShowedCriteria;
        private Grade selectedGrade;
        private Variation selectedVariation;

        public CriteriaTextSelectionView view;

        public Criteria CurShowedCriteria
        {
            get
            {
                return curShowedCriteria;
            }
        }
        public Grade SelectedGrade
        {
            get
            {
                return selectedGrade;
            }
            set
            {
                if (CurShowedCriteria.Grades.Contains(value))
                {
                    selectedGrade = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public Variation SelectedVariation
        {
            get
            {
                return selectedVariation;
            }
            set
            {
                if ( value == null || SelectedGrade != null && SelectedGrade.Variations.Contains(value))
                {
                    selectedVariation = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public CriteriaTextSelectionPresenter(CriteriaTextSelectionView view, Criteria shownCriteria)
        {
            this.view = view;
            curShowedCriteria = shownCriteria;
        }

        public CriteriaTextSelectionPresenter(CriteriaTextSelectionView view, Criteria shownCriteria, List<Guid> savedVariations):this(view, shownCriteria)
        {
            SelectVariationBySavedVariations(savedVariations);
        }

        public void SelectGrade(int selectIndex) {
            if (selectIndex == -1) return;
            if (selectIndex < 0 || selectIndex >= CurShowedCriteria.Grades.Length)
            {
                throw new IndexOutOfRangeException("Der Index liegt nicht in den auswählbaren Noten(Grade)");
            }
            SelectedGrade = CurShowedCriteria.Grades[selectIndex];
            SelectedVariation = selectedGrade.Variations.Count > 0 ? selectedGrade.Variations[0] : null;
            view.RefreshView();
        }


        public void SelectVariationByIndex(int selectIndex )
        {
            if (SelectedGrade == null)
            {
                throw new ArgumentException("Wenn diese Methode aufgerufen wird, kann die ausgewählte Note(Grade) nicht null sein");
            }
            if (selectIndex < 0 || selectIndex >= SelectedGrade.Variations.Count)
            {
                throw new IndexOutOfRangeException("Der Index liegt nicht in den auswählbaren Varianten(Variation)");
            }
            SelectedVariation = SelectedGrade.Variations[selectIndex];
            view.RefreshView();
        }

        public void SelectVariationByReference(string variation)
        {
            SelectedVariation = selectedGrade.Variations.Find(c => c.Name == variation);
            view.RefreshView();
        }

        private void SelectVariationBySavedVariations(List<Guid> savedVariations)
        {
            SelectedVariation = null;
            Variation tempVariation;
            foreach(Guid variationID in savedVariations)
            {
                foreach(Grade usedGrades in CurShowedCriteria.Grades)
                {
                    tempVariation = usedGrades.Variations.Find(variation => variation.guid == variationID);
                    if (tempVariation != null)
                    {
                        SelectedGrade = usedGrades;
                        SelectedVariation = tempVariation;
                        return;
                    }
                }
            }
        }
    }
}
