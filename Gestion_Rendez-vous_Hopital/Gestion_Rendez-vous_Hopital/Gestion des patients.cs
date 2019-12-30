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
    public partial class Gestion_des_patients : Form
    {
        public Gestion_des_patients()
        {
            InitializeComponent();
        }
        private bool rechercher_patient() 
        {
            bool b = false;
            Program.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.con;
            cmd.CommandText = "select * from Patient where CodePatient='" + textBox1.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                b = true;

            dr.Close();
            Program.con.Close();
            return b;
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            listBox1.Text = ""; 
            dateTimePicker1.Value = DateTime.Now; 
            radioButton1.Checked = false; 
            radioButton2.Checked = false; 
            textBox1.Focus(); 
                              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
                MessageBox.Show("Champ Code Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (rechercher_patient() == false)
            {

                textBox2.Text = "";
                listBox1.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                MessageBox.Show("Patient Introuvable", "Introuvable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from Patient where CodePatient='" + textBox1.Text + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();  
                textBox2.Text = dr[1].ToString();
                listBox1.Text = dr[2].ToString();
                dateTimePicker1.Value = DateTime.Parse(dr[3].ToString());
                if (dr[4].ToString() == "M")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                dr.Close();
                Program.con.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || listBox1.Text == "")
            {
                MessageBox.Show("Champ Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Sexe Obligatoire!!", "Sexe obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (rechercher_patient() == true)
            {

                MessageBox.Show("Patient existe déja", "existant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                string s;
                if (radioButton1.Checked)
                    s = "M";
                else
                    s = "F";
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = String.Format("insert into Patient values('{0}','{1}','{2}','{3}','{4}')", textBox1.Text, textBox2.Text, listBox1.Text, dateTimePicker1.Value.ToShortDateString(), s);
                int r = cmd.ExecuteNonQuery(); 
                if (r != 0)
                {
                    MessageBox.Show("Patient bien ajouté", "ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();

                }

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || listBox1.Text == "")
            {
                MessageBox.Show("Champ Vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Sexe Obligatoire!!", "Sexe Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (rechercher_patient() == false)
            {

                MessageBox.Show("Patient inexistant", "inexistant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                string s;
                if (radioButton1.Checked)
                    s = "M";
                else
                    s = "F";
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = String.Format("update Patient set NomPatient='{0}',AdressePatient='{1}',DateNaissance='{2}',SexePatient='{3}' where CodePatient='{4}'", textBox2.Text, listBox1.Text, dateTimePicker1.Value.ToShortDateString(), s, textBox1.Text);
                int r = cmd.ExecuteNonQuery();
                if (r != 0)
                {
                    MessageBox.Show("Patient bien Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();

                }

            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Champ Code vide!!", "Champ Vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (rechercher_patient() == false)
            {

                MessageBox.Show("Patient inexistant", "inexistant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox2.SelectAll();
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = String.Format("delete from Patient where CodePatient='{0}'", textBox1.Text);
                int r = cmd.ExecuteNonQuery(); 
                if (r != 0)
                {
                    MessageBox.Show("Patient bien supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();
                    button1.PerformClick();

                    
                }
            }
}

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Gestion_des_patients_Load(object sender, EventArgs e)
        {

        }