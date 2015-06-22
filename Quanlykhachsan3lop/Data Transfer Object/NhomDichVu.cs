using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class NhomDichVu
    {
        private int _maNhomDichVu;        
        private string _tenNhomDichVu;

        #region "Properties"
        public int MaNhomDichVu
        {
            get { return _maNhomDichVu; }
            set { _maNhomDichVu = value; }
        }
        public string TenNhomDichVu
        {
            get { return _tenNhomDichVu; }
            set { _tenNhomDichVu = value; }
        }
        #endregion

    }
}
