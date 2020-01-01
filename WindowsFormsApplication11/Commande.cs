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
    public partial class Commande : Form
    {
        public Commande()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd,cmd2;
        SqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        static int cpt = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                cmd = new SqlCommand("Insert into Commande values ( '" + textBox1.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + comboBox1.Text + "')",cn);
                cmd.ExecuteNonQuery();
                lgn_cmd cd = new lgn_cmd(textBox1.Text);
                cd.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            cn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void Commande_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("Select * from Client",cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            /*  for(int i=0;i<dt.Rows.Count - 1; i++)
              {
                  comboBox1.Items.Add(dt.Rows[i][0].ToString());
              } */
           comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Num_Client";
            dt.Clear();
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("Select count(*) from Commande",cn);
            SqlDataReader rd2;
            DataTable dt3 = new DataTable();
            rd2 = cmd.ExecuteReader();
            dt3.Load(rd2);
            string num = dt3.Rows[0][0].ToString();
            int num2 = int.Parse(num);
            textBox1.Text = 'C' +  (num2 + 3).ToString();
            textBox1.Enabled = false;
            cmd2 = new SqlCommand("Select * from Commande", cn);
            rd = cmd2.ExecuteReader();
            dt2.Load(rd);
            cn.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = dt2.Rows[cpt][0].ToString();
             dateTimePicker1.Text = dt2.Rows[cpt][1].ToString();
            dateTimePicker2.Text = dt2.Rows[cpt][2].ToString();
            // textBox5.Text =
            comboBox1.Text =  dt2.Rows[cpt][3].ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            --cpt;
            try
            {
                textBox1.Text = dt2.Rows[cpt][0].ToString();
                dateTimePicker1.Text = dt2.Rows[cpt][1].ToString();
                dateTimePicker2.Text = dt2.Rows[cpt][2].ToString();
                // textBox5.Text =
                comboBox1.Text =  dt2.Rows[cpt][3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ++cpt;
            try
            {
                textBox1.Text = dt2.Rows[cpt][0].ToString();
                dateTimePicker1.Text = dt2.Rows[cpt][1].ToString();
                dateTimePicker2.Text = dt2.Rows[cpt][2].ToString();
                //  textBox5.Text = 
                comboBox1.Text = dt2.Rows[cpt][3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cpt = dt2.Rows.Count - 1;
            textBox1.Text = dt2.Rows[cpt][0].ToString();
            dateTimePicker1.Text = dt2.Rows[cpt][1].ToString();
            dateTimePicker2.Text = dt2.Rows[cpt][2].ToString();
            comboBox1.Text =  dt2.Rows[cpt][3].ToString();
            
        }

        
    }
}
