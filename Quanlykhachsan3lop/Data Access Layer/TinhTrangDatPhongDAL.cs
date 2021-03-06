﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlykhachsan3lop.Data_Transfer_Object;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    class TinhTrangDatPhongDAL
    {
        // Lấy danh sách tình trạng đặt phòng từ cơ sở dữ liệu.
        public DataTable LayDanhSachTinhTrangDatPhong()
        {
            string sql = "select * from TINHTRANGDATPHONG";
            return Connector.getDataTable(sql);
        }

        // Thêm một trình trạng đặt phòng vào cơ sở dữ liệu.
        public void ThemTinhTrangDatPhong(TinhTrangDatPhongDTO ttdpDTO)
        {
            string sql;
            sql = string.Format("insert into TINHTRANGDATPHONG(TenTinhTrangDatPhong, HinhAnh,MauSac) Values('{0}', '{1}', {2})", ttdpDTO.TenTinhTrangDatPhong, ttdpDTO.HinhAnh,ttdpDTO.MauSac);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một tình trạng đặt phòng khỏi cơ sở dữ liệu.
        public void XoaTinhTrangDatPhong(TinhTrangDatPhongDTO ttdpDTO)
        {
            string sql = string.Format("delete from TINHTRANGDATPHONG where MaTinhTrangDatPhong = {0}", ttdpDTO.MaTinhTrangDatPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Sửa thông tin một tình trạng đặt phòng.
        public void SuaTinhTrangDatPhong(TinhTrangDatPhongDTO ttdpDTO)
        {
            string sql;
            sql = string.Format("update TINHTRANGDATPHONG set TenTinhTrangDatPhong = '{0}', HinhAnh = '{1}', MauSac = {2} where MaTinhTrangDatPhong = {3}", ttdpDTO.TenTinhTrangDatPhong, ttdpDTO.HinhAnh, ttdpDTO.MauSac, ttdpDTO.MaTinhTrangDatPhong);
            Connector.ExecuteNonQuery(sql);
        }

        // Lấy lên thông tin tình trạng đặt phòng nằm cuối bảng.
        public object LayMaTinhTrangCuoiBang()
        {
            string sql = string.Format("select MaTinhTrang from TINHTRANGDATPHONG where MaTinhTrang = (select max(MaTinhTrang) from TINHTRANGDATPHONG)");
            return Connector.getFistObject(sql);
        }

        //Lấy màu sắc tình trạng
        public int LayMauSacTinhTrang(int maTinhTrang)
        {
            string sql = string.Format("select MauSac from TINHTRANGDATPHONG where MaTinhTrang = {0}",maTinhTrang);
            return int.Parse(Connector.getFistObject(sql).ToString());
        }
    }
}
