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
        public DataTable LayDanhSachTinhTrangPhong()
        {
            string sql = "select * from TINHTRANGPHONG";
            return Connector.getDataTable(sql);
        }

        // Thêm một tình trạng phòng vào cơ sở dữ liệu.
        public bool Insert(TinhTrangPhongDTO tinhTrangPhongDTO)
        {
            string sql = string.Format("insert into TINHTRANGPHONG(TenLoaiTinhTrangPhong,HinhAnh,MauSac) Values('{0}','{1}','{2}')",
                tinhTrangPhongDTO.TenTinhTrangPhong, tinhTrangPhongDTO.HinhAnh, tinhTrangPhongDTO.MauSac);
            Connector.ExecuteNonQuery(sql);
            return true;
        }

        // Xóa một tình trạng phòng khỏi cơ sở dữ liệu.
        public bool Delete(TinhTrangPhongDTO tinhTrangPhongDTO)
        {
            string sql = string.Format("delete from TINHTRANGPHONG where MaTinhTrangPhong = {0}", tinhTrangPhongDTO.MaTinhTrangPhong);
            Connector.ExecuteNonQuery(sql);
            return true;
        }

        // Sưa thông tin một tình trạng phòng.
        public bool Update(TinhTrangPhongDTO tinhTrangPhongDTO)
        {
            string sql = string.Format("update TINHTRANGPHONG set TenLoaiTinhTrangPhong = '{0}', HinhAnh = '{1}', MauSac = '{2}' where MaTinhTrangPhong = {2}",
               tinhTrangPhongDTO.TenTinhTrangPhong, tinhTrangPhongDTO.HinhAnh, tinhTrangPhongDTO.MauSac, tinhTrangPhongDTO.MaTinhTrangPhong);
            Connector.ExecuteNonQuery(sql);
            return true;

        }

        // Lấy lên thông tin tình trạng phòng nằm cuối bảng.
        public object LayMaTinhTrangPhongCuoiBang()
        {
            string sql = string.Format("select MaTinhTrangPhong from TINHTRANGPHONG where MaTinhTrangPhong = (select max(MaTinhTrangPhong) from TINHTRANGPHONG)");
            return Connector.getFistObject(sql);
        }

    }
}
