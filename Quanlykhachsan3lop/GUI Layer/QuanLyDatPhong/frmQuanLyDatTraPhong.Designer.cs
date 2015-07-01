namespace Quanlykhachsan3lop.GUI_Layer.QuanLyDatPhong
{
    partial class frmQuanLyDatTraPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyDatTraPhong));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.listView2 = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemThemPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemThongTinPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemThemVaoPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTTDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNhanPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemChuyenPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTraPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemSDDV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "phong trong");
            this.imageList1.Images.SetKeyName(1, "da dat");
            this.imageList1.Images.SetKeyName(2, "dang o");
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.Appearance.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.listView2);
            this.groupControl1.Controls.Add(this.listView1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(703, 435);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "DANH SÁCH PHÒNG";
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.LargeImageList = this.imageList2;
            this.listView2.Location = new System.Drawing.Point(2, 83);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(699, 350);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "phong trong");
            this.imageList2.Images.SetKeyName(1, "da dat");
            this.imageList2.Images.SetKeyName(2, "dang o");
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(2, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(699, 62);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemThemPhong,
            this.itemThongTinPhong,
            this.toolStripSeparator1,
            this.itemThemVaoPhong,
            this.itemTTDatPhong,
            this.itemDatPhong,
            this.itemNhanPhong,
            this.itemChuyenPhong,
            this.itemTraPhong,
            this.toolStripSeparator2,
            this.itemSDDV,
            this.toolStripSeparator3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 220);
            // 
            // itemThemPhong
            // 
            this.itemThemPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemThemPhong.Image")));
            this.itemThemPhong.Name = "itemThemPhong";
            this.itemThemPhong.Size = new System.Drawing.Size(234, 22);
            this.itemThemPhong.Text = "Thêm Phòng";
            this.itemThemPhong.Click += new System.EventHandler(this.itemThemPhong_Click);
            // 
            // itemThongTinPhong
            // 
            this.itemThongTinPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemThongTinPhong.Image")));
            this.itemThongTinPhong.Name = "itemThongTinPhong";
            this.itemThongTinPhong.Size = new System.Drawing.Size(234, 22);
            this.itemThongTinPhong.Text = "Thông Tin Phòng";
            this.itemThongTinPhong.Click += new System.EventHandler(this.itemThongTinPhong_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // itemThemVaoPhong
            // 
            this.itemThemVaoPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemThemVaoPhong.Image")));
            this.itemThemVaoPhong.Name = "itemThemVaoPhong";
            this.itemThemVaoPhong.Size = new System.Drawing.Size(234, 22);
            this.itemThemVaoPhong.Text = "Thêm Khách Hàng Vào Phòng";
            this.itemThemVaoPhong.Click += new System.EventHandler(this.itemThemVaoPhong_Click);
            // 
            // itemTTDatPhong
            // 
            this.itemTTDatPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemTTDatPhong.Image")));
            this.itemTTDatPhong.Name = "itemTTDatPhong";
            this.itemTTDatPhong.Size = new System.Drawing.Size(234, 22);
            this.itemTTDatPhong.Text = "Danh Sách Đặt Phòng";
            // 
            // itemDatPhong
            // 
            this.itemDatPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemDatPhong.Image")));
            this.itemDatPhong.Name = "itemDatPhong";
            this.itemDatPhong.Size = new System.Drawing.Size(234, 22);
            this.itemDatPhong.Text = "Đặt Phòng";
            this.itemDatPhong.Click += new System.EventHandler(this.itemDatPhong_Click);
            // 
            // itemNhanPhong
            // 
            this.itemNhanPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemNhanPhong.Image")));
            this.itemNhanPhong.Name = "itemNhanPhong";
            this.itemNhanPhong.Size = new System.Drawing.Size(234, 22);
            this.itemNhanPhong.Text = "Nhận Phòng";
            this.itemNhanPhong.Click += new System.EventHandler(this.itemNhanPhong_Click);
            // 
            // itemChuyenPhong
            // 
            this.itemChuyenPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemChuyenPhong.Image")));
            this.itemChuyenPhong.Name = "itemChuyenPhong";
            this.itemChuyenPhong.Size = new System.Drawing.Size(234, 22);
            this.itemChuyenPhong.Text = "Chuyển Phòng";
            this.itemChuyenPhong.Click += new System.EventHandler(this.itemChuyenPhong_Click);
            // 
            // itemTraPhong
            // 
            this.itemTraPhong.Image = ((System.Drawing.Image)(resources.GetObject("itemTraPhong.Image")));
            this.itemTraPhong.Name = "itemTraPhong";
            this.itemTraPhong.Size = new System.Drawing.Size(234, 22);
            this.itemTraPhong.Text = "Trả Phòng";
            this.itemTraPhong.Click += new System.EventHandler(this.itemTraPhong_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // itemSDDV
            // 
            this.itemSDDV.Image = ((System.Drawing.Image)(resources.GetObject("itemSDDV.Image")));
            this.itemSDDV.Name = "itemSDDV";
            this.itemSDDV.Size = new System.Drawing.Size(234, 22);
            this.itemSDDV.Text = "Sử Dụng Dịch Vụ";
            this.itemSDDV.Click += new System.EventHandler(this.itemSDDV_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
            // 
            // frmQuanLyDatTraPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 435);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmQuanLyDatTraPhong";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.frmQuanLyDatTraPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemThongTinPhong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemDatPhong;
        private System.Windows.Forms.ToolStripMenuItem itemNhanPhong;
        private System.Windows.Forms.ToolStripMenuItem itemChuyenPhong;
        private System.Windows.Forms.ToolStripMenuItem itemTraPhong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem itemSDDV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem itemThemPhong;
        private System.Windows.Forms.ToolStripMenuItem itemTTDatPhong;
        private System.Windows.Forms.ToolStripMenuItem itemThemVaoPhong;
    }
}