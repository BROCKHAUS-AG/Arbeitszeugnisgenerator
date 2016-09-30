using System;

namespace Brockhaus.PraktikumZeugnisGenerator.Model
{
    public class Variation
    {
        public string Name { get; set; }
        public string PredifinedText { get; set; }
        public Guid guid { get; set; }
        public Variation() : this(null)
        {
        }
        public Variation(string name) 
        {
            this.Name = name;
            guid = Guid.NewGuid();
        }
        
        internal Variation CreateBackup()
        {
            Variation newVariation = new Variation();
            newVariation.Name = this.Name;
            if (PredifinedText != null)
            {
                newVariation.PredifinedText = (string)this.PredifinedText.Clone();
            }
            else
            {
                newVariation.PredifinedText = null;
            }
            return newVariation;
        }
    }
}
