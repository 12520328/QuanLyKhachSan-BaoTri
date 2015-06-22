using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class ChinhSachDTO
    {
        private int _maChinhSach;       
        private DateTime _thoiGianQuyDinh;       
        private decimal _phuThu;

        public int MaChinhSach
        {
            get { return _maChinhSach; }
            set { _maChinhSach = value; }
        }
        public DateTime ThoiGianQuyDinh
        {
            get { return _thoiGianQuyDinh; }
            set { _thoiGianQuyDinh = value; }
        }
        public decimal PhuThu
        {
            get { return _phuThu; }
            set { _phuThu = value; }
        }


    }
}
