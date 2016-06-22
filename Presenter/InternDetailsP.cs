using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Presenter
{
    public class InternDetailsP //Presenter
    {
        private InternDetailsV view;
        public InternDetails CurShowedInternDetails { get; set; }

        public Sex Sex
        {
            set
            {
                CurShowedInternDetails.Sex = value;
                savedChanges = false;
                view.RefreshView();
            }
            get
            {
                return CurShowedInternDetails.Sex;
            }
        }
        public string FirstName
        {
            set
            {
                CurShowedInternDetails.FirstName = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public string LastName
        {
            set
            {
                CurShowedInternDetails.LastName = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public DateTime DateOfBirth
        {
            set
            {
                CurShowedInternDetails.DateOfBirth = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public string Department
        {
            set
            {
                CurShowedInternDetails.Department = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public DateTime FromDate
        {
            set
            {
                CurShowedInternDetails.FromDate = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public DateTime UntilDate
        {
            set
            {
                CurShowedInternDetails.UntilDate = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public string Exercises
        {
            set
            {
                CurShowedInternDetails.Exercises = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public string PracticalExperience
        {
            set
            {
                CurShowedInternDetails.PracitcalExperience = value;
                savedChanges = false;
                view.RefreshView();
            }
        }
        public bool savedChanges = true;
        public bool emptyFile = true;

        public InternDetailsP(InternDetailsV view)
        {
            this.view = view;
            CurShowedInternDetails = new InternDetails();
        }

        public void SaveInternDetails(string savePath)
        {
            CurShowedInternDetails.Serialize(savePath);
            emptyFile = false;
            savedChanges = true;
        }

        public void LoadInternDetails(string loadPath)
        {
            CurShowedInternDetails = InternDetails.Deserialize(loadPath);
           
            view.RefreshView();
            emptyFile = false;
            savedChanges = true;
        }


    }
}
