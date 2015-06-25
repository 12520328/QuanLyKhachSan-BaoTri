using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class VatTuDAL
    {
        // Lấy danh sách vật tư từ cơ sở dữ liệu.
        public DataTable LayDanhSachVatTu()
        {
            string sql = "select * from VATTU";
            return Connector.getDataTable(sql);
        }

        // Thêm một vật tư vào cơ sở dữ liệu.
        public void ThemVatTu(VatTuDTO vtDTO)
        {
            string sql;
            sql = string.Format("insert into VATTU(TenVatTu, SoLuong, GhiChu) Values('{0}', {1}, '{2}')", vtDTO.TenVatTu, vtDTO.SoLuong, vtDTO.GhiChu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một vật tư khỏi cơ sở dữ liệu.
        public void XoaVatTu(VatTuDTO vtDTO)
        {
            string sql = string.Format("delete from VATTU where MaVatTu = {0}", vtDTO.MaVatTu);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin một vật tư.
        public void SuaVatTu(VatTuDTO vtDTO)
        {
            string sql;
            sql = string.Format("update VATTU set TenVatTu = '{0}', SoLuong = {1}, GhiChu = '{2}' where MaVatTu = {3}", vtDTO.TenVatTu, vtDTO.SoLuong, vtDTO.GhiChu, vtDTO.MaVatTu);
            Connector.ExecuteNonQuery(sql);
        }

        // Lấy lên thông tin vật tư nằm cuối bảng.
        public object LayMaVatTuCuoiBang()
        {
            string sql = string.Format("select MaVatTu from VATTU where MaVatTu = (select max(MaVatTu) from VATTU)");
            return Connector.getFistObject(sql);
        }
    }
}
