using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChuyenPhongDTO
    {
        private int _maChuyenPhong;
        private DateTime _ngayChuyenPhong;
        private int _maPhongCu;
        private int _maPhongMoi;

        

        #region "Properties"
        public int MaChuyenPhong
        {
            get { return _maChuyenPhong; }
            set { _maChuyenPhong = value; }
        }
        public DateTime NgayChuyenPhong
        {
            get { return _ngayChuyenPhong; }
            set { _ngayChuyenPhong = value; }
        }
        public int MaPhongCu
        {
            get { return _maPhongCu; }
            set { _maPhongCu = value; }
        }
        public int MaPhongMoi
        {
            get { return _maPhongMoi; }
            set { _maPhongMoi = value; }
        }
        #endregion
    }
}
