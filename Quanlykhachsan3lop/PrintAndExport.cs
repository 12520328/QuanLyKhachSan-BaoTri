using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop
{
    public static class PrintAndExport
    {
        private static string tileName;

        #region "In"
        public static void ShowGridPreview(GridControl gridControl1, string _tileName)
        {
            tileName = _tileName;
            PrintableComponentLink componentLink = new PrintableComponentLink(new PrintingSystem());
            componentLink.Component = gridControl1;
            componentLink.PaperKind = System.Drawing.Printing.PaperKind.A4;

            componentLink.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(printableComponentLink_CreateReportHeaderArea);
            componentLink.CreateReportFooterArea += new CreateAreaEventHandler(printableComponentLink_CreateReportFooterArea);

            componentLink.CreateDocument();
            PrintTool pt = new PrintTool(componentLink.PrintingSystemBase);
            pt.ShowPreviewDialog();
        }
        //Hiển thị danh sách tiêu đề in
        private static void printableComponentLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string tenKhachSan = "ABC";
            string diaChi = "QUANG TRI";

            DrawText(tenKhachSan, e, new Point(0, 0), new SizeF(200,20), Color.Black,StringAlignment.Near,FontStyle.Bold);
            DrawText(diaChi, e, new Point(0, 20), new SizeF(200, 20), Color.Black, StringAlignment.Near,FontStyle.Bold);

            DrawText(tileName, e, new Point(0, 60), new SizeF(650, 35), Color.Black, StringAlignment.Center, FontStyle.Bold,16);
        }
        //Hiển thị thông tin người lập báo cáo
        private static void printableComponentLink_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {    
            DrawText("Thứ......, ngày......tháng......năm.......", e, new Point(340, 30), new SizeF(300, 20), Color.Black);
            DrawText("Người Lập", e, new Point(400,50), new SizeF(200,20),Color.Black);
            DrawText("Họ Và Tên", e, new Point(400,100), new SizeF(200,20), Color.Black);      
        }

        private static void DrawText(string s, CreateAreaEventArgs e, Point p,SizeF sz, Color mauchu,  StringAlignment canle = StringAlignment.Center, FontStyle fs = FontStyle.Regular,int cochu = 10)
        {
            e.Graph.StringFormat = new BrickStringFormat(canle,canle);

            BrickGraphics brickGraph = e.Graph;
            TextBrick brick1 = e.Graph.DrawString(s, mauchu,
              new RectangleF(p, sz), DevExpress.XtraPrinting.BorderSide.None);            
            brick1.BackColor = Color.White;
            brick1.Font = new Font("Tahoma", cochu, fs);
        }
        #endregion

        #region "Xuất File"
        public static void ExportXls(GridControl gridControl1, string _tileName)
        {
            tileName = _tileName;
            PrintableComponentLink componentLink = new PrintableComponentLink(new PrintingSystem());
            componentLink.Component = gridControl1;
            componentLink.PaperKind = System.Drawing.Printing.PaperKind.A4;

            componentLink.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(printableComponentLink_CreateReportHeaderArea);

            componentLink.CreateDocument();
            string fileName = string.Empty;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Exel 2013 (*.xls)|*.xls";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fileName = save.FileName;

            if (string.IsNullOrEmpty(fileName)) return;
            componentLink.ExportToXls(fileName);
            XtraMessageBox.Show("Hoàn Thành");
        }
        #endregion
    }
}
