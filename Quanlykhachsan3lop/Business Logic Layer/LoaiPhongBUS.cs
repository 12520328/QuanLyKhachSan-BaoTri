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
    public class LoaiPhongBUS
    {
         private LoaiPhongDAL loaiPhongDAL;       

        public LoaiPhongBUS()
        {
            loaiPhongDAL = new LoaiPhongDAL();
        }

        // Lấy danh sách loại phòng
        public DataTable LayDanhSachLoaiPhong()
        {
            return loaiPhongDAL.LayDanhSachLoaiPhong();
        }

        //Thêm một loại phòng vào cơ sở dữ liệu.
        public bool Insert(LoaiPhongDTO loaiPhongDTO)
        {
            if (loaiPhongDTO == null)
                return false;
            loaiPhongDAL.Insert(loaiPhongDTO);
            return true;
        }

        // Xóa một loại phòng khỏi cơ sở dữ liệu.
        public void Delete(int maLoaiPhong)
        {
            loaiPhongDAL.Delete(maLoaiPhong);
        }

        // Sửa thông tin một loại phòng.
        public bool Update(LoaiPhongDTO loaiPhongDTO)
        {
            if (loaiPhongDTO == null)
                return false;
            loaiPhongDAL.Update(loaiPhongDTO);
            return true;
        }
    }
}
