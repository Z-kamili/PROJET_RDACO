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
    public partial class lgn_cmd : Form
    {
        public lgn_cmd(string str)
        {
            InitializeComponent();
            textBox1.Text = str;
            textBox1.Enabled = false;
         
        }
      private  SqlConnection cn;
      private  SqlCommand cmd;
     private   SqlDataReader rd;
      private  DataTable dt = new DataTable();
        private void lgn_cmd_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("Select * from Marque",cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            for(int i=0;i<dt.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            cn.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                cmd = new SqlCommand( "Insert into Ligne_Cmd values (  " + int.Parse(comboBox1.Text) + ",'" +  (textBox1.Text).ToString() + "','" + int.Parse(textBox3.Text) + " ' )",cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoute bien effectuer");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Commande c = new Commande();
                c.Show();
                this.Close();
            }
        }
    }
}
