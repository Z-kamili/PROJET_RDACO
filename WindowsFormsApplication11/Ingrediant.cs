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
    public partial class Ingrediant : Form
    {
        public Ingrediant()
        {
            InitializeComponent();
        }

        private void Ingrediant_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("select * from Ingredient",cn);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("Select count(*) from Ingredient", cn);
            SqlDataReader rd2;
            DataTable dt3 = new DataTable();
            rd2 = cmd.ExecuteReader();
            dt3.Load(rd2);
            string num = dt3.Rows[0][0].ToString();
            int num2 = int.Parse(num);
            textBox1.Text =  (num2 + 1).ToString();
            textBox1.Enabled = false;
           
            cn.Close();

        }
        static int cpt = 0;
        SqlConnection cn;
        SqlCommand cmd;
         SqlDataReader dr;
        DataTable dt = new DataTable();

        private void btnaj_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                cmd = new SqlCommand("Insert into Ingredient values ( ' " + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + " ' )", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoute bien effectuer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = 0;
                textBox1.Text = dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
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
                textBox1.Text = dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
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
                textBox1.Text = dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = dt.Rows.Count - 1;
                textBox1.Text = dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
