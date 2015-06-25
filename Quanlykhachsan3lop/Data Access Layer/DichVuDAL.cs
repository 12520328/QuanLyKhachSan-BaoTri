using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class DichVuDAL
    {
        // Lấy danh sách dịch vụ từ cơ sở dữ liệu.
        public DataTable LayDanhSach()
        {
            string sql = "select * from DICHVU";
            return Connector.getDataTable(sql);
        }

        // Thêm một dịch vụ vào cơ sở dữ liệu.
        public void insert(DichVuDTO dvDTO)
        {
            string sql;
            sql = string.Format("insert into DICHVU(TenDichVu, DonGia, MaDonViTinh, NhomDichVu) Values(N'{0}', {1}, {2}, {3})", dvDTO.TenDichVu, dvDTO.DonGia, dvDTO.MaDonViTinh, dvDTO.NhomDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một dịch vụ khỏi cơ sở dữ liệu.
        public void delete(DichVuDTO dvDTO)
        {
            string sql = string.Format("delete from DICHVU where MaDichVu = {0}", dvDTO.MaDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin một dịch vụ.
        public void update(DichVuDTO dvDTO)
        {
            string sql;
            sql = string.Format("update DICHVU set TenDichVu = N'{0}', DonGia = {1}, MaDonViTinh = {2}, NhomDichVu = {3} where MaDichVu = {4}", dvDTO.TenDichVu, dvDTO.DonGia, dvDTO.MaDonViTinh, dvDTO.NhomDichVu, dvDTO.MaDichVu);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
