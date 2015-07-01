using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChiTietSuDungDichVuDTO
    {
        private int _maChiTietSuDungDichVu;

        public int MaChiTietSuDungDichVu
        {
            get { return _maChiTietSuDungDichVu; }
            set { _maChiTietSuDungDichVu = value; }
        }
        private int _maPhong;

        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }

        private int _maThuePhong;

        public int MaThuePhong
        {
            get { return _maThuePhong; }
            set { _maThuePhong = value; }
        }
        private int _maDichVu;

        public int MaDichVu
        {
            get { return _maDichVu; }
            set { _maDichVu = value; }
        }
        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private decimal _donGia;

        public decimal DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        private decimal _thanhTien;

        public decimal ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }
        private DateTime _ngaySuDung;

        public DateTime NgaySuDung
        {
            get { return _ngaySuDung; }
            set { _ngaySuDung = value; }
        }

    }
}
