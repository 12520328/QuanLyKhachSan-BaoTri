using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class TinhTrangPhongDTO
    {
        private int _maTinhTrangPhong;
        private string _tenTinhTrangPhong;
        private int _mauSac;
        private byte[] _hinhAnh;


        #region "Properties"
        public int MaTinhTrangPhong
        {
            get { return _maTinhTrangPhong; }
            set { _maTinhTrangPhong = value; }
        }
        public string TenTinhTrangPhong
        {
            get { return _tenTinhTrangPhong; }
            set { _tenTinhTrangPhong = value; }
        }
        public int MauSac
        {
            get { return _mauSac; }
            set { _mauSac = value; }
        }
        public byte[] HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }
        #endregion
    }
}
