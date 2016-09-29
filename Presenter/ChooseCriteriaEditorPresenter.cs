using System;
using System.Collections.Generic;
using Brockhaus.Arbeitszeugnisgenerator.View;
using Brockhaus.Arbeitszeugnisgenerator.View.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;

namespace Brockhaus.Arbeitszeugnisgenerator.Presenter
{
    public class ChooseCriteriaEditorPresenter
    {

        private const string NAME_ERR_TITLE = "Fehler";
        private const string NAME_EXISTS_ERR_TEXT = "Der Name ist bereits vorhanden.";
        private const string NAME_EMPTY_ERR_TEXT = "Der Name darf nicht leer sein.";
        public List<Criteria> Criterias;
        public Criteria SelectedCriteria;
        public ChooseCriteriaEditorView view;

        public ChooseCriteriaEditorPresenter(ChooseCriteriaEditorView view, List<Criteria> criteriaList)
        {
            this.view = view;
            Criterias = criteriaList;
        }

        public void AddCriteria(string name)
        {
            try
            {
                if (name == "") throw new ArgumentException(NAME_EMPTY_ERR_TEXT);
                foreach (Criteria criteria in Criterias)
                {
                    if (name == criteria.Name) throw new ArgumentException(NAME_EXISTS_ERR_TEXT);
                }
                Criteria newCrit = new Criteria(name);
                Criterias.Add(newCrit);
                SelectedCriteria = newCrit;
                view.RefreshView();
            }
            catch (ArgumentException exception)
            {
                MessageDialog msg = new MessageDialog(NAME_ERR_TITLE, exception.Message);
                msg.ShowDialog();
                throw new ArgumentException(exception.Message);
            }
        }

        public void RemoveCriteria(int removeIndex)
        {
            if (removeIndex < 0 || removeIndex >= Criterias.Count) throw new ArgumentException();

            Criterias.RemoveAt(removeIndex);
            view.RefreshView();
        }

        public void SelectCriteria(int selectIndex)
        {
            if (selectIndex == -1)
            {
                SelectedCriteria = null;
                return;
            }
            if (selectIndex < 0 || selectIndex >= Criterias.Count)
            {
                throw new IndexOutOfRangeException();
            }
            SelectedCriteria = Criterias[selectIndex];
            view.RefreshView();
        }
    }
}
