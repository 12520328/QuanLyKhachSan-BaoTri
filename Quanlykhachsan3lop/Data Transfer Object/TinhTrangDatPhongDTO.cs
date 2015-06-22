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
        private string _tenTinhTrang;       
        private Image _hinhAnh;        

        #region "Properties"
        public int MaTinhTrangDatPhong
        {
            get { return _maTinhTrangDatPhong; }
            set { _maTinhTrangDatPhong = value; }
        }
        public string TenTinhTrang
        {
            get { return _tenTinhTrang; }
            set { _tenTinhTrang = value; }
        }
        public Image HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }
        #endregion

    }
}
