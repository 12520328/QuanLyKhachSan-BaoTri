using DevExpress.XtraEditors;
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

        public DataTable LayDanhSachTenLoaiGia()
        {
            return loaiGiaDAL.LayDanhSachTenLoaiGia();
        }
        // Lấy danh sách loại giá phụ thu.
        public DataTable LayDanhSachLoaiGia()
        {
            return loaiGiaDAL.LayDanhSachLoaiGia();
        }

        //Thêm một loại giá vào cơ sở dữ liệu.
        public bool Insert(LoaiGiaDTO loaiGiaDTO)
        {
            if (loaiGiaDTO == null)
            {
                return false;
            }
            if (TonTaiTenLoaiGia(loaiGiaDTO.TenLoaiGia) == true)
            {
                XtraMessageBox.Show("Tên loại giá bạn nhập đã tồn tại. Vui lòng nhập tên khác.", "Thông Báo Lỗi");
                return false;
            }
            loaiGiaDAL.Insert(loaiGiaDTO);
            return true;
        }

        // Xóa một loại giá khỏi cơ sở dữ liệu.
        public void Delete(int maLoaiGia)
        {
            loaiGiaDAL.Delete(maLoaiGia);
        }

        // Sửa thông tin một loại giá.
        public bool Update(LoaiGiaDTO loaiGiaDTO)
        {
            if(loaiGiaDTO == null)
            {
                return false;
            }
            try
            {
                loaiGiaDAL.Update(loaiGiaDTO);

            }
            catch
            {
                XtraMessageBox.Show("Tên bảng giá bạn nhập đã tồn tại. Vui lòng nhập lại.", "Thông Báo");
            }
            return true;
        }
      
        //Kiểm tra tồn tại tên loại giá
        public bool TonTaiTenLoaiGia(string TenLoaiGia)
        {
            return loaiGiaDAL.TonTaiTenLoaiGia(TenLoaiGia);
        }
    }
}
