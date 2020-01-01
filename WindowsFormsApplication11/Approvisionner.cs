using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace WindowsFormsApplication11
{
    public partial class Approvisionner : Form
    {
        public Approvisionner()
        {
            InitializeComponent();
        }

        private void Approvisionner_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("Select * from Ingredient",cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            for(int i = 0; i < dt.Rows.Count ; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            cn.Close();
            for(int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i);
            }
            Remplir();
        }
        SqlConnection cn;
        SqlCommand cmd, cmd2;
        SqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public void Remplir()
        {
            SqlDataReader rd2;
            cn.Open();
            cmd = new SqlCommand("Select * from Approvisionner", cn);
            rd2 = cmd.ExecuteReader();
            dt2.Load(rd2);
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                cmd = new SqlCommand("Insert into Approvisionner values ( '" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "')", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoute bien effectuer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Ajoute n'est pas effectuer effectuer");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = 0;
                comboBox1.Text = dt2.Rows[cpt][0].ToString();
                comboBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox1.Text = dt2.Rows[cpt][2].ToString();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button5_Click(object sender, EventArgs e)

        {
            try
            {
                --cpt;
                comboBox1.Text = dt2.Rows[cpt][0].ToString();
                comboBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox1.Text = dt2.Rows[cpt][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ++cpt;
                comboBox1.Text = dt2.Rows[cpt][0].ToString();
                comboBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox1.Text = dt2.Rows[cpt][2].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = dt2.Rows.Count - 1;
                comboBox1.Text = dt2.Rows[cpt][0].ToString();
                comboBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox1.Text = dt2.Rows[cpt][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        static int cpt = 0;
    }
}
