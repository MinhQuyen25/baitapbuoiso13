using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ViDuProject1605
{
    internal class DAO
    {
        private static string ConnectionString = "Data Source = desktop-eh2f7bb\\sqlexpress" +
                                   "Initial Catalog=QuanLyBanHang;" +
                                   "Integrated Security=True";

        public static SqlConnection con = new SqlConnection(ConnectionString);

        public static void Connect()
        {
            try
            {
                if

                    (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            }
            public void Close()
            {
            
                if (con.State == System.Data.ConnectionState.Open)
                {

                    con.Close();
                    con.Dispose();
                    con = null;
                }
            }
            
       
            public static DataTable GetDataToTable(string sql)
            {
                SqlDataAdapter Mydata = new SqlDataAdapter(sql,
                DAO.con);
                DataTable table = new DataTable();
                Mydata.Fill(table);
                return table;
            }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql,
            DAO.con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
            return true;
            else
                return false;
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd; // Khai báo đối tượngSqlCommand
            cmd = new SqlCommand(); // Khởi tạo đối tượng
            cmd.Connection = DAO.con; // Gán kết nối
            cmd.CommandText = sql; // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
    }
    }

    