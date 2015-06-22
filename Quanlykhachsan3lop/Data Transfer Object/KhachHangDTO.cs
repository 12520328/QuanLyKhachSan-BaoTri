using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class KhachHangDTO
    {
        private int _maKhachHang;        
        private string _tenKhachHang;        
        private string _gioiTinh;        
        private string _cMND;      
        private DateTime _ngaySinh;        
        private string _diaChi;       
        private string _soDienThoai;

        #region "Properties"
        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        public string TenKhachHang
        {
            get { return _tenKhachHang; }
            set { _tenKhachHang = value; }
        }
        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        public string CMND
        {
            get { return _cMND; }
            set { _cMND = value; }
        }
        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = value; }
        }
        #endregion

    }
}
