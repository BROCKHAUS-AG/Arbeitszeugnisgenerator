using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class Grade
    {
        public string Name { get; set; }
        public List<Variation> Variations { get; set; }

        public Grade() : this(null)
        {

        }

        public Grade(string name)
        {
            Variations = new List<Variation>();
            Name = name;
        }

        internal Grade CreateBackup()
        {
            Grade newGrade = new Grade(Name);
            List<Variation> newVariations = new List<Variation>();
            foreach (Variation var in Variations)
            {
                newVariations.Add(var.CreateBackup());
            }
            newGrade.Variations = newVariations;
            return newGrade;
        }
    }
}
