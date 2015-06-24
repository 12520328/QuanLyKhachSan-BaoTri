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
    public class TinhTrangPhongBUS
    {
        private TinhTrangPhongDAL tinhTrangPhongDAL;       

        public TinhTrangPhongBUS()
        {
            tinhTrangPhongDAL = new TinhTrangPhongDAL();
        }

        // Lấy danh sách tình trạng phòng phụ thu.
        public DataTable LayDanhSachTinhTrangPhong()
        {
            return tinhTrangPhongDAL.LayDanhSachTinhTrangPhong();
        }

        //Thêm một tình trạng phòng vào cơ sở dữ liệu.
        public bool Insert(TinhTrangPhongDTO tinhTrangPhongDTO)
        {
            return tinhTrangPhongDAL.Insert(tinhTrangPhongDTO);
        }

        // Xóa một tình trạng phòng khỏi cơ sở dữ liệu.
        public bool Delete(TinhTrangPhongDTO tinhTrangPhongDTO)
        {
            return tinhTrangPhongDAL.Delete(tinhTrangPhongDTO);
        }

        // Sửa thông tin một tình trạng phòng.
        public bool Update(TinhTrangPhongDTO tinhTrangPhongDTO)
        {
            return tinhTrangPhongDAL.Update(tinhTrangPhongDTO);
        }

        // Lấy MaTinhTrangPhong cuối cùng trong bảng.
        public object LayMaTinhTrangPhongCuoiBang()
        {
            return tinhTrangPhongDAL.LayMaTinhTrangPhongCuoiBang();
        }
    }
}
