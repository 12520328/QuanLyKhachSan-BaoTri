using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChiTietDatPhongDTO
    {
        private int _maChiTietDatPhong;
        private int _maDatPhong;
        private int _maPhong;

        #region "Properties"
        public int MaChiTietDatPhong
        {
            get { return _maChiTietDatPhong; }
            set { _maChiTietDatPhong = value; }
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
        #endregion
    }
}
