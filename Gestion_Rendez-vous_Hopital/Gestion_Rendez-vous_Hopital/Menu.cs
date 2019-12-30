using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Rendez_vous_Hopital
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void gestionDesMedecinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestion_des_Medecins f = new Gestion_des_Medecins();
            f.MdiParent=this;
            f.Show();
        }

        private void gestionDesPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestion_des_patients f = new Gestion_des_patients();
            f.MdiParent = this;
            f.Show();
        }

        private void gestionDesRDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestion_des_rdv f = new Gestion_des_rdv();
            f.MdiParent = this;
            f.Show();
        }

        private void afficherToutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Afficher_Tout f = new Afficher_Tout();
            f.MdiParent = this;
            f.Show();
        }

        private void rechercherRDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rechercher_RDV_par_date f = new Rechercher_RDV_par_date();
            f.MdiParent = this;
            f.Show();
        }

        private void afficherLesRDVDunPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Afficher_les_EDV_d_un_patient f = new Afficher_les_EDV_d_un_patient();
            f.MdiParent = this;
            f.Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
