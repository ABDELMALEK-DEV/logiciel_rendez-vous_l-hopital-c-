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
    public partial class Gestion_des_rdv : Form
    {
        public Gestion_des_rdv()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now; 
            maskedTextBox1.Text = ""; 
            comboBox2.SelectedIndex = -1; 
            textBox2.Text = ""; 
            textBox3.Text = ""; 
            comboBox2.SelectedIndex = -1; 
            textBox1.Text = ""; 
            radioButton1.Checked = false; 
            radioButton2.Checked = false;
                                    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Gestion_des_rdv_Load(object sender, EventArgs e)
        {
            Program.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.con;
            cmd.CommandText = "select CodeMedecin from Medecin";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox2.Items.Add(dr[0].ToString());

            }
            dr.Close();
            cmd.CommandText = "select * from Patient";
            dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            dr.Close();
            Program.con.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull == false)
                MessageBox.Show("Heure Invalide!!", "champ Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Medecin Invalide!!", "champ Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Patient Invalide!!", "champ Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = String.Format("insert into rdv values('{0}','{1}','{2}','{3}')", dateTimePicker1.Value.ToShortDateString(), maskedTextBox1.Text, comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString());
                int r = cmd.ExecuteNonQuery(); 
                if (r != 0)
                {
                    MessageBox.Show("RDV bien ajouté", "ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();

                }

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from Patient where CodePatient='" + comboBox1.Text + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read(); 
                textBox1.Text = dr[1].ToString();
                if (dr[4].ToString() == "M")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                dr.Close();
                Program.con.Close();

            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from Medecin where CodeMedecin='" + comboBox2.Text + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();  
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[4].ToString();
                dr.Close();
                Program.con.Close();
            }
            
        }
    }
}
