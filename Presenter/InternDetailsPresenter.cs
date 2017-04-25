using Brockhaus.PraktikumZeugnisGenerator.Model;
using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Presenter
{
    public class InternDetailsPresenter
    {
        public InternDetails CurShowedInternDetails { get; set; }

        public bool savedChanges = true;
        public bool emptyFile = true;

        private InternDetailsV view;

        public Sex Sex
        {
            set
            {
                if (CurShowedInternDetails.Sex != value)
                {
                    CurShowedInternDetails.Sex = value;
                    savedChanges = false;
                }
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
                if (CurShowedInternDetails.FirstName != value)
                {
                    CurShowedInternDetails.FirstName = value;
                    savedChanges = false;
                }
                view.RefreshView();
            }
        }
        public string LastName
        {
            set
            {
                if (CurShowedInternDetails.LastName != value)
                {
                    CurShowedInternDetails.LastName = value;
                    savedChanges = false;
                }
                view.RefreshView();
            }
        }
        public DateTime DateOfBirth
        {
            set
            {
                if (CurShowedInternDetails.DateOfBirth != value)
                {
                    CurShowedInternDetails.DateOfBirth = value;
                    savedChanges = false;
                    
                }
                view.RefreshView();
            }
        }
        public string Department
        {
            set
            {
                if (CurShowedInternDetails.Department != value)
                {
                    CurShowedInternDetails.Department = value;
                    savedChanges = false;
                    
                }
                view.RefreshView();
            }
        }
        public DateTime FromDate
        {
            set
            {
                if (CurShowedInternDetails.FromDate != value)
                {
                    CurShowedInternDetails.FromDate = value;
                    savedChanges = false;

                }
                view.RefreshView();
            }
        }
        public DateTime UntilDate
        {
            set
            {
                if (CurShowedInternDetails.UntilDate != value)
                {
                    CurShowedInternDetails.UntilDate = value;
                    savedChanges = false;
                    
                }
                view.RefreshView();
            }
        }
        public string Exercises
        {
            set
            {
                if (CurShowedInternDetails.Exercises != value)
                {
                    CurShowedInternDetails.Exercises = value;
                    savedChanges = false;
                    
                }
                view.RefreshView();
            }
        }
        public string PracticalExperience
        {
            set
            {
                if (CurShowedInternDetails.PracitcalExperience != value)
                {
                    CurShowedInternDetails.PracitcalExperience = value;
                    savedChanges = false;
                   
                }
                view.RefreshView();
            }
        }

        public InternDetailsPresenter(InternDetailsV view)
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
            //List<Criteria> CriteriaList = CurShowedInternDetails.Criterias;

            view.RefreshView();
            emptyFile = false;
            savedChanges = true;
        }


    }
}
