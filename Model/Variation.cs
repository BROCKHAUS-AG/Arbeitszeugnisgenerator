using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class Variation
    {
        public string Name { get; set; }
        public string PredifinedText { get; set; }

        public Sex sex { get; set; }

        public Variation() : this(null,Sex.Male)
        {
        }
        public Variation(string name) : this(name, Sex.Male)
        {
        }

        public Variation(string name, Sex sex)
        {
            Name = name;
            this.sex = sex;
        }

        internal Variation CreateBackup()
        {
            Variation newVariation = new Variation();
            newVariation.Name = this.Name;
            if (PredifinedText != null)
            {
                newVariation.PredifinedText = this.PredifinedText;
            }
            else {
                newVariation.PredifinedText = null;
            }
            newVariation.sex = this.sex;
            return newVariation;
        }
    }
}
