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
    public class ChinhSachBUS
    {
        private ChinhSachDAL chinhSachDAL;       

        public ChinhSachBUS()
        {
            chinhSachDAL = new ChinhSachDAL();
        }

        // Lấy danh sách chính sách phụ thu.
        public DataTable LayDanhSachChinhSach()
        {
            return chinhSachDAL.LayDanhSachChinhSach();
        }

        //Thêm một chính sách vào cơ sở dữ liệu.
        public void Insert(ChinhSachDTO chinhSachDTO)
        {
            chinhSachDAL.Insert(chinhSachDTO);
        }

        // Xóa một chính sách khỏi cơ sở dữ liệu.
        public void Delete(ChinhSachDTO chinhSachDTO)
        {
            chinhSachDAL.Delete(chinhSachDTO);
        }

        // Sửa thông tin một chính sách.
        public void Update(ChinhSachDTO chinhSachDTO)
        {
            chinhSachDAL.Update(chinhSachDTO);
        }

        // Lấy MaChinhSach cuối cùng trong bảng.
        public object LayMaChinhSachCuoiBang()
        {
            return chinhSachDAL.LayMaChinhSachCuoiBang();
        }
    }
}
