using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class VatTuDTO
    {
        private int _maVatTu;
        private string _tenVatTu;
        private int _soLuong;
        private string _ghiChu;


        #region "Properties"  
        public int MaVatTu
        {
            get { return _maVatTu; }
            set { _maVatTu = value; }
        }
        public string TenVatTu
        {
            get { return _tenVatTu; }
            set { _tenVatTu = value; }
        }
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        #endregion
    }
}
