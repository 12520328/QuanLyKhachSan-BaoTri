using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChiTietDatPhongDAL
    {
        // Lấy danh sách chi tiết đặt phòng  từ cơ sở dữ liệu.
        public DataTable LayDanhSachChiTietDatPhong()
        {
            string sql = "select * from CHITIETDATPHONG";
            return Connector.getDataTable(sql);
        }
       
        public DataTable LayDanhSachPhongTheoMaDatPhong(int MaDatPhong)
        {
            string sql = string.Format("select p.MaPhong, p.SoPhong from CHITIETDATPHONG AS ct, PHONG AS p where ct.MaPhong = p.MaPhong  AND MaDatPhong = {0}", MaDatPhong);
            return Connector.getDataTable(sql);
        }
        public DataTable LayDanhSachChiTietDatPhong(int MaDatPhong)
        {
            string sql = string.Format("select * from CHITIETDATPHONG AS ct, PHONG AS p, LOAIPHONG AS lp where ct.MaPhong = p.MaPhong AND p.MaLoaiPhong = lp.MaLoaiPhong AND MaDatPhong = {0}", MaDatPhong) ;
            return Connector.getDataTable(sql);
        }

        // Thêm một chi tiết đặt phòng  vào cơ sở dữ liệu.
        public void Insert(ChiTietDatPhongDTO ctDatPhongDTO)
        {
            string sql = string.Format("insert into CHITIETDATPHONG(MaDatPhong,MaPhong) Values({0},{1})",
                ctDatPhongDTO.MaDatPhong, ctDatPhongDTO.MaPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một chi tiết đặt phòng  khỏi cơ sở dữ liệu.
        public void Delete(int maChiTietDatPhong)
        {
            string sql = string.Format("delete from CHITIETDATPHONG where MaChiTietDatPhong = {0}", maChiTietDatPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một chi tiết đặt phòng .
        public void Update(ChiTietDatPhongDTO ctDatPhongDTO)
        {
            string sql = string.Format("update CHITIETDATPHONG set MaDatPhong = {0}, MaPhong = {1} where MaChiTietDatPhong = {2}",
               ctDatPhongDTO.MaDatPhong, ctDatPhongDTO.MaPhong, ctDatPhongDTO.MaChiTietDatPhong);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
