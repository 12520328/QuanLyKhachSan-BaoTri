using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChiTietHoaDonDAL
    {
        public void Insert(ChiTietHoaDonDTO cthoaDonDTO)
        {
            string sql = string.Format("insert into CHITIETHOADON(MaHoaDon,MaPhong,SoNgayO,TienPhong) values ({0},{1},{2},{3})",
                cthoaDonDTO.MaHoaDon, cthoaDonDTO.MaPhong, cthoaDonDTO.SoNgayO, cthoaDonDTO.TienPhong);
            Connector.ExecuteNonQuery(sql);
        }

        public DataTable LayDanhSachChiTietHoaDon()
        {
            string sql = string.Format("select * from CHITIETHOADON");
            return Connector.getDataTable(sql);
        }
    }
}
