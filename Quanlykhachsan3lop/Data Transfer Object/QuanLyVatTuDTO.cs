using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Transfer_Object
{
    public class QuanLyVatTuDTO
    {
        private int _maQuanLyVatTu;
        private int _maLoaiPhong;
        private int _maVatTu;
        private int _soLuong;
        private string _ghiChu;

        #region "Properties"
        public int MaQuanLyVatTu
        {
            get { return _maQuanLyVatTu; }
            set { _maQuanLyVatTu = value; }
        }
        public int MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        public int MaVatTu
        {
            get { return _maVatTu; }
            set { _maVatTu = value; }
        }
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        #endregion
    }
}
