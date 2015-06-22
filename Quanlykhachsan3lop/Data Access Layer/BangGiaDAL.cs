using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class BangGiaDAL
    {
        // Lấy danh sách bảng giá từ cơ sở dữ liệu.
        public DataTable LayDanhSachLoaiPhong()
        {
            string sql = "select * from BANGGIA";
            return Connector.getDataTable(sql);
        }

        // Thêm một bảng giá vào cơ sở dữ liệu.
        public void Insert(BangGiaDTO bangGiaDTO)
        {
            string sql = string.Format("insert into BANGGIA(TenBangGia,NgayBatDau,NgayKetThuc) Values('{0}','{1}','{2}')", bangGiaDTO.TenBangGia, bangGiaDTO.NgayBatDau, bangGiaDTO.NgayKetThuc);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một bảng giá khỏi cơ sở dữ liệu.
        public void Delete(BangGiaDTO bangGiaDTO)
        {
            string sql = string.Format("delete from BANGGIA where MaBangGia = {0}", bangGiaDTO.MaBangGia);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một bảng giá.
        public void Update(BangGiaDTO bangGiaDTO)
        {
            string sql = string.Format("update BANGGIA set TenBangGia = {0}, NgayBatDau = {1}, NgayKetThuc = {2} where MaBangGia = {3}",
               bangGiaDTO.TenBangGia, bangGiaDTO.NgayBatDau, bangGiaDTO.NgayKetThuc, bangGiaDTO.MaBangGia);
            Connector.ExecuteNonQuery(sql);
        }

        // Lấy lên thông tin bảng giá nằm cuối bảng.
        public object LayMaLoaiPhongCuoiBang()
        {
            string sql = string.Format("select MaBangGia from BANGGIA where MaBangGia = (select max(MaBangGia) from BANGGIA)");
            return Connector.getFistObject(sql);
        }
    }
}
