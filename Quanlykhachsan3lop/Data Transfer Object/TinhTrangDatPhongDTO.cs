using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    
    public class TinhTrangDatPhongDTO
    {
        private int _maTinhTrangDatPhong;
        private string _tenTinhTrangDatPhong;       
        private byte[] _hinhAnh;        

        #region "Properties"
        public int MaTinhTrangDatPhong
        {
            get { return _maTinhTrangDatPhong; }
            set { _maTinhTrangDatPhong = value; }
        }
        public string TenTinhTrangDatPhong
        {
            get { return _tenTinhTrangDatPhong; }
            set { _tenTinhTrangDatPhong = value; }
        }
        public byte[] HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }
        #endregion

    }
}
