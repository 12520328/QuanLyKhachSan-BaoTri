using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ThuePhongDTO
    {
        private int _maThuePhong;
        private int _maDatPhong;
        private int _maPhong;
        private DateTime _ngayThuePhong;
        private int _soLuongNguoi;
                

        #region "Properties"
        public int MaThuePhong
        {
            get { return _maThuePhong; }
            set { _maThuePhong = value; }
        }
        public int MaDatPhong
        {
            get { return _maDatPhong; }
            set { _maDatPhong = value; }
        }
        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
        public DateTime NgayThuePhong
        {
            get { return _ngayThuePhong; }
            set { _ngayThuePhong = value; }
        }
        public int SoLuongNguoi
        {
            get { return _soLuongNguoi; }
            set { _soLuongNguoi = value; }
        }
        #endregion
    }
}
