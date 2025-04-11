using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace QuanLyTiecCuoiVaDoCuoi
{
    internal class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ly gia thinh\\Documents\\dbQLTiecCuoi.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
        }

        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = con.CreateCommand();  
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query, String message)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            con.Close();

            MessageBox.Show(message, "Success" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        public SqlDataReader getForcombo(String query ) {
         SqlConnection con = getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query , con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
