using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChiTietThuePhongDTO
    {
        private int _maChiTietThuePhong;
        private int _maThuePhong;
        private int _maKhachHang;
        private int _maPhong;

        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }

        #region "Properties"
        public int MaChiTietThuePhong
        {
            get { return _maChiTietThuePhong; }
            set { _maChiTietThuePhong = value; }
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
        #endregion
    }
}
