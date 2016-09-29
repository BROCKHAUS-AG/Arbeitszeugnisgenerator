using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brockhaus.PraktikumZeugnisGenerator.View;
using Brockhaus.PraktikumZeugnisGenerator.View.Forms;
using Brockhaus.PraktikumZeugnisGenerator.Services;

namespace Brockhaus.PraktikumZeugnisGenerator
{
    public static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindowView(CriteriasWrapper.Instance.Criterias));
            CriteriasWrapper.Instance.SaveCriteriaWrapper();
        }
    }
}
