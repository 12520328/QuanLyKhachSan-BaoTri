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
    public class ThuePhongBUS
    {
        ThuePhongDAL tpDAL;
        ChiTietThuePhongDAL cttpDAL ;

        public ThuePhongBUS()
        {
           tpDAL = new ThuePhongDAL();
           cttpDAL = new ChiTietThuePhongDAL();
        }

        public DataTable LayDanhSachPhieuThuePhong()
        {
            return tpDAL.LayDanhSachPhieuThuePhong();
        }

        public DataTable LayDanhSachKhachThuePhong()
        {
            return cttpDAL.LayDanhSachKhachHangThuePhong();
        }
        

        //Lấy chi tiết đặt phòng theo đặt phòng
        public DataTable LayDanhSachChiTietThuePhong(int maChiTietThuePhong)
        {
            return cttpDAL.LayDanhSachChiTietThuePhong(maChiTietThuePhong);
        }

        public DataTable LayDanhSachChiTietThuePhongTheoMaThuePhong(int MaThuePhong)
        {
            return cttpDAL.LayDanhSachChiTietThuePhongTheoMaThuePhong(MaThuePhong);
        }
        //Thêm một đặt phòng vào cơ sở dữ liệu.
        public bool Insert(ThuePhongDTO tpDTO)
        {
            if (tpDTO == null)
            {
                return false;
            }
           tpDAL.Insert(tpDTO);
            //Lấy mã thuê phòng vừa thêm Vào
           tpDTO.MaThuePhong = LayMaThuePhong();
            //Cập nhật chi tiết đặt phòng
            foreach (ChiTietThuePhongDTO ct in tpDTO.CTThuePhong)
            {
               ct.MaThuePhong =tpDTO.MaThuePhong;
               InsertCTThuePhong(ct);

               //Cập nhật tình trạng ở cho phòng
               PhongBUS p = new PhongBUS();
               p.UpdateTinhTrangPhong(2, ct.MaPhong);
               p.UpdateMaThamChieu(ct.MaThuePhong, ct.MaPhong);
            }
            //Cập nhật trạng thái đặt phòng
            DatPhongBUS dp = new DatPhongBUS();
            dp.UpdateTrangThai(tpDTO.MaDatPhong, "Đã Nhận Phòng");

            
            return true;
        }

        public void InsertCTThuePhong(ChiTietThuePhongDTO ct)
        {           
            cttpDAL.Insert(ct);
        }

        public void UpdateCTThuePhong(ChiTietThuePhongDTO ct)
        {
            cttpDAL.Update(ct);
        }

        public void ChuyenPhong(int mahuePhong,int MaPhong, int MaPhongMoi)
        {
            cttpDAL.UpdateChuyenPhong(mahuePhong,MaPhong, MaPhongMoi);
        }

        // Xóa một đặt phòng khỏi cơ sở dữ liệu.
        public void Delete(int maChiTietThuePhong)
        {
            
        }

        // Sửa thông tin một đặt phòng.
        public bool Update(ThuePhongDTO tpDTO)
        {
            if(tpDTO == null)
            {
                return false;
            }
           tpDAL.Update(tpDTO);
            //Cập nhật chi tiết đặt phòng
            foreach (ChiTietThuePhongDTO ct in tpDTO.CTThuePhong)
            {               
               cttpDAL.Update(ct);
            }
            return true;
        }
        public int LayMaThuePhong()
        {
            return tpDAL.LayMaThuePhong();
        }

       public int LayMaDatPhong(int MaThuePhong)
        {
            return tpDAL.LayMaDatPhong (MaThuePhong);
        }
    }
}
