using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_Rendez_vous_Hopital
{
    public partial class Afficher_Tout : Form
    {
        public Afficher_Tout()
        {
            InitializeComponent();
        }

        private void Afficher_Tout_Load(object sender, EventArgs e)
        {
            groupBox1.Select();
            radioButton1.Checked = false; 
            radioButton2.Checked = false; 
            radioButton3.Checked = false; 


            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from Medecin";
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dataGridView1.DataSource = t;
                dr.Close();
                Program.con.Close();
            }
            else
            {
                dataGridView1.DataSource = null;
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from Patient";
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dataGridView1.DataSource = t;
                dr.Close();
                Program.con.Close();
            }
            else
            {
                dataGridView1.DataSource = null;
            }
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from rdv";
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dataGridView1.DataSource = t;
                dr.Close();
                Program.con.Close();
            }
            else
            {
                dataGridView1.DataSource = null;
            }
            
        }
    }
}
