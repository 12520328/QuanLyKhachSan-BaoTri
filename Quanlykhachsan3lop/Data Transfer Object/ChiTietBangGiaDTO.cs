using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChiTietBangGiaDTO
    {
        private int _maChiTietBangGia;
        private int _maBangGia;
        private int _maLoaiGia;
        private decimal _donGia;


        #region "Properties"
        public int MaChiTietBangGia
        {
            get { return _maChiTietBangGia; }
            set { _maChiTietBangGia = value; }
        }
        public int MaBangGia
        {
            get { return _maBangGia; }
            set { _maBangGia = value; }
        }
        public int MaLoaiGia
        {
            get { return _maLoaiGia; }
            set { _maLoaiGia = value; }
        }
        public decimal DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        #endregion
    }
}
