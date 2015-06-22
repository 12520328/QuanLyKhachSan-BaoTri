using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChiTietHoaDonDTO
    {
        private int _maChiTietHoaDon;       
        private int _maHoaDon;        
        private int _maPhong;
        private int _maSuDungDichVu;        
        private int _maChinhSach;
        private int _soNgayO;
        private decimal _tienPhong;
        private decimal _tienDichVu;
        private decimal _khuyenMai;
        private decimal _phuThu;


        #region "Properties"
        public int MaChiTietHoaDon
        {
            get { return _maChiTietHoaDon; }
            set { _maChiTietHoaDon = value; }
        }
        public int MaHoaDon
        {
            get { return _maHoaDon; }
            set { _maHoaDon = value; }
        }
        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
        public int MaSuDungDichVu
        {
            get { return _maSuDungDichVu; }
            set { _maSuDungDichVu = value; }
        }
        public int MaChinhSach
        {
            get { return _maChinhSach; }
            set { _maChinhSach = value; }
        }
        public int SoNgayO
        {
            get { return _soNgayO; }
            set { _soNgayO = value; }
        }
        public decimal TienPhong
        {
            get { return _tienPhong; }
            set { _tienPhong = value; }
        }
        public decimal TienDichVu
        {
            get { return _tienDichVu; }
            set { _tienDichVu = value; }
        }
        public decimal KhuyenMai
        {
            get { return _khuyenMai; }
            set { _khuyenMai = value; }
        }
        public decimal PhuThu
        {
            get { return _phuThu; }
            set { _phuThu = value; }
        }
        #endregion
    }
}
