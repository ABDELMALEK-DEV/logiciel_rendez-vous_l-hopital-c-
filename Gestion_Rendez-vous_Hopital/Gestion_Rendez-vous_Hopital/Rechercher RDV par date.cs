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
    public partial class Rechercher_RDV_par_date : Form
    {
        public Rechercher_RDV_par_date()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = ""; 
            dataGridView1.DataSource = null; 
            textBox4.Text = ""; 
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false; 
            textBox2.Text = ""; 
            textBox3.Text = ""; 
                              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull == false)
            {
                MessageBox.Show("Date Invalide!!", "Date Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from rdv where DateRDV='" + maskedTextBox1.Text + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = t;
                dr.Close();
                Program.con.Close();
            }
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1_SelectionChanged(sender, e); 
            }

        }

        private void Rechercher_RDV_par_date_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Program.con.State != ConnectionState.Open) 
            {
                string codem, codep;
                codem = dataGridView1.CurrentRow.Cells[3].Value.ToString(); 
                codep = dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select NomMedecin,SpecialiteMedecin from Medecin where CodeMedecin='" + codem + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox2.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
                dr.Close();
                cmd.CommandText = "select * from Patient where CodePatient='" + codep + "'";
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox4.Text = dr[1].ToString();
                textBox5.Text = dr[3].ToString();
                if (dr[4].ToString() == "M")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                dr.Close();

                Program.con.Close();
            }
            
        }
    }
}
