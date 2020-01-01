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
    public partial class Csltcommande : Form
    {
        public Csltcommande()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd, cmd2;
        SqlDataReader rd,dr;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        static int cpt = 0;
        private void Csltcommande_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("Select * from Commande", cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            for(int i=0;i<dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            dt.Clear();

            cn.Close();
            cn.Open();
            cmd = new SqlCommand("Select * from Client", cn);
            dr = cmd.ExecuteReader();
            dt2.Load(dr);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt2.Rows[i][0].ToString());
            }
            cn.Close();
        }
       
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataReader dr;
            cmd = new SqlCommand("Select * from Commande where Num_Cmd = '" + comboBox1.Text + "'", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
             dt.Load(dr);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = "Select * from Ligne_Cmd where Num_cmd  = '" + dataGridView1.SelectedCells[0].Value + "'";
            cn.Open();
            cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            if(comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir tout les champs");
            }else
            {
              
                string str = "Update Commande set Date_Cmd = '" + dateTimePicker1.Value + "',Date_Livraison = '" + dateTimePicker2.Value + "',Num_Client = " + int.Parse(comboBox2.Text) + "where Num_Cmd = '" + comboBox1.Text + "'";
               
               
                cmd = new SqlCommand(str, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification bien effectuer");
            }
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir tout les champs");
            }
            else
            {
                if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                { 
 string str = "Delete from Commande where Num_Cmd = '" + comboBox1.Text + "'";
                    cmd = new SqlCommand(str, cn);
                    cmd.ExecuteNonQuery();
                MessageBox.Show("suppression bien effectuer");
              
                }

               
            }
            cn.Close();
           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string str = "Select * from Ligne_Cmd where Num_cmd  = '" + dataGridView1.SelectedCells[0].Value + "'";
            cn.Open();
            cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
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
