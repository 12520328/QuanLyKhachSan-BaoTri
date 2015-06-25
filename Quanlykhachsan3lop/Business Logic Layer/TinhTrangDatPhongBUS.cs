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
    class TinhTrangDatPhongBUS
    {
        private TinhTrangDatPhongDAL ttdpDAL;

        public TinhTrangDatPhongBUS()
        {
            ttdpDAL = new TinhTrangDatPhongDAL();
        }

        // Lấy danh sách tình trạng đặt phòng.
        public DataTable LayDanhSachTinhTrangDatPhong()
        {
            return ttdpDAL.LayDanhSachTinhTrangDatPhong();
        }

        //Thêm một tầng lầu vào cơ sở dữ liệu.
        public void ThemTinhTrangDatPhong(TinhTrangDatPhongDTO ttdpDTO)
        {
            ttdpDAL.ThemTinhTrangDatPhong(ttdpDTO);
        }

        // Xóa một tầng lầu khỏi cơ sở dữ liệu.
        public void XoaTinhTrangDatPhong(TinhTrangDatPhongDTO TinhTrangDatPhongDTO)
        {
            ttdpDAL.XoaTinhTrangDatPhong(TinhTrangDatPhongDTO);
        }

        // Sửa thông tin một tầng lầu.
        public void SuaTinhTrangDatPhong(TinhTrangDatPhongDTO TinhTrangDatPhongDTO)
        {
            ttdpDAL.SuaTinhTrangDatPhong(TinhTrangDatPhongDTO);
        }

        // Lấy MaTinhTrangDatPhong cuối cùng trong bảng.
        public object LayMaTinhTrangDatPhongCuoiBang()
        {
            return ttdpDAL.LayMaTinhTrangCuoiBang();
        }
    }
}
