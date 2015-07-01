using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class SuDungDichVuDAL
    {
        public DataTable DSSuDungDichVu(int maPhong)
        {
            string sql = string.Format("select MaSuDungDichVu, TenDichVu, MaThuePhong, MaPhong, SoLuong, Gia, ThanhTien, NgaySuDung from SUDUNGDICHVU inner join DICHVU on SUDUNGDICHVU.MaDichVu = DICHVU.MaDichVu where MaPhong = {0}",maPhong);
            return Connector.getDataTable(sql);
        }

        // Lấy danh sách sử dụng dịch vụ từ cơ sở dữ liệu.
        public DataTable LayDanhSachSuDungDichVu()
        {
            string sql = "select * from SUDUNGDICHVU";
            return Connector.getDataTable(sql);
        }
        public string LayTenKhachHang(int MaPhong)
        {
            string sql = string.Format("select TenKhachHang from SUDUNGDICHVU inner join DATPHONG on SUDUNGDICHVU.MaDatPhong = DATPHONG.MaDatPhong inner join KHACHHANG  on DATPHONG.MaKhachHang = KHACHHANG.MaKhachHang where SUDUNGDICHVU.MaPhong = {0}", MaPhong);
            return Connector.getFistObject(sql) == null ? "" : Connector.getFistObject(sql).ToString();
        }

        //Thêm một dòng mới
        public void Insert(SuDungDichVuDTO sddvDTO)
        {
            string sql;
            sql = string.Format("insert into SUDUNGDICHVU(MaDatPhong, MaPhong, ThanhTien) Values({0}, {1}, {2})", sddvDTO.MaDatPhong,sddvDTO.MaPhong,sddvDTO.ThanhTien);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa
        public void Delete(int maSuDungDichVu)
        {
            string sql = string.Format("delete from SUDUNGDICHVU where MaSuDungDichVu = {0}", maSuDungDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin 
        public void Update(SuDungDichVuDTO sddvDTO)
        {
            string sql;
            sql = string.Format("update SUDUNGDICHVU set MaDatPhong = {0}, MaPhong = {1}, ThanhTien = {2} where MaSuDungDichVu = {3}", sddvDTO.MaDatPhong, sddvDTO.MaPhong, sddvDTO.ThanhTien, sddvDTO.ThanhTien);
            Connector.ExecuteNonQuery(sql);
        }

    }
}
