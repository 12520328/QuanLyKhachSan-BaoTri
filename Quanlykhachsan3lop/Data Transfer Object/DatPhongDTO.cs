using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class DatPhongDTO
    {
        private int _maDatPhong;
        private int _maKhachHang;
        private DateTime _ngayDat;
        private DateTime _ngayDen;
        private DateTime _ngayDi;
        private decimal _datCoc;
        private decimal _khuyenMai;
        private int _VND;

        public int VND
        {
            get { return _VND; }
            set { _VND = value; }
        }

        private int _tongSoKhach;
        private int _tongSoPhong;
        private string _trangThai;

      
        private List<ChiTietDatPhongDTO> _chiTietDatPhong;
              


        #region "Properties"
        public int MaDatPhong
        {
            get { return _maDatPhong; }
            set { _maDatPhong = value; }
        }
        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        public DateTime NgayDat
        {
            get { return _ngayDat; }
            set { _ngayDat = value; }
        }
        public DateTime NgayDen
        {
            get { return _ngayDen; }
            set { _ngayDen = value; }
        }
        public DateTime NgayDi
        {
            get { return _ngayDi; }
            set { _ngayDi = value; }
        }
        public decimal DatCoc
        {
            get { return _datCoc; }
            set { _datCoc = value; }
        }
        public decimal KhuyenMai
        {
            get { return _khuyenMai; }
            set { _khuyenMai = value; }
        }
        public int TongSoKhach
        {
            get { return _tongSoKhach; }
            set { _tongSoKhach = value; }
        }
        public int TongSoPhong
        {
            get { return _tongSoPhong; }
            set { _tongSoPhong = value; }
        }
        public string TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }
        public List<ChiTietDatPhongDTO> ChiTietDatPhong
        {
            get { return _chiTietDatPhong; }
            set { _chiTietDatPhong = value; }
        }
        #endregion

        public DatPhongDTO()
        {
            _chiTietDatPhong = new List<ChiTietDatPhongDTO>();
        }
    }
}
