using Quanlykhachsan3lop.Data_Access_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Business_Logic_Layer
{
    public class HoaDonBUS
    {
        HoaDonDAL hd = new HoaDonDAL();
        public void Insert(HoaDonDTO hdDTO)
        {
            hd.Insert(hdDTO);
            hdDTO.MaHoaDon = hd.LayMaHoaDonMoiThemVao();
            ChiTietHoaDonDAL cthdDAL = new ChiTietHoaDonDAL();
            foreach (ChiTietHoaDonDTO ct in hdDTO.ChiTietHoaDon)
            {
                ct.MaHoaDon = hdDTO.MaHoaDon;
                cthdDAL.Insert(ct);
            }
        }

        public DataTable LayThongTinThuePhong(int MaThuePhong)
        {
            return hd.LayThongTinThuePhong(MaThuePhong);
        }
    }
}
