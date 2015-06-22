using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class HuyDatPhongDTO
    {
        private int _maHuyDatPhong;
        private int _maDatPhong;
        private DateTime _ngayHuy;
        private string _ghiChu;

        #region "Properties"
        public int MaHuyDatPhong
        {
            get { return _maHuyDatPhong; }
            set { _maHuyDatPhong = value; }
        }
        public int MaDatPhong
        {
            get { return _maDatPhong; }
            set { _maDatPhong = value; }
        }
        public DateTime NgayHuy
        {
            get { return _ngayHuy; }
            set { _ngayHuy = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        #endregion
    }
}
