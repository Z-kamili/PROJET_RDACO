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
    public partial class Nomoclature : Form
    {
        public Nomoclature()
        {
            InitializeComponent();
        }

        private void Nomoclature_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
          //  dataGridView1.AllowUserToAddRows = false;
          
            //
            DataGridViewComboBoxColumn dvc = new DataGridViewComboBoxColumn();
            dvc.HeaderText = "Code Ingredient";
            dvc.Name = "Code_Ingredient";
            dvc.DisplayMember = "Code_Ingredient";
            DataGridViewTextBoxColumn dtb = new DataGridViewTextBoxColumn();
            dtb.HeaderText = "Dosage";
            dtb.Name = "Dosage";
            //--
           dataGridView1.Columns.AddRange(dvc, dtb);
           textBox1.ReadOnly = true;
           textBox2.ReadOnly = true;
            //CB_NomEclature_CodeGamme_Ajouter.DropDownStyle = ComboBoxStyle.DropDownList;
          
            //
            //
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Marque";
            cmd.Connection = cn;
            cn.Open();
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
         /*  comboBox1.DataSource = dt;
           comboBox1.DisplayMember = "Code_Marque";*/
          for(int i = 0; i <dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            } 
            cn.Close();
        }
        
        SqlConnection cn;
         SqlCommand cmd,cmd2;
        SqlDataReader dr,dr2;
        DataTable dt = new DataTable();
        DataTable dt4 = new DataTable();
        static int cpt = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cpt = 0;
                comboBox1.Text = dt.Rows[cpt][0].ToString();
               // comboBox2.Text = dt.Rows[cpt][1].ToString();
              //  textBox1.Text = dt.Rows[cpt][2].ToString();
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
                comboBox1.Text = dt.Rows[cpt][0].ToString();
              //  comboBox2.Text = dt.Rows[cpt][1].ToString();
              //  textBox1.Text = dt.Rows[cpt][2].ToString();
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
                comboBox1.Text = dt.Rows[cpt][0].ToString();
               // comboBox2.Text = dt.Rows[cpt][1].ToString();
              //  textBox1.Text = dt.Rows[cpt][2].ToString();
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
                comboBox1.Text = dt.Rows[cpt][0].ToString();
               // textBox1.Text = dt.Rows[cpt][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnaj_Click(object sender, EventArgs e)
        {
            /* cn.Open();
              try
              {
                  cmd2 = new SqlCommand("Insert into Nomenclature values ( ' " + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + " ' )", cn);
                  cmd2.ExecuteNonQuery();
                  MessageBox.Show("Ajoute bien effectuer");
              }catch(Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
              cn.Close();*/
           try
            {
                cn.Open();
                SqlCommand testCMD = new SqlCommand
                ("Ajoute_Nmclt", cn);

                testCMD.CommandType = CommandType.StoredProcedure;

                /*  SqlParameter RetVal = testCMD.Parameters.Add
                     ("RetVal", SqlDbType.Int);
                  RetVal.Direction = ParameterDirection.ReturnValue;*/
                SqlParameter IdIn = testCMD.Parameters.Add
                  ("@code_marque", SqlDbType.Int);
                IdIn.Direction = ParameterDirection.Input;
                SqlParameter NumTitles = testCMD.Parameters.Add
                   ("@code_ingrediant", SqlDbType.Int);
                NumTitles.Direction = ParameterDirection.Input;
                SqlParameter dosage = testCMD.Parameters.Add
                  ("@dosage", SqlDbType.Float);
                dosage.Direction = ParameterDirection.Input;
                SqlParameter res = new SqlParameter();
                res = testCMD.Parameters.Add("@r", SqlDbType.Int);
                res.Direction = ParameterDirection.Output;
                 for (int i = 0; i < dataGridView1.Rows.Count; i++)
                 {
                     if (dataGridView1.Rows[i].Cells[1].Value != null)
                     {
                         IdIn.Value = comboBox1.Text;
                         NumTitles.Value = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                         dosage.Value = float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());

                     }
                 }


                SqlDataReader myReader;

                myReader = testCMD.ExecuteReader();
                if (res.Value.ToString() == "1")
                {
                    MessageBox.Show("Ajoute n'est pas effectuer");
                }
                else
                {
                    MessageBox.Show("Ajoute bien effectuer");
                }

                cn.Close();


            }catch(Exception ex)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            //  dataGridView1.DataSource = null;

            //
            //   int val = comboBox1.Text;
            //
            /*    cmd = new SqlCommand("select * from Nomenclature where Code_Marque = " + comboBox1.Text, cn);
                   cn.Open();
                   dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                DataGridViewTextBoxColumn dtb = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn dtb2 = new DataGridViewTextBoxColumn();
                dtb.HeaderText = "Code Ingrediant";
                dtb.Name = "Code Ingrediant";

                   cn.Close();
                cn.Open();
                cmd = new SqlCommand("Select Intitule_Marque,Recette from Marque where Code_Marque = '" + comboBox1.Text + "'",cn);
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr2);
                textBox1.Text = dt3.Rows[0][0].ToString();
                textBox2.Text = dt3.Rows[0][1].ToString();
                cn.Close();
                //
                //
                /* dataGridView1.Rows.Clear();
                 //
                 int val = Convert.ToInt32(comboBox1.SelectedItem);
                 //
                 cmd = new SqlCommand("select * from  Nomenclature where Code_Marque = " + val,cn);
                 cn.Open();
                 dr = cmd.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(dr);
                 if (dr.Read())
                 {
                      dataGridView1.Rows[0].Cells[0] = dr[1].ToString();
                     TB_Recette_Ajouter.Text = dr[2].ToString();
                     CB_NomEclature_CodeGamme_Ajouter.Text = dr[3].ToString();
                 }
                 cnx.Close();
                 //
                 //
                 cnx.Open();
                 cmd = new SqlCommand();
                 cmd.Connection = cnx;
                 var req = @"select * from Nomenclature where Code_Marque = " + CB_CodeMarque_Ajouter.Text;
                 cmd.CommandText = req;
                 dr = cmd.ExecuteReader();
                 dt = new DataTable();
                 DG_NomEclature_Ajouter.DataSource = dt;
                 dt.Load(dr); */
            //  dataGridView1.DataSource = null;

            //
            //   int val = comboBox1.Text;
            //
            //string req = "select Code_Marque From Nomenclature  ";

            /*     cmd = new SqlCommand("select Code_Ingredient,Dosage from Nomenclature where Code_Marque = " + comboBox1.Text, cn);
                 cn.Open();
                 dr = cmd.ExecuteReader();
                 dt = new DataTable();
                 dt.Load(dr);
                 DataGridViewTextBoxColumn dtb = new DataGridViewTextBoxColumn();
                 DataGridViewTextBoxColumn dtb2 = new DataGridViewTextBoxColumn();
                 dtb.HeaderText = "Code Ingrediant";
                 dtb.Name = "Code Ingrediant";
                 dataGridView1.DataSource = dt;
                 //chargement 
                 string reqqq = "select * from Marque";
                 cmd = new SqlCommand(reqqq, cn);
                 dr = cmd.ExecuteReader();
                 dt = new DataTable();
                 dt.Load(dr);
                 textBox1.Text = dt.Rows[comboBox1.SelectedIndex]["Intitule_Marque"].ToString();
                 textBox2.Text = dt.Rows[comboBox1.SelectedIndex]["Recette"].ToString();
                 cn.Close();*/
            /*   cn.Close();
               cn.Open();
               cmd = new SqlCommand("select * from Nomenclature where Code_Marque = " + comboBox1.Text, cn);
               dr = cmd.ExecuteReader();
               dt = new DataTable();
               dt.Load(dr);
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   dataGridView1.Rows.Add();
                   //
                   dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][2];
                   //DG_NomEclature_Ajouter.Rows[i].Cells[1].ReadOnly = true;
                   //
                   DataGridViewComboBoxCell cell = dataGridView1.Rows[i].Cells[0] as DataGridViewComboBoxCell;
                   cell.Items.Add(dt.Rows[i][1].ToString());
                   dataGridView1.Rows[i].Cells[0].Value = cell.Items[0];
                   dataGridView1.Rows[i].Cells[0].ReadOnly = true;
               }

               int nb = dt.Rows.Count;
               cn.Close(); */
            //int val = int.Parse(comboBox1.Text);
            //
            SqlDataReader dr;
            //  comboBox1.Text = "";
            int val = int.Parse(comboBox1.Text);
            
            cmd = new SqlCommand("select * from  Nomenclature where Code_Marque = " + val, cn);
            cn.Close();
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
              //  CB_NomEclature_CodeGamme_Ajouter.Text = dr[3].ToString();
            }

            cn.Close();
            //
            //
            cn.Open();
            cmd = new SqlCommand("select * from Nomenclature where Code_Marque = " + comboBox1.Text, cn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               dataGridView1.Rows.Add();
                //
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][2];
                //DG_NomEclature_Ajouter.Rows[i].Cells[1].ReadOnly = true;
                //
                  DataGridViewComboBoxCell cell = dataGridView1.Rows[i].Cells[0] as DataGridViewComboBoxCell;
                 cell.Items.Add(dt.Rows[i][1].ToString());
                dataGridView1.Rows[i].Cells[0].Value = cell.Items[0];
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }

            int nb = dt.Rows.Count;
            cn.Close();
            cn.Open();
            cmd = new SqlCommand(
                "SELECT Code_Ingredient FROM Ingredient WHERE Code_Ingredient NOT IN (SELECT Code_Ingredient FROM Nomenclature WHERE Code_Marque = " +
                val + ")", cn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //nb = nb + i;
               dataGridView1.Rows.Add();
                DataGridViewComboBoxCell
                    cell = dataGridView1.Rows[nb].Cells[0] as DataGridViewComboBoxCell;
                //
                cell.Items.Add(dt.Rows[i][0].ToString());
               dataGridView1.Rows[nb].Cells[0].Value = cell.Items[0];
                nb = nb + 1;
            }

            //
            cn.Close();
            //
            /*   cn.Open();
               cmd = new SqlCommand(
                   "SELECT Code_Ingredient FROM Ingredient WHERE Code_Ingredient NOT IN (SELECT Code_Ingredient FROM Nomenclature WHERE Code_Marque = " +
                   val + ")", cn);
               dr = cmd.ExecuteReader();
               dt = new DataTable();
               dt.Load(dr);
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   //nb = nb + i;
                   DG_NomEclature_Ajouter.Rows.Add();
                   DataGridViewComboBoxCell
                       cell = DG_NomEclature_Ajouter.Rows[nb].Cells[0] as DataGridViewComboBoxCell;
                   //
                   cell.Items.Add(dt.Rows[i][0].ToString());
                   DG_NomEclature_Ajouter.Rows[nb].Cells[0].Value = cell.Items[0];
                   nb = nb + 1;
               }

               //
               cnx.Close();*/
        }

        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

    }
}
