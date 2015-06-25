using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class DichVuDTO
    {
        private int _maDichVu;
        private string _tenDichVu;
        private decimal _donGia;
        private int _maDonViTinh;
        private int _nhomDichVu;

        #region "Properties"
        public int MaDichVu
        {
            get { return _maDichVu; }
            set { _maDichVu = value; }
        }
        public string TenDichVu
        {
            get { return _tenDichVu; }
            set { _tenDichVu = value; }
        }
        public decimal DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        public int MaDonViTinh
        {
            get { return _maDonViTinh; }
            set { _maDonViTinh = value; }
        }
        public int NhomDichVu
        {
            get { return _nhomDichVu; }
            set { _nhomDichVu = value; }
        }
        #endregion
    }
}
