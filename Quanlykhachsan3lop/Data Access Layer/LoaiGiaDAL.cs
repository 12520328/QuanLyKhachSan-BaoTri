using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class LoaiGiaDAL
    {
        // Lấy danh sách loại giá từ cơ sở dữ liệu.
        public DataTable LayDanhSachLoaiGia()
        {
            string sql = "select * from LOAIGIA";
            return Connector.getDataTable(sql);
        }

        // Thêm một loại giá vào cơ sở dữ liệu.
        public void Insert(LoaiGiaDTO loaiGiaDTO)
        {
            string sql = string.Format("insert into LOAIGIA(TenLoaiGia,GhiChu) Values(N'{0}',N'{1}')",
                loaiGiaDTO.TenLoaiGia, loaiGiaDTO.GhiChu);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một loại giá khỏi cơ sở dữ liệu.
        public void Delete(int maLoaiGia)
        {
            string sql = string.Format("delete from LOAIGIA where MaLoaiGia = {0}", maLoaiGia);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một loại giá.
        public void Update(LoaiGiaDTO loaiGiaDTO)
        {
            string sql = string.Format("update LOAIGIA set TenLoaiGia = N'{0}', GhiChu = N'{1}' where MaLoaiGia = {2}",
               loaiGiaDTO.TenLoaiGia, loaiGiaDTO.GhiChu, loaiGiaDTO.MaLoaiGia);
            Connector.ExecuteNonQuery(sql);            
        }
       

        //Kiểm tra tên loại giá đã có chưa
        public bool TonTaiTenLoaiGia(string TenLoaiGia)
        {
            string sql = string.Format("select MaLoaiGia from LOAIGIA where TenLoaiGia = '{0}'",TenLoaiGia);
            if(Connector.getFistObject(sql) == null)
            {
                return false;
            }
            return true;
        }
    }
}
