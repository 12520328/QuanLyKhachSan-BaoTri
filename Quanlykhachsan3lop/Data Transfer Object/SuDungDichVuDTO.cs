using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class SuDungDichVuDTO
    {
        private int _maSuDungDichVu;
        private int _maThuePhong;
        private int _maPhong;
        private int _maKhachHang;
        private int _maDichVu;
        private int _soLuong;
        private decimal _thanhTien;
        private DateTime _ngaySuDung;

        #region "Properties"
        public int MaSuDungDichVu
        {
            get { return _maSuDungDichVu; }
            set { _maSuDungDichVu = value; }
        }
        public int MaThuePhong
        {
            get { return _maThuePhong; }
            set { _maThuePhong = value; }
        }
        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        public int MaDichVu
        {
            get { return _maDichVu; }
            set { _maDichVu = value; }
        }
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public decimal ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }
        public DateTime NgaySuDung
        {
            get { return _ngaySuDung; }
            set { _ngaySuDung = value; }
        }
        #endregion
    }
}
