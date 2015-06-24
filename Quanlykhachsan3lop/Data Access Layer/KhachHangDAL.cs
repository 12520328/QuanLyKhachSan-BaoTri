using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class KhachHangDAL
    {
        // Lấy danh sách khách hàng từ cơ sở dữ liệu.
        public DataTable LayDanhSachKhachHang()
        {
            string sql = "select * from KHACHHANG";
            return Connector.getDataTable(sql);
        }

        // Thêm một khách hàng vào cơ sở dữ liệu.
        public void Insert(KhachHangDTO khachHangDTO)
        {
            string sql = string.Format("insert into KHACHHANG(TenKhachHang,GioiTinh,CMND,NgaySinh,DiaChi,SDT) Values(N'{0}',N'{1}','{2}','{3}',N'{4}','{5}')",
                khachHangDTO.TenKhachHang,khachHangDTO.GioiTinh, khachHangDTO.CMND,khachHangDTO.NgaySinh,khachHangDTO.DiaChi,khachHangDTO.SoDienThoai);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một khách hàng khỏi cơ sở dữ liệu.
        public void Delete(int maKhachHang)
        {
            string sql = string.Format("delete from KHACHHANG where MaKhachHang = {0}", maKhachHang);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một khách hàng.
        public void Update(KhachHangDTO khachHangDTO)
        {
            string sql = string.Format("update KHACHHANG set TenKhachHang = N'{0}', GioiTinh = N'{1}', CMND = '{2}', NgaySinh = '{3}', DiaChi = N'{4}', SDT = '{5}' where MaKhachHang = {6}",
                khachHangDTO.TenKhachHang,khachHangDTO.GioiTinh,khachHangDTO.CMND,khachHangDTO.NgaySinh,khachHangDTO.DiaChi,khachHangDTO.SoDienThoai, khachHangDTO.MaKhachHang);
            Connector.ExecuteNonQuery(sql);
        }               
    }
}
