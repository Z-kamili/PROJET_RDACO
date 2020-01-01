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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
             
        }
        static int cpt = 0;
       
        private void button5_Click(object sender, EventArgs e)
        {
            string sa = "Insert into Client values ( ' " + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + " ' )";
            Declaration_gnrl.connecter();
            try
            {
                Declaration_gnrl.insertion(sa);
                MessageBox.Show("ajoute bien effectuer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration_gnrl.Fermer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cpt = 0;
            textBox1.Text = dt.Rows[cpt][0].ToString();
            textBox2.Text = dt.Rows[cpt][1].ToString();
            textBox3.Text = dt.Rows[cpt][2].ToString();

        }

        private void Client_Load(object sender, EventArgs e)
        {
          
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
           cmd =new SqlCommand("Select * from Client",cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("Select count(*) from Client", cn);
            SqlDataReader rd2;
            DataTable dt3 = new DataTable();
            rd2 = cmd.ExecuteReader();
            dt3.Load(rd2);
            string num = dt3.Rows[0][0].ToString();
            int num2 = int.Parse(num);
            textBox1.Text =  (num2 + 2).ToString();
            textBox1.Enabled = false;
            cn.Close();
        }
        SqlConnection cn;
       SqlCommand cmd, cmd2;
       SqlDataReader rd;
      DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            --cpt;
            try
            {
                textBox1.Text = dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show("Erreur");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ++cpt;
            try
            {
                textBox1.Text = dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cpt= dt.Rows.Count - 1;
            
                textBox1.Text =dt.Rows[cpt][0].ToString();
                textBox2.Text = dt.Rows[cpt][1].ToString();
                textBox3.Text = dt.Rows[cpt][2].ToString();
           
          
                
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
