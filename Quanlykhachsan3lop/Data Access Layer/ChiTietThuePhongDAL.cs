using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChiTietThuePhongDAL
    {
        // Lấy danh sách chi tiết thuê phòng  từ cơ sở dữ liệu.
        public DataTable LayDanhSachChiTietThuePhong()
        {
            string sql = "select * from CHITIETTHUEPHONG";
            return Connector.getDataTable(sql);
        }

        public DataTable LayDanhSachKhachHangThuePhong()
        {
            string sql = "select kh.TenKhachHang, p.SoPhong, ct.MaChiTietThuePhong from CHITIETTHUEPHONG AS ct, PHONG AS p, KHACHHANG AS kh where p.MaPhong = ct.MaPhong AND kh.MaKhachHang = ct.MaKhachHang";
            return Connector.getDataTable(sql);
        }
        public DataTable LayDanhSachChiTietThuePhong(int MaThuePhong)
        {
            string sql = string.Format("select * from CHITIETTHUEPHONG where MaThuePhong = {0}", MaThuePhong);
            return Connector.getDataTable(sql);
        }

        public DataTable LayDanhSachChiTietThuePhongTheoMaThuePhong(int MaThuePhong)
        {
            string sql = string.Format("select * from CHITIETTHUEPHONG where MaThuePhong = {0}", MaThuePhong);
            return Connector.getDataTable(sql);
        }   
        

        // Thêm một chi tiết thuê phòng  vào cơ sở dữ liệu.
        public void Insert(ChiTietThuePhongDTO ctThuePhongDTO)
        {
            string sql = string.Format("insert into CHITIETTHUEPHONG(MaThuePhong,MaKhachHang,MaPhong) Values({0},{1},{2})",
                ctThuePhongDTO.MaThuePhong, ctThuePhongDTO.MaKhachHang,ctThuePhongDTO.MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
        
        // Xóa một chi tiết thuê phòng  khỏi cơ sở dữ liệu.
        public void Delete(int maChiTietThuePhong)
        {
            string sql = string.Format("delete from CHITIETTHUEPHONG where MaChiTietThuePhong = {0}", maChiTietThuePhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một chi tiết thuê phòng .
        public void Update(ChiTietThuePhongDTO ctThuePhongDTO)
        {
            string sql = string.Format("update CHITIETTHUEPHONG set MaThuePhong = {0}, MaKhacHang = {1}, MaPhong = {2} where MaChiTietThuePhong = {3}",
               ctThuePhongDTO.MaThuePhong, ctThuePhongDTO.MaKhachHang, ctThuePhongDTO.MaPhong, ctThuePhongDTO.MaChiTietThuePhong);
            Connector.ExecuteNonQuery(sql);
        }

        public void UpdateChuyenPhong(int MaThuePhong, int MaPhong, int MaPhongMoi)
        {
            string sql = string.Format("update CHITIETTHUEPHONG set MaPhong = {0} where MaThuePhong = {1} and MaPhong = {2}",
               MaPhongMoi, MaThuePhong, MaPhong, MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
