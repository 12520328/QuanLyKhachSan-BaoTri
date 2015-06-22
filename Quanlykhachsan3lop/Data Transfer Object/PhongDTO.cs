using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class PhongDTO
    {
        private string _soPhong;
        private int _maTinhTrangDatPhong;
        private int _maLoaiPhong;
        private int _maTinhTrangPhong;
        private int _maTang;

        #region "Properties"
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
        #endregion
    }
}
