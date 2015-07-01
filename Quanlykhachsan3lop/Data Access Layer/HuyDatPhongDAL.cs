using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class HuyDatPhongDAL
    {
        //Lấy danh sach hủy đặt phòng

        public DataTable LayDanhSachPhieuHuyDatPhong()
        {
            string sql = "select * from HUYDATPHONG";
            return Connector.getDataTable(sql);
        }

        // Thêm một phiếu hủy đặt phòng vào cơ sở dữ liệu.
        public void Insert(HuyDatPhongDTO huyDatPhongDTO)
        {
            string sql = string.Format("insert into HUYDATPHONG(MaDatPhong,NgayHuy,GhiChu) Values({0},'{1}',N'{2}')",
                                huyDatPhongDTO.MaDatPhong,huyDatPhongDTO.NgayHuy,huyDatPhongDTO.GhiChu);
       
            Connector.ExecuteNonQuery(sql);
        }

    }
}
