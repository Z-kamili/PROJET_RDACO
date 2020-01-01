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
    public partial class Marque : Form
    {
        public Marque()
        {
            InitializeComponent();
        }
        static int cpt = 0;

        private void button1_Click(object sender, EventArgs e)
        {
          
            string sa = "Insert into Marque values ( ' " + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + int.Parse (comboBox1.Text)  + " ' )";

            cn.Open();
            try
            {
                cmd = new SqlCommand(sa,cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoute bien effectuer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void Marque_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("Select * from Gamme", cn);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            for(int i=0;i<dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            cn.Close();
            cn.Open();
            dt.Clear();
            cmd2 = new SqlCommand("Select * from Marque", cn);
            dr2 = cmd2.ExecuteReader();
            dt2.Load(dr2);
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("Select count(*) from Marque", cn);
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
     static SqlDataReader rd;
     
        SqlConnection cn;
        SqlCommand cmd,cmd2;
         SqlDataReader dr,dr2;
       DataTable dt = new DataTable();
         DataTable dt2 = new DataTable();

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = 0;
                textBox1.Text = dt2.Rows[cpt][0].ToString();
                textBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox3.Text = dt2.Rows[cpt][2].ToString();
                comboBox1.Text = dt2.Rows[cpt][3].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            --cpt;
            try
            {
                textBox1.Text = dt2.Rows[cpt][0].ToString();
                textBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox3.Text = dt2.Rows[cpt][2].ToString();
                comboBox1.Text = dt2.Rows[cpt][3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ++cpt;
            try
            {
                textBox1.Text =dt2.Rows[cpt][0].ToString();
                textBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox3.Text =dt2.Rows[cpt][2].ToString();
                comboBox1.Text = dt2.Rows[cpt][3].ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = dt2.Rows.Count - 1;
                textBox1.Text = dt2.Rows[cpt][0].ToString();
                textBox2.Text = dt2.Rows[cpt][1].ToString();
                textBox3.Text = dt2.Rows[cpt][2].ToString();
                comboBox1.Text = dt2.Rows[cpt][3].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
