using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class SuDungDichVuDTO
    {
        private int _maSuDungDichVu;
        private int _maDatPhong;
        private int _maPhong;
        private decimal _thanhTien;
        private List<ChiTietSuDungDichVuDTO> _chiTietSuDungDichVu;

        public List<ChiTietSuDungDichVuDTO> ChiTietSuDungDichVu
        {
            get { return _chiTietSuDungDichVu; }
            set { _chiTietSuDungDichVu = value; }
        }
        #region "Properties"
        public int MaSuDungDichVu
        {
            get { return _maSuDungDichVu; }
            set { _maSuDungDichVu = value; }
        }
        public int MaDatPhong
        {
            get { return _maDatPhong; }
            set { _maDatPhong = value; }
        }
        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
        public decimal ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }
        #endregion
    }
}
