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
    class TangLauBUS
    {
        private TangLauDAL tangLauDAL;

        public TangLauBUS()
        {
            tangLauDAL = new TangLauDAL();
        }

        // Lấy danh sách tầng lầu.
        public DataTable LayDanhSachTangLau()
        {
            return tangLauDAL.LayDanhSachTangLau();
        }

        //Thêm một tầng lầu vào cơ sở dữ liệu.
        public void ThemTangLau(TangLauDTO tangLauDTO)
        {
            tangLauDAL.ThemTangLau(tangLauDTO);
        }

        // Xóa một tầng lầu khỏi cơ sở dữ liệu.
        public void XoaTangLau(TangLauDTO tangLauDTO)
        {
            tangLauDAL.XoaTangLau(tangLauDTO);
        }

        // Sửa thông tin một tầng lầu.
        public void SuaTangLau(TangLauDTO tangLauDTO)
        {
            tangLauDAL.SuaTangLau(tangLauDTO);
        }

        // Lấy MaTangLau cuối cùng trong bảng.
        public object LayMaTangLauCuoiBang()
        {
            return tangLauDAL.LayMaTangLauCuoiBang();
        }
    }
}
