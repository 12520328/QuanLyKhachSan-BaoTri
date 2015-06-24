using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class NguoiDungDAL
    {
        // Lấy danh sách người dùng từ cơ sở dữ liệu.
        public DataTable LayDanhSachNguoiDung()
        {
            string sql = "select * from NGUOIDUNG";
            return Connector.getDataTable(sql);
        }

        // Thêm một người dùng vào cơ sở dữ liệu.
        public bool Insert(NguoiDungDTO nguoiDungDTO)
        {
            if(nguoiDungDTO.TenNguoiDung == "admin")
            {
                XtraMessageBox.Show("Tên người dùng đã tồn tại.", "Thông Báo");
                return false;
            }
            string sql = string.Format("insert into NGUOIDUNG(HoVaTen,TenNguoiDung,MatKhau,LoaiNguoiDung) Values('{0}','{1}','{2}','{3}')",
                nguoiDungDTO.HoVaTen, nguoiDungDTO.TenNguoiDung, nguoiDungDTO.MatKhau, nguoiDungDTO.LoaiNguoiDung);
            Connector.ExecuteNonQuery(sql);
            return true;
        }

        // Xóa một người dùng khỏi cơ sở dữ liệu.
        public bool Delete(NguoiDungDTO nguoiDungDTO)
        {
            string sql = string.Format("delete from NGUOIDUNG where MaNguoiDung = {0}", nguoiDungDTO.MaNguoiDung);
            Connector.ExecuteNonQuery(sql);
            return true;
        }

        // Sưa thông tin một người dùng.
        public bool Update(NguoiDungDTO nguoiDungDTO)
        {
            if (nguoiDungDTO.TenNguoiDung == "admin")
            {
                XtraMessageBox.Show("Tên người dùng đã tồn tại.", "Thông Báo");
                return false;
            }
            string sql = string.Format("update NGUOIDUNG set TenNguoiDung = '{0}', MatKhau = '{1}', LoaiNguoiDung = '{2}' where MaNguoiDung = {3}",
               nguoiDungDTO.TenNguoiDung, nguoiDungDTO.MatKhau, nguoiDungDTO.LoaiNguoiDung, nguoiDungDTO.MaNguoiDung);

            try
            {
                Connector.ExecuteNonQuery(sql);
                return true;
            }
            catch
            {
                XtraMessageBox.Show("Tên người dùng đã tồn tại.", "Thông Báo");
                return false;
            }
        }


        // Lấy lên thông tin người dùng nằm cuối bảng.
        public object LayMaNguoiDungCuoiBang()
        {
            string sql = string.Format("select MaNguoiDung from NGUOIDUNG where MaNguoiDung = (select max(MaNguoiDung) from NGUOIDUNG)");
            return Connector.getFistObject(sql);
        }

        //Kiểm tra tên người dùng tồn tại không?
        public bool TonTaiTenNguoiDung(string TenNguoiDung)
        {
            string sql = string.Format("select TenNguoiDung from NGUOIDUNG where TenNguoiDung = '{0}'",TenNguoiDung);
            if (Connector.getFistObject(sql) == null)
                return false;
            return true;
        }

        //Kiểm tra đăng nhập
        public bool KiemTraDangNhap(string TenNguoiDung, string MatKhau)
        {
            string sql = string.Format("select * from NGUOIDUNG where TenNguoiDung = '{0}' and MatKhau = '{1}'", TenNguoiDung, MatKhau);
            if (Connector.getFistObject(sql) == null)
                return false;
            return true;
        }      
 
        //Lấy loại ngừoi dùng
        public string LayLoaiNguoiDung(string TenNguoiDung)
        {
            string sql = string.Format("select LoaiNguoiDung from NGUOIDUNG where TenNguoiDung = '{0}'",TenNguoiDung);
            return Convert.ToString(Connector.getFistObject(sql));
        }

        //Lấy họ tên ngừoi dùng
        public string LayHoTenNguoiDung(string TenNguoiDung)
        {
            string sql = string.Format("select HoVaTen from NGUOIDUNG where TenNguoiDung = '{0}'", TenNguoiDung);
            return Convert.ToString(Connector.getFistObject(sql));
        }

        //Lấy mã người dùng
        public int LayMaNguoiDung(string TenNguoiDung)
        {
            string sql = string.Format("select MaNguoiDung from NGUOIDUNG where TenNguoiDung = '{0}'", TenNguoiDung);
            return Convert.ToInt32(Connector.getFistObject(sql));
        }
    }
}
