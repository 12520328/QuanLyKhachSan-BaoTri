using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class NguoiDungDTO
    {
        private int _maNguoiDung;
        private string _tenNguoiDung;
        private string _matKhau;
        private string _loaiNguoiDung;


        #region "Properties"
        public int MaNguoiDung
        {
            get { return _maNguoiDung; }
            set { _maNguoiDung = value; }
        }
        public string TenNguoiDung
        {
            get { return _tenNguoiDung; }
            set { _tenNguoiDung = value; }
        }
        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
        public string LoaiNguoiDung
        {
            get { return _loaiNguoiDung; }
            set { _loaiNguoiDung = value; }
        }
        #endregion
    }
}
