using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class QuanLyVatTuDAL
    {
        // Lấy danh sách quản lý vật tư từ cơ sở dữ liệu.
        public DataTable LayDanhSachQuanLyVatTu()
        {
            string sql = "select * from QUANLYVATTU";
            return Connector.getDataTable(sql);
        }

        public DataTable LayDanhSachQuanLyVatTu(int MaLoaiPhong)
        {
            string sql =string.Format( "select VATTU.TenVatTu from QUANLYVATTU INNER JOIN VATTU ON VATTU.MaVatTu = QUANLYVATTU.MaVatTu where QUANLYVATTU.MaLoaiPhong = {0}",MaLoaiPhong);
            return Connector.getDataTable(sql);
        }
        // Thêm một quản lý vật tư vào cơ sở dữ liệu.
        public void Insert(QuanLyVatTuDTO quanLyVatTuDTO)
        {
            string sql = string.Format("insert into QUANLYVATTU(MaLoaiPhong,MaVatTu,SoLuong,GhiChu) Values({0},{1},{2},N'{3}')",
                quanLyVatTuDTO.MaLoaiPhong, quanLyVatTuDTO.MaVatTu, quanLyVatTuDTO.SoLuong,quanLyVatTuDTO.GhiChu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một quản lý vật tư khỏi cơ sở dữ liệu.
        public void Delete(int maQuanLyVatTu)
        {
            string sql = string.Format("delete from QUANLYVATTU where MaQuanLyVatTu = {0}", maQuanLyVatTu);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một quản lý vật tư.
        public void Update(QuanLyVatTuDTO quanLyVatTuDTO)
        {
            string sql = string.Format("update QUANLYVATTU set MaLoaiPhong = {0}, MaVatTu = {1}, SoLuong = {2}, GhiChu = 'N{3}' where MaQuanLyVatTu = {4}",
               quanLyVatTuDTO.MaLoaiPhong, quanLyVatTuDTO.MaVatTu, quanLyVatTuDTO.SoLuong,quanLyVatTuDTO.GhiChu, quanLyVatTuDTO.MaQuanLyVatTu);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
