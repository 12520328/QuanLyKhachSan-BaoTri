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
    public class ChuyenPhongBUS
    {
        ChuyenPhongDAL chuyenPhongDAL;
        public ChuyenPhongBUS()
        {
            chuyenPhongDAL = new ChuyenPhongDAL();
        }

        public DataTable LayDanhSachChuyenPhong()
        {
            return chuyenPhongDAL.LayDanhSachChuyenPhong();
        }

        public void Insert(ChuyenPhongDTO chuyenPhongDTO)
        {
            chuyenPhongDAL.Insert(chuyenPhongDTO);
        }

        public void Delete(int MaChuyenPhong)
        {
            chuyenPhongDAL.Delete(MaChuyenPhong);
        }

        public void Update(ChuyenPhongDTO chuyenPhongDTO)
        {
            chuyenPhongDAL.Update(chuyenPhongDTO);
        }
    }
}
