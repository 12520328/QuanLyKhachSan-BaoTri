using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChiTietSuDungDichVuDAL
    {
        // Lấy danh sách chi tiết sử dụng dịch vụ từ cơ sở dữ liệu.
        public DataTable LayDanhSachChiTietSuDungDichVu()
        {
            string sql = "select * from CHITIETSUDUNGDICHVU";
            return Connector.getDataTable(sql);
        }

        // Thêm một chi tiết sử dụng dịch vụ vào cơ sở dữ liệu.
        public void Insert(ChiTietSuDungDichVuDTO chiTietSuDungDichVuDTO)
        {
            string sql = string.Format("insert into CHITIETSUDUNGDICHVU(MaDichVu,SoLuong,DonGia,ThanhTien,MaThuePhong, NgaySuDung) Values({0},{1},{2},{3},{4},'{5}')",
                 chiTietSuDungDichVuDTO.MaDichVu, chiTietSuDungDichVuDTO.SoLuong,chiTietSuDungDichVuDTO.DonGia,chiTietSuDungDichVuDTO.ThanhTien,chiTietSuDungDichVuDTO.MaThuePhong, chiTietSuDungDichVuDTO.NgaySuDung);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một chi tiết sử dụng dịch vụ khỏi cơ sở dữ liệu.
        public void Delete(int maChiTietSuDungDichVu)
        {
            string sql = string.Format("delete from CHITIETSUDUNGDICHVU where MaChiTietSuDungDichVu = {0}", maChiTietSuDungDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một chi tiết sử dụng dịch vụ.
        public void Update(ChiTietSuDungDichVuDTO chiTietSuDungDichVuDTO)
        {
            string sql = string.Format("update CHITIETSUDUNGDICHVU set  MaDichVu = {0}, SoLuong = {1}, DonGia = {2}, ThanhTien = {3}, MaThuePhong = {4}, NgaySuDung = '{5}' where MaChiTietSuDungDichVu = {6}",
               chiTietSuDungDichVuDTO.MaDichVu, chiTietSuDungDichVuDTO.SoLuong, chiTietSuDungDichVuDTO.DonGia, chiTietSuDungDichVuDTO.ThanhTien,chiTietSuDungDichVuDTO.MaThuePhong, chiTietSuDungDichVuDTO.NgaySuDung, chiTietSuDungDichVuDTO.MaChiTietSuDungDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        //Lấy danh sách chi tiết sử dụng dịch vụ theo mã sử dụng dịch vụ
        public DataTable LayDanhSachChiTietSuDungDichVu(int MathuePhong)
        {
            string sql = string.Format("select * from CHITIETSUDUNGDICHVU where MaThuePhong = {0}", MathuePhong);
            return Connector.getDataTable(sql);
        }
    }
}
