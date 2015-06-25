using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class BangGiaDTO
    {
        private int _maBangGia;
        private string _tenBangGia;
        private DateTime _ngayBatDau;
        private DateTime _ngayKetThuc;
        private List<ChiTietBangGiaDTO> _chiTietBangGia;
               
        
        #region "Properties"
        public int MaBangGia
        {
            get { return _maBangGia; }
            set { _maBangGia = value; }
        }
        public string TenBangGia
        {
            get { return _tenBangGia; }
            set { _tenBangGia = value; }
        }
        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }
            set { _ngayBatDau = value; }
        }
        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set { _ngayKetThuc = value; }
        }
        public List<ChiTietBangGiaDTO> ChiTietBangGia
        {
            get { return _chiTietBangGia; }
            set { _chiTietBangGia = value; }
        }
        #endregion

        public BangGiaDTO()
        {
            _chiTietBangGia = new List<ChiTietBangGiaDTO>();
        }

        public BangGiaDTO(int MaBangGia,string TenBangGia, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            _maBangGia = MaBangGia;
            _tenBangGia = TenBangGia;
            _ngayBatDau = NgayBatDau;
            _ngayKetThuc = NgayKetThuc;
            _chiTietBangGia = new List<ChiTietBangGiaDTO>();
        }
    }
}
