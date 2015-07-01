using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class KhuyenMaiDAL
    {
        // Lấy danh sách Khuyến mãi từ cơ sở dữ liệu.
        public DataTable LayDanhSach()
        {
            string sql = "select * from KHUYENMAI";
            return Connector.getDataTable(sql);
        }

        // Thêm một Khuyến mãi vào cơ sở dữ liệu.
        public void insert(KhuyenMaiDTO kmDTO)
        {
            string sql;
            sql = string.Format("insert into KHUYENMAI(TenKhuyenMai, LoaiKhuyenMai, CongThuc) Values(N'{0}', N'{1}', '{2}')", kmDTO.TenKhuyenMai, kmDTO.LoaiKhuyenMai, kmDTO.CongThuc);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một Khuyến mãi khỏi cơ sở dữ liệu.
        public void delete(KhuyenMaiDTO kmDTO)
        {
            string sql = string.Format("delete from KHUYENMAI where MaKhuyenMai = {0}", kmDTO.MaKhuyenMai);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin một Khuyến mãi.
        public void update(KhuyenMaiDTO kmDTO)
        {
            string sql;
            sql = string.Format("update KHUYENMAI set TenKhuyenMai = N'{0}', LoaiKhuyenMai = '{1}', CongThuc = '{2}' where MaKhuyenMai = {3}", kmDTO.TenKhuyenMai, kmDTO.LoaiKhuyenMai, kmDTO.CongThuc, kmDTO.MaKhuyenMai);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
