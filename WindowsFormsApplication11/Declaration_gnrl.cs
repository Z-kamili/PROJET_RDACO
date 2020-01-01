using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication11
{
    class Declaration_gnrl
    {
        public static string  req;
        public static SqlCommand cmd;
        public static SqlConnection cn;
        public static SqlDataReader Dr;
        public static DataTable dt = new DataTable();
        public static int cpt;
        public static void connecter()
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=CasRDACO;Integrated Security=true");
            cn.Open();
        }
        public static void Fermer()
        {
            cn.Close();
        }
        public static SqlDataReader selection(string rep)
        {
            cmd = new SqlCommand(rep, cn);
            return cmd.ExecuteReader();
        }
        public static int insertion(string rep)
        {
            cmd = new SqlCommand(rep, cn);
            return cmd.ExecuteNonQuery();
        }
      
    }
}
