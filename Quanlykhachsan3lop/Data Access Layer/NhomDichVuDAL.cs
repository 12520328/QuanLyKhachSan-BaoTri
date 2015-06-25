using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class NhomDichVuDAL
    {
        // Lấy danh sách nhóm dịch vụ từ cơ sở dữ liệu.
        public DataTable LayDanhSachNhomDichvu()
        {
            string sql = "select * from NHOMDICHVU";
            return Connector.getDataTable(sql);
        }

        // Thêm một nhóm dịch vụ vào cơ sở dữ liệu.
        public void ThemNhomDichvu(NhomDichVuDTO ndvDTO)
        {
            string sql;
            sql = string.Format("insert into NHOMDICHVU(TenNhomDichVu) Values('{0}')", ndvDTO.TenNhomDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một nhóm dịch vụ khỏi cơ sở dữ liệu.
        public void XoaNhomDichVu(NhomDichVuDTO ndvDTO)
        {
            string sql = string.Format("delete from NHOMDICHVU where NhomDichVu = {0}", ndvDTO.NhomDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin một nhóm dịch vụ.
        public void SuaNhomDichVu(NhomDichVuDTO ndvDTO)
        {
            string sql;
            sql = string.Format("update NHOMDICHVU set TenNhomDichVu = '{0}' where NhomDichVu = {1}", ndvDTO.TenNhomDichVu, ndvDTO.NhomDichVu);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
