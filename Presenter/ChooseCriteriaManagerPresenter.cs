using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using System;
using System.Collections.Generic;
using Brockhaus.PraktikumZeugnisGenerator.Dialogs;

namespace Brockhaus.PraktikumZeugnisGenerator.Presenter
{
    public class ChooseCriteriaManagerPresenter
    {
        private const string NAME_ERR_TITLE = "Fehler";
        private const string NAME_ERR_TEXT = "Namen dürfen nicht doppelt vergeben werden";
        public List<Criteria> Criterias;
        public Criteria SelectedCriteria;
        public ChooseCriteriaManagerView view;

        public ChooseCriteriaManagerPresenter(ChooseCriteriaManagerView view, List<Criteria> criteriaList)
        {
            this.view = view;
            Criterias = criteriaList;
        }

        public void AddCriteria(string name)
        {
            try
            {
                if (name == "") throw new ArgumentException();
                foreach (Criteria criteria in Criterias)
                {
                    if (name == criteria.Name) throw new ArgumentException();
                }
                Criteria newCrit = new Criteria(name);
                Criterias.Add(newCrit);
                SelectedCriteria = newCrit;
                view.RefreshView();
            }
            catch(ArgumentException)
            {
                MessageDialog msg = new MessageDialog(NAME_ERR_TITLE, NAME_ERR_TEXT);
                   msg.ShowDialog();
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
