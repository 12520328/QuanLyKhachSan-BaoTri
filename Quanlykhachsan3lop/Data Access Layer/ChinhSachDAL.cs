using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class ChinhSachDAL
    {
        // Lấy danh sách các chính sách từ cơ sở dữ liệu.
        public DataTable LayDanhSachChinhSach()
        {
            string sql = "select * from CHINHSACH";
            return Connector.getDataTable(sql);
        }

        // Thêm một chính sách vào cơ sở dữ liệu.
        public void Insert(ChinhSachDTO chinhSachDTO)
        {
            string sql = string.Format("insert into CHINHSACH(ThoiGianQuyDinh, PhuThu) Values('{0}','{1}')", chinhSachDTO.ThoiGianQuyDinh, chinhSachDTO.PhuThu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một chính sách khỏi cơ sở dữ liệu.
        public void Delete(ChinhSachDTO chinhSachDTO)
        {
            string sql = string.Format("delete from CHINHSACH where MaChinhSach = {0}", chinhSachDTO.MaChinhSach);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một chính sách.
        public void Update(ChinhSachDTO chinhSachDTO)
        {
            string sql = string.Format("update CHINHSACH set ThoiGianQuyDinh = '{0}', PhuThu = '{1}' where MaChinhSach = {2}", chinhSachDTO.ThoiGianQuyDinh, chinhSachDTO.PhuThu, chinhSachDTO.MaChinhSach);
            Connector.ExecuteNonQuery(sql);
        }

        // Lấy lên thông tin chính sách nằm cuối bảng.
        public object LayMaChinhSachCuoiBang()
        {
            string sql = string.Format("select MaChinhSach from CHINHSACH where MaChinhSach = (select max(MaChinhSach) from CHINHSACH)");
            return Connector.getFistObject(sql);
        }
    }
}
