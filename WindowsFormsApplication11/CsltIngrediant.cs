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
    public partial class CsltIngrediant : Form
    {
        public CsltIngrediant()
        {
            InitializeComponent();
        }

        private void CsltIngrediant_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
            cmd = new SqlCommand("Select * from Ingredient", cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            cn.Close();
         

        }
        SqlConnection cn;
        SqlCommand cmd, cmd2;
        SqlDataReader rd, rd2;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();

            cmd = new SqlCommand("Select * from Ingredient where Code_Ingredient = '" + comboBox1.Text + "'", cn);
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
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
                cn.Open();
                try
                {
                    string str = "Update Ingredient set  Intitule_Ingredient =  '" + textBox2.Text + "',Qte_Stock = '" + textBox3.Text + "',Code_Ingredient = " + int.Parse(comboBox1.Text) + "where Code_Ingredient  = '" + comboBox1.Text + "'";


                    cmd = new SqlCommand(str, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modification bien effectuer");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir tout les champs");
            }
            else
            {
                if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    cn.Open();

                    string str = "Delete from Ingredient where Code_Ingredient = '" + comboBox1.Text + "'";
                    cmd = new SqlCommand(str, cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("suppression bien effectuer");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    cn.Close();
                }


            }
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
