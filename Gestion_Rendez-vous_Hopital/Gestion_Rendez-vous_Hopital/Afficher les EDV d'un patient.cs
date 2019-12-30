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
    public partial class Afficher_les_EDV_d_un_patient : Form
    {
        public Afficher_les_EDV_d_un_patient()
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

   
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; 
            textBox2.Text = ""; 
            textBox3.Text = ""; 
            textBox4.Text = ""; 
            radioButton1.Checked = false; 
            radioButton2.Checked = false; 
            dataGridView1.DataSource = null; 
            textBox5.Text = ""; 
            dateTimePicker1.Value = DateTime.Now; 
            maskedTextBox1.Text = ""; 
            comboBox1.SelectedIndex = -1; 
                                           
        }

        private void Afficher_les_EDV_d_un_patient_Load(object sender, EventArgs e)
        {
            Program.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.con;
            cmd.CommandText = "select CodeMedecin from Medecin";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            dr.Close();
            Program.con.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") 
                MessageBox.Show("Champ Code vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (rechercher_patient() == false)
            {

                textBox2.Text = ""; 
                textBox4.Text = "";
                textBox3.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                MessageBox.Show("Patient introuvable", "introuvable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.SelectAll();
                dataGridView1.DataSource = null;

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
                textBox4.Text = dr[2].ToString();
                textBox3.Text = DateTime.Parse(dr[3].ToString()).ToShortDateString(); ;
                if (dr[4].ToString() == "M")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                dr.Close();
                cmd.CommandText = "select NumeroRDV,DateRDV,HeureRDV,CodeMedecin from rdv where CodePatient='" + textBox1.Text + "' order by DateRDV";
                dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = t;
                dr.Close();
                Program.con.Close();
            }
            if (dataGridView1.Rows.Count != 0)

                dataGridView1_SelectionChanged(sender, e);

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3) 
            {
                string codem = dataGridView1.CurrentCell.Value.ToString(); 
                Gestion_des_Medecins f = new Gestion_des_Medecins();
                f.Show();
                
                f.textBox1.Text = codem; 
                f.button2.PerformClick();
               
                
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (Program.con.State != ConnectionState.Open && dataGridView1.Rows.Count != 0)
            {
                string coderdv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = "select * from rdv where NumeroRDV='" + coderdv + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox5.Text = dr[0].ToString();
                    dateTimePicker1.Value = DateTime.Parse(dr[1].ToString());
                    maskedTextBox1.Text = dr[2].ToString();
                    comboBox1.SelectedItem = dr[3].ToString();
                }
                dr.Close();
                Program.con.Close();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Champ Numéro RDV vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = String.Format("delete from rdv where NumeroRDV='{0}'", textBox5.Text);
                int r = cmd.ExecuteNonQuery(); 
                if (r != 0)
                {
                    MessageBox.Show("RDV bien supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();
                    textBox5.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    maskedTextBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull == false)
                MessageBox.Show("Heure Invalide!!", "champ Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Medecin Invalide!!", "champ Invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Program.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.con;
                cmd.CommandText = String.Format("update rdv set DateRDV='{0}',HeureRDV='{1}',CodeMedecin='{2}' where NumeroRDV='{3}'", dateTimePicker1.Value.ToShortDateString(), maskedTextBox1.Text, comboBox1.SelectedItem.ToString(), textBox5.Text);
                int r = cmd.ExecuteNonQuery(); 
                if (r != 0)
                {
                    MessageBox.Show("RDV bien modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.con.Close();
                    dataGridView1.CurrentRow.Cells[1].Value = dateTimePicker1.Value.ToShortDateString(); 
                    dataGridView1.CurrentRow.Cells[2].Value = maskedTextBox1.Text;
                    dataGridView1.CurrentRow.Cells[3].Value = comboBox1.SelectedItem.ToString();

                }
                
            }
        }
