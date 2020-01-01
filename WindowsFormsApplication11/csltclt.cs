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
    public partial class csltclt : Form
    {
        public csltclt()
        {
            InitializeComponent();
        }

        private void csltclt_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();

           
           cmd = new SqlCommand("Select * from Client",cn);
            rd = cmd.ExecuteReader();
           dt.Load(rd);
            for(int i=0;i<=dt.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            cn.Close();
        }
        SqlConnection cn;
        SqlCommand cmd, cmd2;
        SqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr,dr1;
            DataTable dt = new DataTable();
            cn.Open();
            cmd = new SqlCommand("Select * from Client where Num_Client = " + int.Parse(comboBox1.Text), cn);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            cmd = new SqlCommand("Select * from Commande where Num_Client = " + int.Parse(comboBox1.Text), cn);
            dr1 = cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("Select * from Ligne_Cmd where Num_cmd  = '" + dataGridView1.SelectedCells[0].Value + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir tout les champs");
            }
            else
            {
               
                string str = "Update Client set Raison_Social = '" + textBox2.Text  + "',Adresse_Client = '" + textBox3.Text + "' where Num_Client = " +  int.Parse(comboBox1.Text);
               
                cn.Open();
                cmd = new SqlCommand(str, cn);
                 cmd.ExecuteNonQuery();
                MessageBox.Show("Modification bien effectuer");
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir le champs");
            }
            else
            {
                if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    
                    string str = "Delete from Client where Num_Client = '" + comboBox1.Text + "'";
                    cmd = new SqlCommand(str, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("suppression bien effectuer");
                   
                }


            }
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
