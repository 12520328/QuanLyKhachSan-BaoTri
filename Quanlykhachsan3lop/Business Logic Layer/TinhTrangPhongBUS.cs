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
        private TinhTrangPhongDAL ttpDAL;

        public TinhTrangPhongBUS()
        {
            ttpDAL = new TinhTrangPhongDAL();
        }

        // Lấy danh sách tình trạng phòng
        public DataTable LayDanhSach()
        {
            return ttpDAL.LayDanhSach();
        }

        //Thêm một tình trạng phòng vào cơ sở dữ liệu.
        public void insert(TinhTrangPhongDTO ttpDTO)
        {
            ttpDAL.insert(ttpDTO);
        }

        // Xóa một tình trạng phòng khỏi cơ sở dữ liệu.
        public void delete(TinhTrangPhongDTO ttpDTO)
        {
            ttpDAL.delete(ttpDTO);
        }

        // Sửa thông tin một tình trạng phòng.
        public void update(TinhTrangPhongDTO ttpDTO)
        {
            ttpDAL.update(ttpDTO);
        }
    }
}
