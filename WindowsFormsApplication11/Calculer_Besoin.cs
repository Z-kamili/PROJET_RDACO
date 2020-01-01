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
    public partial class Calculer_Besoin : Form
    {
        public Calculer_Besoin()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd, cmd2;
        SqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        static int cpt = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void Calculer_Besoin_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("dbo.f_Besoin_Net", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@Qte_Stock", SqlDbType.Float);
                SqlParameter p2 = new SqlParameter("@Besoin_brut_Ing", SqlDbType.Float);
                SqlParameter p3 = new SqlParameter("@Result", SqlDbType.Float);
                p1.Direction = ParameterDirection.Input;
                p2.Direction = ParameterDirection.Input;
                p3.Direction = ParameterDirection.ReturnValue;
                p1.Value = float.Parse(textBox1.Text);
                p2.Value = float.Parse(textBox2.Text);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cn.Open();
                cmd.ExecuteScalar();
                MessageBox.Show(p3.Value.ToString());
                if (p3.Value != DBNull.Value)
                {
                    label3.Text = p3.Value.ToString();
                }
                cn.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("erreur");
            }
         
        }
    }
}
