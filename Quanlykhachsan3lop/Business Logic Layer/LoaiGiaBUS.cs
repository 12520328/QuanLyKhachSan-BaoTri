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
    public class LoaiGiaBUS
    {
         private LoaiGiaDAL loaiGiaDAL;       

        public LoaiGiaBUS()
        {
            loaiGiaDAL = new LoaiGiaDAL();
        }

        // Lấy danh sách loại giá phụ thu.
        public DataTable LayDanhSachLoaiGia()
        {
            return loaiGiaDAL.LayDanhSachLoaiGia();
        }

        //Thêm một loại giá vào cơ sở dữ liệu.
        public void Insert(LoaiGiaDTO loaiGiaDTO)
        {
            loaiGiaDAL.Insert(loaiGiaDTO);
        }

        // Xóa một loại giá khỏi cơ sở dữ liệu.
        public void Delete(LoaiGiaDTO loaiGiaDTO)
        {
            loaiGiaDAL.Delete(loaiGiaDTO);
        }

        // Sửa thông tin một loại giá.
        public void Update(LoaiGiaDTO loaiGiaDTO)
        {
            loaiGiaDAL.Update(loaiGiaDTO);
        }

        // Lấy MaLoaiGia cuối cùng trong bảng.
        public object LayMaLoaiGiaCuoiBang()
        {
            return loaiGiaDAL.LayMaLoaiGiaCuoiBang();
        }
        //Kiểm tra tồn tại tên loại giá
        public bool TonTaiTenLoaiGia(string TenLoaiGia)
        {
            return loaiGiaDAL.TonTaiTenLoaiGia(TenLoaiGia);
        }
    }
}
