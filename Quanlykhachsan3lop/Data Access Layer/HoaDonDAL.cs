using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class HoaDonDAL
    {
        public void Insert(HoaDonDTO hoaDonDTO)
        {
            string sql = string.Format("insert into HOADON(SoHoaDon,MaKhachHang,MaDatPhong,TongTien,NgayLap,MaSuDungDichVu) values ({0},{1},{2},{3},{4},{5})",
                hoaDonDTO.SoHoaDon, hoaDonDTO.MaKhachHang, hoaDonDTO.MaDatPhong, hoaDonDTO.TongTien, hoaDonDTO.NgayLap, hoaDonDTO.MaSuDungDichVu);
            Connector.ExecuteNonQuery(sql);
        }

        public DataTable LayThongTinThuePhong(int MaThuePhong)
        {
            string sql = string.Format("select * from PHONG as p INNER JOIN LOAIPHONG as lp ON	p.MaLoaiPhong = lp.MaLoaiPhong INNER JOIN CHITIETTHUEPHONG as cttp ON p.MaPhong = cttp.MaPhong INNER JOIN THUEPHONG as tp ON cttp.MaThuePhong = tp.MaThuePhong WHERE tp.MaThuePhong = {0}",MaThuePhong);
            return Connector.getDataTable(sql);
        }

        public DataTable LayDanhSachHoaDon()
        {
            string sql = string.Format("select * from HOADON");
            return Connector.getDataTable(sql);
        }

        public int LayMaHoaDonMoiThemVao()
        {
            string sql = string.Format("select ");
            return int.Parse(Connector.getFistObject(sql).ToString());
        }
    }
}
