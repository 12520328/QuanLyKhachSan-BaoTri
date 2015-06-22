using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class TangLauDTO
    {
        private int _maTangLau;
        private string _tenTangLau;

        #region "Properties"
        public int MaTangLau
        {
            get { return _maTangLau; }
            set { _maTangLau = value; }
        }
        public string TenTangLau
        {
            get { return _tenTangLau; }
            set { _tenTangLau = value; }
        }
        #endregion
    }
}
