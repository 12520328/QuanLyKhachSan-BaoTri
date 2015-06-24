using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class DonViTinhDAL
    {
        // Lấy danh sách đơn vị tính từ cơ sở dữ liệu.
        public DataTable LayDanhSachDonViTinh()
        {
            string sql = "select * from DONVITINH";
            return Connector.getDataTable(sql);
        }

        // Thêm một đơn vị tính vào cơ sở dữ liệu.
        public void Insert(DonViTinhDTO donViTinhDTO)
        {
            string sql = string.Format("insert into DONVITINH(TenDonViTinh,GhiChu) Values(N'{0}',N'{1}')",
                donViTinhDTO.TenDonVi, donViTinhDTO.GhiChu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một đơn vị tính khỏi cơ sở dữ liệu.
        public void Delete(int maDonViTinh)
        {
            string sql = string.Format("delete from DONVITINH where MaDonViTinh = {0}", maDonViTinh);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một đơn vị tính.
        public void Update(DonViTinhDTO donViTinhDTO)
        {
            string sql = string.Format("update DONVITINH set TenDonViTinh = N'{0}', GhiChu = N'{1}' where MaDonViTinh = {2}",
                donViTinhDTO.TenDonVi, donViTinhDTO.GhiChu,donViTinhDTO.MaDonVi);
            Connector.ExecuteNonQuery(sql);
        }           
    }
}
