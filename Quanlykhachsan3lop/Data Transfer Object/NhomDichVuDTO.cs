using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class NhomDichVuDTO
    {
        private int _nhomDichVu;        
        private string _tenNhomDichVu;

        #region "Properties"
        public int NhomDichVu
        {
            get { return _nhomDichVu; }
            set { _nhomDichVu = value; }
        }
        public string TenNhomDichVu
        {
            get { return _tenNhomDichVu; }
            set { _tenNhomDichVu = value; }
        }
        #endregion

    }
}
