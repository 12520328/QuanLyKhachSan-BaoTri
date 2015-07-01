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
    public class DatPhongBUS
    {
        private DatPhongDAL datPhongDAL;
        private ChiTietDatPhongDAL chiTietDatPhongDAL;

        public DatPhongBUS()
        {
            datPhongDAL = new DatPhongDAL();
            chiTietDatPhongDAL = new ChiTietDatPhongDAL();
        }

        public DataTable LayDanhSachPhieuDatPhong()
        {
            return datPhongDAL.LayDanhSachPhieuDatPhong();
        }

        public DataTable LayDanhSachPhieuDatPhong(int MaDatPhong)
        {
            return datPhongDAL.LayDanhSachPhieuDatPhong(MaDatPhong);
        }


        //Lấy chi tiết đặt phòng theo đặt phòng
        public int LayMaKhachHang(int maDatPhong)
        {
            return datPhongDAL.LayMaKhachHang(maDatPhong);
        }
        public DataTable LayDanhSach()
        {
            return datPhongDAL.LayDanhSachPhieuDatPhong();
        }
       public DataTable LayDanhSachPhongTheoMaDatPhong(int MaDatPhong)
        {
            return chiTietDatPhongDAL.LayDanhSachPhongTheoMaDatPhong(MaDatPhong);
        }

        //Thêm một đặt phòng vào cơ sở dữ liệu.
        public bool Insert(DatPhongDTO datPhongDTO)
        {
            if (datPhongDTO == null)
            {
                return false;
            }
            datPhongDAL.Insert(datPhongDTO);
            //Lấy Mã Bàng Giá vừa thêm Vào
            datPhongDTO.MaDatPhong = LayMaDatPhong();
            //Cập nhật chi tiết đặt phòng
            foreach (ChiTietDatPhongDTO ct in datPhongDTO.ChiTietDatPhong)
            {
                ct.MaDatPhong = datPhongDTO.MaDatPhong;
                chiTietDatPhongDAL.Insert(ct);
                //Cập nhật tình trạng ở cho phòng
                PhongBUS p = new PhongBUS();
                p.UpdateTinhTrangPhong(1, ct.MaPhong);
                p.UpdateMaThamChieu(ct.MaDatPhong, ct.MaPhong);
            }
            return true;
        }

        // Xóa một đặt phòng khỏi cơ sở dữ liệu.
        public void Delete(int maChiTietDatPhong)
        {
            
        }

        // Sửa thông tin một đặt phòng.
        public bool Update(DatPhongDTO datPhongDTO)
        {
            if(datPhongDTO == null)
            {
                return false;
            }
            datPhongDAL.Update(datPhongDTO);
            //Cập nhật chi tiết đặt phòng
            foreach (ChiTietDatPhongDTO ct in datPhongDTO.ChiTietDatPhong)
            {               
                chiTietDatPhongDAL.Update(ct);
            }
            return true;
        }
        public void UpdateTrangThai(int MaDatPhong, string TrangThai)
        {
             datPhongDAL.UpdateTrangThai(MaDatPhong, TrangThai);
        }

        public int LayMaDatPhong()
        {
            return datPhongDAL.LayMaDatPhong();
        }

        public string LayTrangThai(int MaDatPhong)
        {
            return datPhongDAL.LayTrangThai(MaDatPhong);
        }
    }
}
