using System;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class Criteria
    {
        public string Name { get; set; }
        public Grade[] Grades { get; set; }
        public Guid guid { get; set; }

        public Criteria() : this(null)
        {
        }

        public Criteria(string name) {
            Grades = new Grade[6];
            Name = name;
            Grades[0] = new Grade("Sehr Gut");
            Grades[1] = new Grade("Gut");
            Grades[2] = new Grade("Befriedigend");
            Grades[3] = new Grade("Ausreichend");
            Grades[4] = new Grade("Mangelhaft");
            Grades[5] = new Grade("Ungenügend");
            guid = Guid.NewGuid();
        }

        public List<Grade> GetUsedGrades()
        {
            List<Grade> tempList = new List<Grade>();
            foreach(Grade grade in new List<Grade>(Grades))
            {
                if(grade.Variations.Count > 0)
                {
                    tempList.Add(grade);
                }
            }
            return tempList;
        }

        internal Criteria CreateBackup()
        {
            Criteria newCriteria = new Criteria(Name);

            for (int i = 0; i < Grades.Length; i++)
            {
                newCriteria.Grades[i] = Grades[i].CreateBackup();
            }

            return newCriteria;
        }
    }
}
