using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class DatPhongDAL
    {
        //Lấy danh sach phiêu đặt phòng
        public DataTable LayDanhSachPhieuDatPhong()
        {
            string sql = "select * from DATPHONG inner join KHACHHANG on DATPHONG.MaKhachHang = KHACHHANG.MaKhachHang";
            return Connector.getDataTable(sql);
        }
        public int LayMaKhachHang(int maDatPhong)
        {
            string sql = string.Format("select MaKhachHang from DATPHONG where MaDatPhong = {0} ", maDatPhong);
            return int.Parse(Connector.getFistObject(sql).ToString());
        }
        public DataTable LayDanhSachPhieuDatPhong(int MaDatPhong)
        {
            string sql = string.Format("select * from DATPHONG inner join KHACHHANG on DATPHONG.MaKhachHang = KHACHHANG.MaKhachHang where MaDatPhong = {0}",MaDatPhong);
            return Connector.getDataTable(sql);
        }
        // Thêm một phiếu đặt phòng vào cơ sở dữ liệu.
        public void Insert(DatPhongDTO datPhongDTO)
        {
            string sql;
           sql = string.Format("insert into DATPHONG(MaKhachHang,NgayDat,NgayDen,NgayDi,DatCoc,KhuyenMai,VND,TrangThai) Values({0},'{1}','{2}','{3}',{4},{5},{6},'{7}')",
                   datPhongDTO.MaKhachHang, datPhongDTO.NgayDat, datPhongDTO.NgayDen, datPhongDTO.NgayDi, datPhongDTO.DatCoc,
                    datPhongDTO.KhuyenMai, datPhongDTO.VND, datPhongDTO.TrangThai);
           
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một phiếu đặt phòng khỏi cơ sở dữ liệu.
        public void Delete(int maDatPhong)
        {
            string sql = string.Format("delete from DATPHONG where MaDatPhong = {0}", maDatPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một phiếu đặt phòng.
        public void Update(DatPhongDTO datPhongDTO)
        {
            string sql = string.Format("update DATPHONG set MaKhachHang = {0}, NgayDat = '{1}', NgayDen = '{2}', NgayDi = '{3}', DatCoc = {4}, KhuyenMai = {5}, VND = {6}, TrangThai = '{7}' where MaDatPhong = {8}",
               datPhongDTO.MaKhachHang, datPhongDTO.NgayDat, datPhongDTO.NgayDen, datPhongDTO.NgayDi, datPhongDTO.DatCoc, datPhongDTO.KhuyenMai,
               datPhongDTO.VND,datPhongDTO.TrangThai,datPhongDTO.MaDatPhong);
            Connector.ExecuteNonQuery(sql);
        }
        public void UpdateTrangThai(int MaDatPhong, string TrangThai)
        {
            string sql = string.Format("update DATPHONG set TrangThai = '{0}' where MaDatPhong  = {1}", TrangThai, MaDatPhong);
            Connector.ExecuteNonQuery(sql);
        }
        //Lấy Mã đặt phòng vừa thêm vào
        public int LayMaDatPhong()
        {
            string sql = string.Format("SELECT MAX(MaDatPhong) from DATPHONG");
            return int.Parse(Connector.getFistObject(sql).ToString());
        }

        public string LayTrangThai(int MaDatPhong)
        {
            string sql = string.Format("SELECT TrangThai from DATPHONG where MaDatPhong = {0}",MaDatPhong);
            return Connector.getFistObject(sql).ToString();
        }
    }
}
