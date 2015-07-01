using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChiTietSuDungDichVuBUS
    {
        ChiTietSuDungDichVuDAL ctDAL;
        public ChiTietSuDungDichVuBUS()
        {
            ctDAL = new ChiTietSuDungDichVuDAL();
        }
        public DataTable LayDanhSachChiTietSuDungDichVu()
        {
            return ctDAL.LayDanhSachChiTietSuDungDichVu();
        }
        public DataTable LayDanhSachChiTietSuDungDichVu(int MaThuePhong)
        {
            return ctDAL.LayDanhSachChiTietSuDungDichVu(MaThuePhong);
        }
        public void Insert(ChiTietSuDungDichVuDTO ct)
        {
            ctDAL.Insert(ct);
        }

        public void Update(ChiTietSuDungDichVuDTO ct)
        {
            ctDAL.Update(ct);
        }

        public void Delete(int MaChiTiet)
        {
            ctDAL.Delete(MaChiTiet);
        }
    }
}
