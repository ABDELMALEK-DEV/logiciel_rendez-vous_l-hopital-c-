using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_Rendez_vous_Hopital
{
    static class Program
    {
        public static SqlConnection con = new SqlConnection("Data Source=ABDELMALEK-PC\SQLEXPRESS; initial catalog=Gestion_rendez_vous; integrated security=true");

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
