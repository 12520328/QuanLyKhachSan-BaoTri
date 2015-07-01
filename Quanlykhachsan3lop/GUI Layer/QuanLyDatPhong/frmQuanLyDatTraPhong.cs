using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyDatPhong
{
    public partial class frmQuanLyDatTraPhong : Form
    {
        //0: Phòng Trống; 1: Đã Đặt, 2:Đang Ở
        const int PhongTrong = 0 ;
        const int DaDat = 1;
        const int DangO = 2;

        public frmQuanLyDatTraPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyDatTraPhong_Load(object sender, EventArgs e)
        {
            LoadImageListView1();
            LoadImageListView2();
        }

        private void LoadImageListView1()
        {
            ListViewItem item1 = new ListViewItem("Phòng Trống");
            item1.ImageIndex = 0;
          
            ListViewItem item2 = new ListViewItem("Đã Đặt");
            item2.ImageIndex = 1;
       

            ListViewItem item3 = new ListViewItem("Đang Ở");
            item3.ImageIndex = 2;
        
            listView1.Items.AddRange(new ListViewItem[] {item1, item2, item3 });
        }

        private void LoadImageListView2()
        {
            listView2.Clear();
            for (int i = 0; i < DanhSachTangLau().Rows.Count; i++)
            {
                string groupName = DanhSachTangLau().Rows[i]["TenTangLau"].ToString();
                int groupID = int.Parse(DanhSachTangLau().Rows[i]["MaTangLau"].ToString());
                ListViewGroup listGroup = new ListViewGroup(groupName, HorizontalAlignment.Left);
                listView2.Groups.Add(listGroup);
                for (int j = 0; j < DanhSachPhong().Rows.Count; j++)
                {
                    if (int.Parse(DanhSachPhong().Rows[j]["MaTang"].ToString()) == groupID)
                    {
                        string tenPhong = DanhSachPhong().Rows[j]["SoPhong"].ToString();
                        ListViewItem item = new ListViewItem();
                        item.Text = tenPhong;
                        switch (int.Parse(DanhSachPhong().Rows[j]["TinhTrangPhong"].ToString()))
                        {                           
                            case PhongTrong:
                                item.ImageIndex = 0;
                                break;
                            case DaDat:
                                item.ImageIndex = 1;
                                break;
                            case DangO:
                                item.ImageIndex = 2;
                                break;
                        }
                        item.Tag = int.Parse(DanhSachPhong().Rows[j]["MaPhong"].ToString());
                        item.Group = listGroup;
                        listView2.Items.Add(item);
                    }
                }
            }
        }

        private DataTable DanhSachTangLau()
        {
            TangLauBUS tl = new TangLauBUS();
            return tl.LayDanhSachTangLau();
        }

        private DataTable DanhSachPhong()
        {
            PhongBUS p = new PhongBUS();
            return p.LayDanhSach();
        }

        private void CustomizeContextMenu(int TinhTrangPhong)
        {
            itemChuyenPhong.Visible = true;
            itemDatPhong.Visible = true;
            itemSDDV.Visible = true;
            itemTraPhong.Visible = true;
            itemNhanPhong.Visible = true;
            itemTTDatPhong.Visible = true;
            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = true;
            toolStripSeparator3.Visible = true;
            switch (TinhTrangPhong)
            {
                //Nếu phòng trống thì show toàn bộ
                case PhongTrong:
                    itemTTDatPhong.Visible = false;
                    itemChuyenPhong.Visible = false;
                    itemNhanPhong.Visible = false;
                    itemSDDV.Visible = false;
                    itemTraPhong.Visible = false;
                    toolStripSeparator3.Visible = false;
                    toolStripSeparator2.Visible = false;
                    break;
                //Nếu click vào phòng đang đặt thì chỉ view nhân phòng với thông tin phòng
                case DaDat:
                    itemChuyenPhong.Visible = false;
                    itemDatPhong.Visible = false;
                    itemSDDV.Visible = false;
                    itemTraPhong.Visible = false;
                    toolStripSeparator3.Visible = false;
                    toolStripSeparator2.Visible = false;
                    
                    break;

                //Nếu click vào phòng đang ơ thì bỏ nhận phòng, đặt phòngg
                case DangO:
                    itemNhanPhong.Visible = false;
                    itemDatPhong.Visible = false;
                    itemTTDatPhong.Visible = false;
                    break;
            }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView2.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    CustomizeContextMenu(listView2.FocusedItem.ImageIndex);
                    contextMenuStrip1.Show(Cursor.Position);
                }                
            }
        }


        #region ContextMenu
        private void itemThemPhong_Click(object sender, EventArgs e)
        {
            Form f = new frmPhong();
            f.ShowDialog();
            LoadImageListView2();
        }
        private void itemThongTinPhong_Click(object sender, EventArgs e)
        {
            Form f = new frmThongTinPhong(listView2.FocusedItem.Text, int.Parse(listView2.FocusedItem.Tag.ToString())); ;
            f.ShowDialog();
        }

        private void itemDatPhong_Click(object sender, EventArgs e)
        {
            Form f = new frmPhieuDatPhong("Đặt Phòng", true, int.Parse(listView2.FocusedItem.Tag.ToString()));
            f.ShowDialog();
            LoadImageListView2();
        }

        private void itemThemVaoPhong_Click(object sender, EventArgs e)
        {
            Form f = new frmThemKhachVaoPhong();
            f.ShowDialog();
        }

        private void itemChuyenPhong_Click(object sender, EventArgs e)
        {
            Form f = new frmChuyenPhong(listView2.FocusedItem.Text, int.Parse(listView2.FocusedItem.Tag.ToString()));
            f.ShowDialog();
            LoadImageListView2();
        }

        private void itemNhanPhong_Click(object sender, EventArgs e)
        {
            Form f = new frmPhieuDatPhong("Nhận Phòng", false,int.Parse(listView2.FocusedItem.Tag.ToString()));
            f.ShowDialog();
            LoadImageListView2();
        }

        private void itemTraPhong_Click(object sender, EventArgs e)
        {

            Form f = new frmHoaDon( int.Parse(listView2.FocusedItem.Tag.ToString()),listView2.FocusedItem.Text);
            f.ShowDialog();
        }

        private void itemSDDV_Click(object sender, EventArgs e)
        {
            Form f = new frmSuDungDichVu(listView2.FocusedItem.Text, int.Parse(listView2.FocusedItem.Tag.ToString()));
            f.ShowDialog();
        }

        private void itemXemHoaDon_Click(object sender, EventArgs e)
        {
            LoadImageListView2();
        }
        #endregion


      
    }
   
}
