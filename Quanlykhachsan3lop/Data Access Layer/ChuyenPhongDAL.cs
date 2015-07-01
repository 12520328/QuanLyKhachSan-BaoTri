using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChuyenPhongDAL
    {
        // Lấy danh sách chuyển phòng  từ cơ sở dữ liệu.
        public DataTable LayDanhSachChuyenPhong()
        {
            string sql = "select * from CHUYENPHONG";
            return Connector.getDataTable(sql);
        }       
      

        // Thêm một chuyển phòng  vào cơ sở dữ liệu.
        public void Insert(ChuyenPhongDTO chuyenPhongDTO)
        {
            string sql = string.Format("insert into CHUYENPHONG(NgayChuyen,MaPhongCu,MaPhongMoi) Values('{0}',{1},{2})",
                chuyenPhongDTO.NgayChuyenPhong, chuyenPhongDTO.MaPhongCu,chuyenPhongDTO.MaPhongMoi);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một chuyển phòng  khỏi cơ sở dữ liệu.
        public void Delete(int maChuyenPhong)
        {
            string sql = string.Format("delete from CHUYENPHONG  where MaChuyenPhong = {0}", maChuyenPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một chuyển phòng .
        public void Update(ChuyenPhongDTO chuyenPhongDTO)
        {
            string sql = string.Format("update CHUYENPHONG  set NgayChuyen = '{0}', MaPhongCu = {1}, MaPhongMoi = {2} where MaChuyenPhong = {3}",
               chuyenPhongDTO.NgayChuyenPhong, chuyenPhongDTO.MaPhongCu, chuyenPhongDTO.MaPhongMoi,chuyenPhongDTO.MaChuyenPhong);
            Connector.ExecuteNonQuery(sql);
        }
    }
}
