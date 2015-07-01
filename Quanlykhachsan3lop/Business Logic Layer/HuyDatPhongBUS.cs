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
    public class HuyDatPhongBUS
    {
        HuyDatPhongDAL h = new HuyDatPhongDAL();
        public DataTable LayDanhSachPhieuThuePhong()
        {
            return h.LayDanhSachPhieuHuyDatPhong();
        }

        public void Insert(HuyDatPhongDTO hDTO)
        {
             h.Insert(hDTO);
        }
    }
}
