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
        private string _hoVaTen;       
        private string _tenNguoiDung;
        private string _matKhau;
        private string _loaiNguoiDung;
        
        public NguoiDungDTO(string HoVaTen = "", string TenNguoiDung = "", string MatKhau = "", string LoaiNguoiDung = "",int MaNguoiDung = 0)
        {
            _maNguoiDung = MaNguoiDung;
            _hoVaTen = HoVaTen;
            _tenNguoiDung = TenNguoiDung;
            _matKhau = MatKhau;
            _loaiNguoiDung = LoaiNguoiDung;
        }
     
        #region "Properties"
        public string HoVaTen
        {
            get { return _hoVaTen; }
            set { _hoVaTen = value; }
        }
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
