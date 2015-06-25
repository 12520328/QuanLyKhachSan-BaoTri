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
    class VatTuBUS
    {
        private VatTuDAL vtDAL;

        public VatTuBUS()
        {
            vtDAL = new VatTuDAL();
        }

        // Lấy danh sách vật tư.
        public DataTable LayDanhSachVatTu()
        {
            return vtDAL.LayDanhSachVatTu();
        }

        //Thêm một vật tư vào cơ sở dữ liệu.
        public void ThemVatTu(VatTuDTO vtDTO)
        {
            vtDAL.ThemVatTu(vtDTO);
        }

        // Xóa một vật tư khỏi cơ sở dữ liệu.
        public void XoaVatTu(VatTuDTO vtDTO)
        {
            vtDAL.XoaVatTu(vtDTO);
        }

        // Sửa thông tin một vật tư.
        public void SuaVatTu(VatTuDTO vtDTO)
        {
            vtDAL.SuaVatTu(vtDTO);
        }

        // Lấy MaTinhTrangDatPhong cuối cùng trong bảng.
        public object LayMaVatTuCuoiBang()
        {
            return vtDAL.LayMaVatTuCuoiBang();
        }
    }
}
