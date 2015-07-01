using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class TinhTrangPhongDAL
    {
        // Lấy danh sách tình trạng phòng từ cơ sở dữ liệu.
        public DataTable LayDanhSach()
        {
            string sql = "select * from TINHTRANGPHONG";
            return Connector.getDataTable(sql);
        }

        // Thêm một tình trạng phòng vào cơ sở dữ liệu.
        public void insert(TinhTrangPhongDTO ttpDTO)
        {
            string sql;
            sql = string.Format("insert into TINHTRANGPHONG(TenTinhTrangPhong, HinhAnh, MauSac) Values(N'{0}', '{1}', {2})", ttpDTO.TenTinhTrangPhong, ttpDTO.HinhAnh, ttpDTO.MauSac);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một tình trạng phòng khỏi cơ sở dữ liệu.
        public void delete(TinhTrangPhongDTO ttpDTO)
        {
            string sql = string.Format("delete from TINHTRANGPHONG where MaTinhTrangPhong = {0}", ttpDTO.MaTinhTrangPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin một tình trạng phòng.
        public void update(TinhTrangPhongDTO ttpDTO)
        {
            string sql;
            sql = string.Format("update TINHTRANGPHONG set TenTinhTrangPhong = N'{0}', HinhAnh = '{1}', MauSac = {2} where MaTinhTrangPhong = {3}", ttpDTO.TenTinhTrangPhong, ttpDTO.HinhAnh, ttpDTO.MauSac, ttpDTO.MaTinhTrangPhong);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
