using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop
{
    public static class Connector
    {
        private static SqlConnection _conn = new SqlConnection();

        public static void MoKetNoi()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn = new SqlConnection(@"Data Source=PHUONG;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
                if (_conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        _conn.Open();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!");
                    }
                }
            }
        }

        public static void DongKetNoi()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
        
        
        // Trả về một DataTable .
        public static DataTable getDataTable(string sql)
        {

            MoKetNoi();

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            DongKetNoi();

            return dt;

        }

        // Thực thi câu lệnh truy vấn insert,delete,update
        public static void ExecuteNonQuery(string sql)
        {
            MoKetNoi();

            SqlCommand cmd = new SqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();

            DongKetNoi();

        }

        // Trả về DataReader
        public static SqlDataReader getDataReader(string sql)
        {
            MoKetNoi();

            SqlCommand com = new SqlCommand(sql, _conn);

            SqlDataReader dr = com.ExecuteReader();
            DongKetNoi();

            return dr;
        }

        // Trả về một object với câu lệnh select chỉ trả về một giá trị.
        public static object getFistObject(string sql)
        {
            MoKetNoi();
            SqlCommand com = new SqlCommand(sql, _conn);

            object fistObject = com.ExecuteScalar();
            DongKetNoi();

            return fistObject;
        }
    }

}
