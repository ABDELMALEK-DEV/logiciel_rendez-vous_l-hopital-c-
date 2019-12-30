using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_Rendez_vous_Hopital
{
    public partial class Gestion_des_Medecins : Form
    {
        public Gestion_des_Medecins()
        {
            InitializeComponent();
        }

        private bool rechercher_medecin()
        {
            bool p = false;
            Program.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.con;
            cmd.CommandText = "select * from Medecin where CodeMedecin='" + textBox1.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                p = true;
            }
            dr.Close();
            Program.con.Close();
            return p;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Champ Code Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (rechercher_medecin() == false)
                {
                    textBox2.Text = "";
                    maskedTextBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    comboBox1.SelectedIndex = -1;
                    MessageBox.Show("Medecin Introuvable", "Introuvable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                else
                {
                    Program.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Program.con;
                    cmd.CommandText = "select * from Medecin where CodeMedecin='" + textBox1.Text + "'";
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    textBox2.Text = dr[1].ToString();
                    maskedTextBox1.Text = dr[2].ToString();
                    dateTimePicker1.Value = DateTime.Parse(dr[3].ToString());
                    comboBox1.SelectedItem = dr[4].ToString();
                    dr.Close();
                    Program.con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Champ Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (maskedTextBox1.MaskFull == false)
            {
                MessageBox.Show("Numero de telephone invalide!!", "Champ invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Specialité invalide!!", "Chmap Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rechercher_medecin() == true)
            {
                MessageBox.Show("Medecin existe deja", "Existant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = string.Format( "insert into Medecin values('{0}','{1}','{2}','{3}','{4}')", textBox1.Text,textBox2.Text,maskedTextBox1.Text,dateTimePicker1.Value.ToShortDateString(),comboBox1.SelectedItem.ToString());
                int r = cmd.ExecuteNonQuery();
                if (r != 0)
                {
                    MessageBox.Show("Medecin bien ajouter", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();
                }
               
            }
        }

        private void Gestion_des_Medecins_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Champ Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (maskedTextBox1.MaskFull == false)
            {
                MessageBox.Show("Numero de telephone invalide!!", "Champ invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Specialité invalide!!", "Chmap Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rechercher_medecin() == false)
            {
                MessageBox.Show("Medecin inexistant", "Existant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = string.Format("Update Medecin set NomMedecin='{0}',TelMedecin='{1}',DateEmbauche='{2}',SpecialiteMedecin='{3}',where CodeMedecin='{4}'", textBox2.Text, maskedTextBox1.Text, dateTimePicker1.Value.ToShortDateString(), comboBox1.SelectedItem.ToString(), textBox1.Text);
                int r = cmd.ExecuteNonQuery();
                if (r != 0)
                {
                    MessageBox.Show("Medecin bien Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Champ Code Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
            else if (rechercher_medecin() == false)
            {
                MessageBox.Show("Medecin inexistant", "Existant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = string.Format("delete from Medecin where CodeMedecin='{0}'", textBox1.Text);
                int r = cmd.ExecuteNonQuery();
                if (r != 0)
                {
                    MessageBox.Show("Medecin bien Supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();
                    button3.PerformClick();
                }

            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
