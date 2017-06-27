using Brockhaus.PraktikumZeugnisGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brockhaus.Arbeitszeugnisgenerator.Model
{
    public class GuidList : List<GuidId>
    {
        public int SortDelegate(GuidId a, GuidId b)
        {
            return a.Id - b.Id;
        }
    }
}
