using DevExpress.Utils;
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
    public partial class frmSoDoPhong : Form
    {
        TangLauBUS tangLauBUS = new TangLauBUS();

        public frmSoDoPhong()
        {
            InitializeComponent();
        }

        private void frmSoDoPhong_Load(object sender, EventArgs e)
        {
            ListViewGroup group1 = new ListViewGroup("Chú Thích", HorizontalAlignment.Left);
            ListViewGroup group2 = new ListViewGroup("Users", HorizontalAlignment.Left);
            view.LargeImageList = imageList1;

            ListViewItem item = new ListViewItem();
            item.Text = "Phong 1";
            item.Group = group1;
            item.BackColor = Color.Red;
            item.ToolTipText = "Sach";

            view.Items.Add(item);
            view.Items.Add(new ListViewItem("Suzan Smith",2, group1));
            view.Items.Add(new ListViewItem("Syed Hussain",3, group2));
            view.Items.Add(new ListViewItem("Sonia Jones",0, group2));

            view.Groups.Add(group1);
            view.Groups.Add(group2);
            NewGroup();
        }

        private void NewGroup()
        {
            PhongBUS phong = new PhongBUS();
            ListViewGroup group = new ListViewGroup();
            ListViewItem item = new ListViewItem();
            ImageList img = new ImageList();
            int index = 0;
            for (int i = 0; i < tangLauBUS.LayDanhSachTangLau().Rows.Count; i++)
            {
                group.Header = tangLauBUS.LayDanhSachTangLau().Rows[i]["TenTangLau"].ToString();
                group.HeaderAlignment = HorizontalAlignment.Left;
                for (int j = 0; j < phong.LayDanhSach().Rows.Count; j++)
                {
                    if(phong.LayDanhSach().Rows[j]["MaTang"].ToString() ==  tangLauBUS.LayDanhSachTangLau().Rows[i]["MaTangLau"].ToString())
                    {
                        item.Text = phong.LayDanhSach().Rows[j]["SoPhong"].ToString();
                        PictureBox p = new PictureBox();
                        p.BackColor = Color.FromArgb(phong.LayMauSac(int.Parse(phong.LayDanhSach().Rows[j]["MaPhong"].ToString())));                        
                        img.Images.Add(p.Image);
                        index++;
                        item.ImageIndex = index;
                        item.Group = group;
                        view.Items.Add(item);
                    }
                }             
                view.Groups.Add(group);
            }
        }
    }
}
