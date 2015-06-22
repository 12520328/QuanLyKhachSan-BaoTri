using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class LoaiPhongDAL
    {
        // Lấy danh sách loại phòng từ cơ sở dữ liệu.
        public DataTable LayDanhSachLoaiPhong()
        {
            string sql = "select * from LOAIPHONG";
            return Connector.getDataTable(sql);
        }

        // Thêm một loại phòng vào cơ sở dữ liệu.
        public void Insert(LoaiPhongDTO loaiPhongDTO)
        {
            string sql = string.Format("insert into LOAIPHONG(TenLoaiPhong,MaBangGia,SoNguoiToiDa) Values('{0}','{1}','{2}')", loaiPhongDTO.TenLoaiPhong,loaiPhongDTO.MaBangGia,loaiPhongDTO.SoLuongNguoiToiDa);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một loại phòng khỏi cơ sở dữ liệu.
        public void Delete(LoaiPhongDTO loaiPhongDTO)
        {
            string sql = string.Format("delete from LOAIPHONG where MaLoaiPhong = {0}", loaiPhongDTO.MaLoaiPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một loại phòng.
        public void Update(LoaiPhongDTO loaiPhongDTO)
        {
            string sql = string.Format("update LOAIPHONG set TenLoaiPhong = {0}, MaBangGia = {1}, SoNguoiToiDa = {2} where MaTangLau = {3}",
               loaiPhongDTO.TenLoaiPhong,loaiPhongDTO.MaBangGia,loaiPhongDTO.SoLuongNguoiToiDa,loaiPhongDTO.MaLoaiPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Lấy lên thông tin loại phòng nằm cuối bảng.
        public object LayMaLoaiPhongCuoiBang()
        {
            string sql = string.Format("select MaLoaiPhong from LOAIPHONG where MaLoaiPhong = (select max(MaLoaiPhong) from LOAIPHONG)");
            return Connector.getFistObject(sql);
        }
    }
}
