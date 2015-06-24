using Quanlykhachsan3lop.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmQuanLyBangGia : Form
    {
        BangGiaBUS bangGiaBUS = new BangGiaBUS();
        LoaiGiaBUS loaiGiaBUS = new LoaiGiaBUS();

        public frmQuanLyBangGia()
        {
            InitializeComponent();
        }

        private void frmQuanLyBangGia_Load(object sender, EventArgs e)
        {
            lkupLoaiGia.DataSource = loaiGiaBUS.LayDanhSachLoaiGia();


        }

        private DataTable getAllLoaiGia()
        {
            return loaiGiaBUS.LayDanhSachLoaiGia();
        }
    }
}
