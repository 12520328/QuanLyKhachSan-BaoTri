using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class LoaiGiaDTO
    {
        private int _maLoaiGia;
        private string _tenLoaiGia;

        private string _ghiChu;

        

        #region "Properties"
        public int MaLoaiGia
        {
            get { return _maLoaiGia; }
            set { _maLoaiGia = value; }
        }
        public string TenLoaiGia
        {
            get { return _tenLoaiGia; }
            set { _tenLoaiGia = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        #endregion
    }
}
