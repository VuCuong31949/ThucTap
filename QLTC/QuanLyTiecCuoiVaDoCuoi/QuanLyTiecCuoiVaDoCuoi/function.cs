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
            con.ConnectionString = global::QuanLyTiecCuoiVaDoCuoi.Properties.Settings.Default.dbQuanLyTiecCuoi2ConnectionString1;
            return con;
        }





        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            try
            {
                con.Open(); // Đảm bảo mở kết nối
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi getData: " + ex.Message);
                return new DataSet();
            }
            finally
            {
                con.Close(); // Đóng kết nối
            }
        }





        public void setData(string query, string message, SqlParameter[] parameters = null)
        {
            SqlConnection con = getConnection();
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
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
