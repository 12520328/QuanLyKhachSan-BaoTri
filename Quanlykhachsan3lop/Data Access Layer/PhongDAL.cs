using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class PhongDAL
    {
        #region 
        // Lấy danh sách phòng từ cơ sở dữ liệu.
        public DataTable LayDanhSach()
        {
            string sql = "select * from PHONG";
            return Connector.getDataTable(sql);
        }
        public DataTable LayDanhSach(int MaPhong)
        {
            string sql = string.Format("select * from PHONG INNER JOIN LOAIPHONG ON PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong where MaPhong = {0}",MaPhong);
            return Connector.getDataTable(sql);
        }

        public int LayMaThamChieu(int MaPhong)
        {
            string sql = string.Format("select MaThamChieu from PHONG where MaPhong = {0}", MaPhong);
            return int.Parse(Connector.getFistObject(sql).ToString());
        }
        //Lấy danh sách phong ở được TinhTrangPhong = 0

        public DataTable LayDanhSachPhong(int TinhTrangPhong)
        {
            string sql = string.Format("select * from PHONG where TinhTrangPhong = {0}",TinhTrangPhong);
            return Connector.getDataTable(sql);
        }
        public void Insert(PhongDTO pDTO)
        {
            string sql;
            sql = string.Format("insert into PHONG(SoPhong, MaLoaiPhong, MaTang, TinhTrangPhong, ThongTinPhong, SoGiuong, SoNguoi) Values(N'{0}', {1}, {2}, {3}, N'{4}',{5}, {6})",
                pDTO.SoPhong, pDTO.MaLoaiPhong, pDTO.MaTang, pDTO.TinhTrangPhong, pDTO.ThongTinPhong, pDTO.SoGiuong, pDTO.SoNguoi);
            Connector.ExecuteNonQuery(sql);
        }
        public void Update(PhongDTO pDTO)
        {
            string sql;
            sql = string.Format("update PHONG set SoPhong = N'{0}', MaLoaiPhong = {1}, MaTang = {2},  ThongTinPhong = N'{3}', SoGiuong = {4}, SoNguoi = {5} where MaPhong = {6}",
                pDTO.SoPhong, pDTO.MaLoaiPhong, pDTO.MaTang,  pDTO.ThongTinPhong, pDTO.SoGiuong, pDTO.SoNguoi, pDTO.MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
        public void UpdateTinhTrangPhong(int TinhTrangPhong, int MaPhong)
        {
            string sql;
            sql = string.Format("update PHONG set TinhTrangPhong = {0} where MaPhong = {1}", TinhTrangPhong, MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
        public void UpdateMaThamChieu(int MaThamChieu, int MaPhong)
        {
            string sql;
            sql = string.Format("update PHONG set MaThamChieu = {0} where MaPhong = {1}", MaThamChieu, MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
        public void UpdateThongTinPhong(string ThongTinPhong, int MaPhong)
        {
            string sql;
            sql = string.Format("update PHONG set ThongTinPhong = N'{0}' where MaPhong = {1}", ThongTinPhong, MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
        public void Delete(int MaPhong)
        {
            string sql = string.Format("delete from PHONG where MaPhong = {0}", MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
        #endregion



        public DataTable LayDanhSachPhongChoThue()
        {
            string sql = string.Format("select PHONG.MaPhong, PHONG.SoPhong, LOAIPHONG.TenLoaiPhong, LOAIPHONG.SoNguoiToiDa, LOAIPHONG.GiaTheoNgay from PHONG INNER JOIN LOAIPHONG ON Phong.MaLoaiPhong = LOAIPHONG.MaLoaiPhong where PHONG.TinhTrangO = {0}", 1);
            return Connector.getDataTable(sql);
        }

        public DataTable LayDanhSachPhongChoThue(int MaPhong)
        {
            string sql = string.Format("select PHONG.MaPhong, PHONG.SoPhong, LOAIPHONG.TenLoaiPhong, LOAIPHONG.SoNguoiToiDa, LOAIPHONG.GiaTheoNgay from PHONG INNER JOIN LOAIPHONG ON Phong.MaLoaiPhong = LOAIPHONG.MaLoaiPhong where PHONG.TinhTrangO = {0} AND PHONG.MaPhong = {1}", 1,MaPhong);
            return Connector.getDataTable(sql);
        }

        public void UpdateTinhTrangO(int TinhTrangO, int MaPhong)
        {
            string sql;
            sql = string.Format("update PHONG set TinhTrangO = {0} where MaPhong = {1}",TinhTrangO,MaPhong );
            Connector.ExecuteNonQuery(sql);
        }

        // Thêm một phòng vào cơ sở dữ liệu.
        public void insert(PhongDTO pDTO)
        {
            string sql;
            sql = string.Format("insert into PHONG(SoPhong, MaTinhTrangDatPhong, MaLoaiPhong, MaTang, MaTinhTrangPhong) Values('{0}', {1}, {2}, {3}, {4})", pDTO.SoPhong, pDTO.MaTinhTrangDatPhong, pDTO.MaLoaiPhong, pDTO.MaTang, pDTO.MaTinhTrangPhong);
            Connector.ExecuteNonQuery(sql);
        }
       
        // Xóa một phòng khỏi cơ sở dữ liệu.
        

        // Sửa thông tin một phòng.
        public void update(PhongDTO pDTO)
        {
            string sql;
            sql = string.Format("update PHONG set SoPhong = '{0}', MaTinhTrangDatPhong = {1}, MaLoaiPhong = {2}, MaTang = {3}, MaTinhTrangPhong = {4} where MaPhong = {5}", pDTO.SoPhong, pDTO.MaTinhTrangDatPhong, pDTO.MaLoaiPhong, pDTO.MaTang, pDTO.MaTinhTrangPhong, pDTO.MaPhong);
            Connector.ExecuteNonQuery(sql);
        }
       

        //Lấy màu sắc tình trạng đặt phòng
        public int LayMauSac(int maPhong)
        {
            TinhTrangDatPhongDAL tinhTrangDatPhong = new TinhTrangDatPhongDAL();
            string sql = string.Format("select MaTinhTrangDatPhong from PHONG where MaPhong = {0}", maPhong);
            int maTinhTrang = int.Parse(Connector.getFistObject(sql).ToString());
            return tinhTrangDatPhong.LayMauSacTinhTrang(maTinhTrang);

        }
    }
}
