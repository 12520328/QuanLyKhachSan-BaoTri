using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ThuePhongDAL
    {
        //Lấy danh sach phiêu thuê phòng
        public DataTable LayDanhSachPhieuThuePhong()
        {
            string sql = "select * from THUEPHONG ";
            return Connector.getDataTable(sql);
        }
      
        // Thêm một phiếu thuê phòng vào cơ sở dữ liệu.
        public void Insert(ThuePhongDTO thuePhongDTO)
        {
            string sql = string.Format("insert into THUEPHONG(MaDatPhong,NgayNhanPhong,GioNhanPhong) Values({0},'{1}','{2}')",
                   thuePhongDTO.MaDatPhong, thuePhongDTO.NgayThuePhong, thuePhongDTO.GioThuePhong);    
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một phiếu thuê phòng khỏi cơ sở dữ liệu.
        public void Delete(int maThuePhong)
        {
            string sql = string.Format("delete from THUEPHONG where MaThuePhong = {0}", maThuePhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một phiếu thuê phòng.
        public void Update(ThuePhongDTO thuePhongDTO)
        {
            string sql = string.Format("update THUEPHONG set MaDatPhong = {0}, NgayNhanPhong = '{1}', GioNhanPhong = '{2}' where MaThuePhong = {3}",
                thuePhongDTO.MaDatPhong, thuePhongDTO.NgayThuePhong, thuePhongDTO.GioThuePhong, thuePhongDTO.MaThuePhong);

            Connector.ExecuteNonQuery(sql);
        }     
        //Lấy Mã thuê phòng vừa thêm vào
        public int LayMaThuePhong()
        {
            string sql = string.Format("SELECT MAX(MaThuePhong) from THUEPHONG");
            return int.Parse(Connector.getFistObject(sql).ToString());
        }

        public int LayMaDatPhong(int MaThuePhong)
        {
            string sql = string.Format("SELECT MaDatPhong FROM THUEPHONG WHERE MaThuePhong = {0}",MaThuePhong);
            return int.Parse(Connector.getFistObject(sql).ToString());
        }
    }
}
