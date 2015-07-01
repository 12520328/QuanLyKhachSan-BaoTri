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
    public class QuanLyVatTuBUS
    {
        private QuanLyVatTuDAL quanLyVatTuDAL;       

        public QuanLyVatTuBUS()
        {
            quanLyVatTuDAL = new QuanLyVatTuDAL();
        }

        // Lấy danh sách quản lý vật tư
        public DataTable LayDanhSachQuanLyVatTu()
        {
            return quanLyVatTuDAL.LayDanhSachQuanLyVatTu();
        }

        public DataTable LayDanhSachQuanLyVatTu(int MaLoaiPhong)
        {
            return quanLyVatTuDAL.LayDanhSachQuanLyVatTu(MaLoaiPhong);
        }

        //Thêm một quản lý vật tư vào cơ sở dữ liệu.
        public bool Insert(QuanLyVatTuDTO quanLyVatTuDTO)
        {
            if (quanLyVatTuDTO == null)
                return false;
            quanLyVatTuDAL.Insert(quanLyVatTuDTO);
            return true;
        }

        // Xóa một quản lý vật tư khỏi cơ sở dữ liệu.
        public void Delete(int maQuanLyVatTu)
        {
            quanLyVatTuDAL.Delete(maQuanLyVatTu);
        }

        // Sửa thông tin một quản lý vật tư.
        public bool Update(QuanLyVatTuDTO quanLyVatTuDTO)
        {
            if (quanLyVatTuDTO == null)
                return false;
            quanLyVatTuDAL.Update(quanLyVatTuDTO);
            return true;
        }
    }
}
