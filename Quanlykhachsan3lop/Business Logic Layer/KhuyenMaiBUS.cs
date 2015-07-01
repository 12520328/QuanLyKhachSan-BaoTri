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
    class KhuyenMaiBUS
    {
        private KhuyenMaiDAL kmDAL;

        public KhuyenMaiBUS()
        {
            kmDAL = new KhuyenMaiDAL();
        }

        // Lấy danh sách khuyến mãi
        public DataTable LayDanhSach()
        {
            return kmDAL.LayDanhSach();
        }

        //Thêm một khuyến mãi vào cơ sở dữ liệu.
        public void insert(KhuyenMaiDTO kmDTO)
        {
            kmDAL.insert(kmDTO);
        }

        // Xóa một khuyến mãi khỏi cơ sở dữ liệu.
        public void delete(KhuyenMaiDTO kmDTO)
        {
            kmDAL.delete(kmDTO);
        }

        // Sửa thông tin một khuyến mãi.
        public void update(KhuyenMaiDTO kmDTO)
        {
            kmDAL.update(kmDTO);
        }
    }
}
