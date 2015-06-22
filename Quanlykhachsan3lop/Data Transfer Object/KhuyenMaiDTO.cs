using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class KhuyenMaiDTO
    {
        private int _maKhuyenMai;
        private string _tenKhuyenMai;
        private string _loaiKhuyenMai;
        private string _congThuc;

        #region "Properties"
        public int MaKhuyenMai
        {
            get { return _maKhuyenMai; }
            set { _maKhuyenMai = value; }
        }
        public string TenKhuyenMai
        {
            get { return _tenKhuyenMai; }
            set { _tenKhuyenMai = value; }
        }
        public string LoaiKhuyenMai
        {
            get { return _loaiKhuyenMai; }
            set { _loaiKhuyenMai = value; }
        }
        public string CongThuc
        {
            get { return _congThuc; }
            set { _congThuc = value; }
        }
        #endregion
    }
}
