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
    class PhongBUS
    {
        #region
        private PhongDAL pDAL;

        public PhongBUS()
        {
            pDAL = new PhongDAL();
        }

        // Lấy danh sách phòng
        public DataTable LayDanhSach()
        {
            return pDAL.LayDanhSach();
        }
        public DataTable LayDanhSach(int MaPhong)
        {
            return pDAL.LayDanhSach(MaPhong);
        }
        public int LayMaThamChieu(int MaPhong)
        {
            return pDAL.LayMaThamChieu(MaPhong);
        }
        public DataTable LayDanhSachPhong(int TinhTrangPhong)
        {
            return pDAL.LayDanhSachPhong(TinhTrangPhong);
        }

        public void Insert(PhongDTO pDTO)
        {
            pDAL.Insert(pDTO);
        }
        public void Update(PhongDTO pDTO)
        {
            pDAL.Update(pDTO);
        }
        // Xóa một phòng khỏi cơ sở dữ liệu.
        public void delete(int pDTO)
        {
            pDAL.Delete(pDTO);
        }
        public void UpdateTinhTrangPhong(int TinhTrangPhong, int MaPhong)
        {
            pDAL.UpdateTinhTrangPhong(TinhTrangPhong, MaPhong);
        }
        public void UpdateMaThamChieu(int MathamChieu, int MaPhong)
        {
            pDAL.UpdateMaThamChieu(MathamChieu, MaPhong);
        }
        public void UpdateThongTinPhong(string ThongTinPhong, int MaPhong)
        {
            pDAL.UpdateThongTinPhong(ThongTinPhong, MaPhong);
        }
        #endregion


        //Lây dánh sách phòng cho thuê
        public DataTable LayDanhSachPhongChoThue()
        {
            return pDAL.LayDanhSachPhongChoThue();
        }
        public DataTable LayDanhSachPhongChoThue(int MaPhong)
        {
            return pDAL.LayDanhSachPhongChoThue(MaPhong);
        }
        //Thêm một phòng vào cơ sở dữ liệu.
        public void insert(PhongDTO pDTO)
        {
            pDAL.insert(pDTO);
        }

       
        // Sửa thông tin một phòng.
        public void update(PhongDTO pDTO)
        {
            pDAL.update(pDTO);
        }

        public void UpdateTinhTrangO(int TinhTrangO, int MaPhong)
        {
            pDAL.UpdateTinhTrangO(TinhTrangO, MaPhong);
        }

        //Lấy màu sắc tình trạng
        public int LayMauSac(int maPhong)
        {
            return pDAL.LayMauSac(maPhong);
        }
    }
}
