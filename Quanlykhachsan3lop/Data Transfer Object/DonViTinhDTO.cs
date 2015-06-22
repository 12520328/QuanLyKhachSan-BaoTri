using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class DonViTinhDTO
    {
        private int _maDonVi;
        private string _tenDonVi;
        private string _ghiChu;

        #region "Properties"
        public int MaDonVi
        {
            get { return _maDonVi; }
            set { _maDonVi = value; }
        }
        public string TenDonVi
        {
            get { return _tenDonVi; }
            set { _tenDonVi = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        #endregion

    }
}
