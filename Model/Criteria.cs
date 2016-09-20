using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class Criteria
    {
        Guid guid = new Guid();

        public string Name { get; set; }
        public Grade[] Grades { get; set; }

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
