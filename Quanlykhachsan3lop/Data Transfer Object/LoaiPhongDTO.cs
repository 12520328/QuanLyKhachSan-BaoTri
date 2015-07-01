using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class LoaiPhongDTO
    {
        private int _maLoaiPhong;
        private string _tenLoaiPhong;
        private int _maBangGia;
        private int _soLuongNguoiToiDa;
        private decimal _giaTheoNgay;

        

        #region "Properties"
        public int MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        public string TenLoaiPhong
        {
            get { return _tenLoaiPhong; }
            set { _tenLoaiPhong = value; }
        }
        public int MaBangGia
        {
            get { return _maBangGia; }
            set { _maBangGia = value; }
        }
        public int SoLuongNguoiToiDa
        {
            get { return _soLuongNguoiToiDa; }
            set { _soLuongNguoiToiDa = value; }
        }
        public decimal GiaTheoNgay
        {
            get { return _giaTheoNgay; }
            set { _giaTheoNgay = value; }
        }
        #endregion

    }
}
