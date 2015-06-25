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
        public DataTable LayDanhSachTenBangGia()
        {
            string sql = "select TenBangGia from BANGGIA";
            return Connector.getDataTable(sql);
        }
        // Lấy danh sách bảng giá từ cơ sở dữ liệu.
        public DataTable LayDanhSachBangGia()
        {
            string sql = "select * from BANGGIA";
            return Connector.getDataTable(sql);
        }

        // Thêm một bảng giá vào cơ sở dữ liệu.
        public void Insert(BangGiaDTO bangGiaDTO)
        {          
            string sql = string.Format("insert into BANGGIA(TenBangGia,NgayBatDau,NgayKetThuc) Values(N'{0}','{1}','{2}')",
                bangGiaDTO.TenBangGia, bangGiaDTO.NgayBatDau, bangGiaDTO.NgayKetThuc);
            Connector.ExecuteNonQuery(sql);
          
        }

        // Xóa một bảng giá khỏi cơ sở dữ liệu.
        public void Delete(int  maBangGia)
        {
            string sql = string.Format("delete from BANGGIA where MaBangGia = {0}", maBangGia);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một bảng giá.
        public void Update(BangGiaDTO bangGiaDTO)
        {            
            string sql = string.Format("update BANGGIA set TenBangGia = N'{0}', NgayBatDau = {1}, NgayKetThuc = {2} where MaBangGia = {3}",
               bangGiaDTO.TenBangGia, bangGiaDTO.NgayBatDau, bangGiaDTO.NgayKetThuc, bangGiaDTO.MaBangGia);
            Connector.ExecuteNonQuery(sql);
        }
        //Kiểm tra tên bảng giá đã có chưa
        public bool TonTaiTenBangGia(string TenBangGia)
        {
            string sql = string.Format("select TenBangGia from BANGGIA where TenBangGia = '{0}'", TenBangGia);
            if (Connector.getFistObject(sql) == null)
            {
                return false;
            }
            return true;
        }

        //Lấy mã bảng giá theo tên
        public object LayMaBangGia(string TenBangGia)
        {
            string sql = string.Format("select MaBangGia from BANGGIA where TenBangGia = N'{0}'", TenBangGia);
            return Connector.getFistObject(sql);
        }
    }
}
