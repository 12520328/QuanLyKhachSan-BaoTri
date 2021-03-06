﻿using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Data_Access_Layer
{
    public class ChiTietBangGiaDAL
    {
        // Lấy danh sách chi tiết bảng giá từ cơ sở dữ liệu.
        public DataTable LayDanhSachChiTietBangGia()
        {
            string sql = "select * from CHITIETBANGGIA";
            return Connector.getDataTable(sql);
        }

        // Thêm một chi tiết bảng giá vào cơ sở dữ liệu.
        public void Insert(ChiTietBangGiaDTO chiTietBangGiaDTO)
        {
            string sql = string.Format("insert into CHITIETBANGGIA(MaBangGia,MaLoaiGia,DonGia) Values({0},{1},{2})",
                chiTietBangGiaDTO.MaBangGia, chiTietBangGiaDTO.MaLoaiGia, chiTietBangGiaDTO.DonGia);
            Connector.ExecuteNonQuery(sql);
        }

        // Xóa một chi tiết bảng giá khỏi cơ sở dữ liệu.
        public void Delete(ChiTietBangGiaDTO chiTietBangGiaDTO)
        {
            string sql = string.Format("delete from CHITIETBANGGIA where MaChiTietBangGia = {0}", chiTietBangGiaDTO.MaChiTietBangGia);
            Connector.ExecuteNonQuery(sql);
        }

        // Sưa thông tin một chi tiết bảng giá.
        public void Update(ChiTietBangGiaDTO chiTietBangGiaDTO)
        {
            string sql = string.Format("update CHITIETBANGGIA set MaBangGia = {0}, MaLoaiGia = {1}, DonGia = {2} where MaChiTietBangGia = {3}",
               chiTietBangGiaDTO.MaBangGia, chiTietBangGiaDTO.MaLoaiGia, chiTietBangGiaDTO.DonGia, chiTietBangGiaDTO.MaChiTietBangGia);
            Connector.ExecuteNonQuery(sql);
        }        

        //Lấy danh sách chi tiết bảng giá theo mã bảng giá
        public DataTable LayDanhSachChiTietBangGia(int maBangGia)
        {
            string sql = string.Format("select * from CHITIETBANGGIA where MaBangGia = {0}",maBangGia);
            return Connector.getDataTable(sql);
        }
    }
}
