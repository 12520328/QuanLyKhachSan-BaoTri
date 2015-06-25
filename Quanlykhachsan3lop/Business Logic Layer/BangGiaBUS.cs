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
    public class BangGiaBUS
    {    
        private BangGiaDAL bangGiaDAL;
        private ChiTietBangGiaDAL chiTietBangGiaDAL;

        public BangGiaBUS()
        {
            bangGiaDAL = new BangGiaDAL();
            chiTietBangGiaDAL = new ChiTietBangGiaDAL();
        }

        public DataTable LayDanhSachTenBangGia()
        {
            return bangGiaDAL.LayDanhSachTenBangGia();
        }
        // Lấy danh sách bảng giá 
        public DataTable LayDanhSachBangGia()
        {
            return bangGiaDAL.LayDanhSachBangGia();
        }

        //Thêm một bảng giá vào cơ sở dữ liệu.
        public bool Insert(BangGiaDTO bangGiaDTO)
        {
            if (bangGiaDTO == null)
            {
                return false;
            }
            if (TonTaiTenBangGia(bangGiaDTO.TenBangGia) == true)
            {
                XtraMessageBox.Show("Tên bảng giá bạn nhập đã tồn tại. Vui lòng nhập lại.", "Thông Báo Lỗi");
                return false;
            }
            bangGiaDAL.Insert(bangGiaDTO);
            //Lấy Mã Bàng Giá vừa thêm Vào
            bangGiaDTO.MaBangGia = LayMaBangGia(bangGiaDTO.TenBangGia);
            //Cập nhật chi tiết bảng giá
            foreach (ChiTietBangGiaDTO ct in bangGiaDTO.ChiTietBangGia)
            {
                ct.MaBangGia = bangGiaDTO.MaBangGia;
                chiTietBangGiaDAL.Insert(ct);
            }
            return true;
        }

        // Xóa một bảng giá khỏi cơ sở dữ liệu.
        public void Delete(int maBangGia)
        {
            bangGiaDAL.Delete(maBangGia);
        }

        // Sửa thông tin một bảng giá.
        public bool Update(BangGiaDTO bangGiaDTO)
        {
            if(bangGiaDTO == null)
            {
                return false;
            }
            try
            {
                bangGiaDAL.Update(bangGiaDTO);

            }
            catch
            {
                XtraMessageBox.Show("Tên bảng giá bạn nhập đã tồn tại. Vui lòng nhập lại.", "Thông Báo");
            }
            return true;
        }
      
        //Kiểm tra tồn tại tên bảng giá
        public bool TonTaiTenBangGia(string TenBangGia)
        {
            return bangGiaDAL.TonTaiTenBangGia(TenBangGia);
        }

        //Lấy mã bảng giá theo tên
        public int LayMaBangGia(string TenBangGia)
        {
            return int.Parse(bangGiaDAL.LayMaBangGia(TenBangGia).ToString());
        }
    }
}
