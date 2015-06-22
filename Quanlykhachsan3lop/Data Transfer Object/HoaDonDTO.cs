using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class HoaDonDTO
    {
        private string _soHoaDon;       
        private int _maNguoiDung;        
        private int _maKhachHang;                
        private int _maThuePhong;        
        private decimal _tongTien;       
        private DateTime _ngayLap;        
        private decimal _tienKhachTra;
        private List<ChiTietHoaDonDTO> _chiTietHoaDon;

        

        #region "Properties"
        public string SoHoaDon
        {
            get { return _soHoaDon; }
            set { _soHoaDon = value; }
        }
        public int MaNguoiDung
        {
            get { return _maNguoiDung; }
            set { _maNguoiDung = value; }
        }
        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        public int MaThuePhong
        {
            get { return _maThuePhong; }
            set { _maThuePhong = value; }
        }
        public decimal TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }
        public decimal TienKhachTra
        {
            get { return _tienKhachTra; }
            set { _tienKhachTra = value; }
        }
        public List<ChiTietHoaDonDTO> ChiTietHoaDon
        {
            get { return _chiTietHoaDon; }
            set { _chiTietHoaDon = value; }
        }
        #endregion


        public HoaDonDTO()
        {
            _chiTietHoaDon = new List<ChiTietHoaDonDTO>();
        }
    }
}
