using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Brockhaus.PraktikumZeugnisGenerator.Model;

namespace Brockhaus.PraktikumZeugnisGenerator.Services
{
    [Serializable]
    public class CriteriasWrapper
    {
        private static CriteriasWrapper criteriasWrapper;

        public List<Criteria> Criterias;

        public static CriteriasWrapper Instance
        {
            get
            {
                if (criteriasWrapper == null)
                {
                    criteriasWrapper = LoadCrieriasWrapper();
                    if (criteriasWrapper == null)
                    {
                        criteriasWrapper = new CriteriasWrapper();
                    }
                }
                return criteriasWrapper;
            }
        }

        private CriteriasWrapper()
        {
            Criterias = new List<Criteria>();
        }

        #region Serializer und Deserializer

        public static CriteriasWrapper LoadCrieriasWrapper()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CriteriasWrapper));
            CriteriasWrapper loadedCriteriasWrapper = null;
            try
            {
                using (Stream fileStream = new FileStream(@"files\CriteriasWrapper.xml", FileMode.Open))
                {
                    loadedCriteriasWrapper = (CriteriasWrapper)serializer.Deserialize(fileStream);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return loadedCriteriasWrapper;
        }

        public void SaveCriteriaWrapper()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CriteriasWrapper));
            using (Stream fileStream = new FileStream(@"Files\CriteriasWrapper.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, this);
            }
        }

        #endregion
    }
}
