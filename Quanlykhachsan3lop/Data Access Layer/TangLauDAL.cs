using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class TangLauDAL
    {
        // Lấy danh sách tầng lầu từ cơ sở dữ liệu.
        public DataTable LayDanhSachTangLau()
        {
            string sql = "select * from TANGLAU";
            return Connector.getDataTable(sql);
        }

        // Thêm một tầng lầu vào cơ sở dữ liệu.
        public void ThemTangLau(TangLauDTO tangLauDTO)
        {
            string sql = string.Format("insert into TANGLAU(TenTangLau) Values('{0}')", tangLauDTO.TenTangLau);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một tầng lầu khỏi cơ sở dữ liệu.
        public void XoaTangLau(TangLauDTO tangLauDTO)
        {
            string sql = string.Format("delete from TANGLAU where MaTangLau = {0}", tangLauDTO.MaTangLau);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một tầng lầu.
        public void SuaTangLau(TangLauDTO tangLauDTO)
        {
            string sql = string.Format("update TANGLAU set TenTangLau = '{0}' where MaTangLau = {1}", tangLauDTO.TenTangLau, tangLauDTO.MaTangLau);
            Connector.ExecuteNonQuery(sql);
        }

        // Lấy lên thông tin tầng lầu nằm cuối bảng.
        public object LayMaTangLauCuoiBang()
        {
            string sql = string.Format("select MaTangLau from TANGLAU where MaTangLau = (select max(MaTangLau) from TANGLAU)");
            return Connector.getFistObject(sql);
        }
    }
}
