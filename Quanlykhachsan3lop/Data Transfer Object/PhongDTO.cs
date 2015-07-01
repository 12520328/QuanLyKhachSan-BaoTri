using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class PhongDTO
    {
       
        private int _maTinhTrangDatPhong;       
        private int _maTinhTrangPhong;      
        private bool _TinhTrangO;




        private int _tinhTrangPhong;//0: Phòng Trống; 1: Đã Đặt, 2:Đang Ở
        private int _maPhong;
        private string _soPhong;
        private int _soGiuong;
        private string _thongTinPhong;
        private int _maTang;
        private int _maLoaiPhong;
        private int _soNguoi;

        
       
        #region "Properties"
        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
        public string SoPhong
        {
            get { return _soPhong; }
            set { _soPhong = value; }
        }
        public int MaTinhTrangDatPhong
        {
            get { return _maTinhTrangDatPhong; }
            set { _maTinhTrangDatPhong = value; }
        }
        public int MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        public int MaTinhTrangPhong
        {
            get { return _maTinhTrangPhong; }
            set { _maTinhTrangPhong = value; }
        }
        public int MaTang
        {
            get { return _maTang; }
            set { _maTang = value; }
        }
        public bool TinhTrangO
        {
            get { return _TinhTrangO; }
            set { _TinhTrangO = value; }
        }
        public int SoNguoi
        {
            get { return _soNguoi; }
            set { _soNguoi = value; }
        }
        public int TinhTrangPhong
        {
            get { return _tinhTrangPhong; }
            set { _tinhTrangPhong = value; }
        }
        public int SoGiuong
        {
            get { return _soGiuong; }
            set { _soGiuong = value; }
        }
        public string ThongTinPhong
        {
            get { return _thongTinPhong; }
            set { _thongTinPhong = value; }
        }
        #endregion
    }
}
