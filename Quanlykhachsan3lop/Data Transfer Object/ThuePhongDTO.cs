using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ThuePhongDTO
    {
        private int _maThuePhong;
        private int _maDatPhong;
        private DateTime _ngayThuePhong;
        private DateTime _gioThuePhong;
        private List<ChiTietThuePhongDTO> ctThuePhong;

      
        
        public ThuePhongDTO()
        {
            ctThuePhong = new List<ChiTietThuePhongDTO>();
        }

        #region "Properties"
        public int MaThuePhong
        {
            get { return _maThuePhong; }
            set { _maThuePhong = value; }
        }
        public int MaDatPhong
        {
            get { return _maDatPhong; }
            set { _maDatPhong = value; }
        }
        public DateTime GioThuePhong
        {
            get { return _gioThuePhong; }
            set { _gioThuePhong = value; }
        }
        public DateTime NgayThuePhong
        {
            get { return _ngayThuePhong; }
            set { _ngayThuePhong = value; }
        }
        public List<ChiTietThuePhongDTO> CTThuePhong
        {
            get { return ctThuePhong; }
            set { ctThuePhong = value; }
        }
        #endregion
    }
}
