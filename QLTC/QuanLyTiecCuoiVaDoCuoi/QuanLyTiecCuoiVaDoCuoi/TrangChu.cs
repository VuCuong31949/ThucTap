using QuanLyTiecCuoiVaDoCuoi.Tiệc_Cưới_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiecCuoiVaDoCuoi
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            uC_DsSanhCuoi1.Visible = false;
            danhSáchTiệcCướiToolStripMenuItem.PerformClick();

        }

        private void uC_DsTiecCuoi1_Load(object sender, EventArgs e)
        {

        }

        private void uC_DsTiecCuoi1_Load_1(object sender, EventArgs e)
        {

        }

        private void tiệcCướiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

     

        private void uC_QlMonAn1_Load(object sender, EventArgs e)
        {

        }

        private void MenuDsTiecCuoi_Click(object sender, EventArgs e)
        {
            uC_DsTiecCuoi1.Visible = true;
            uC_DsTiecCuoi1.BringToFront();
        }



        private void quảnLýMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlMonAn1.Visible = true;
            uC_QlMonAn1.BringToFront();
        }

        private void danhSáchSảnhCướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_DsSanhCuoi1.Visible = true;
            uC_DsSanhCuoi1.BringToFront();

        }

        private void uC_DsSanhCuoi_Load(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void danhSáchDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_DsDichVu1.Visible = true;
            uC_DsDichVu1.BringToFront();
        }

        private void danhSáchKháchMờiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_DsKhachMoi1.Visible = true;
            uC_DsKhachMoi1.BringToFront();
        }

        private void quảnLýGóiTiệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlGoi1.Visible = true;
            uC_QlGoi1.BringToFront();
        }

        private void thốngKêVậtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_TkVatLieu1.Visible = true;
            uC_TkVatLieu1.BringToFront();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_TkDoanhThu1.Visible = true;
            uC_TkDoanhThu1.BringToFront();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlHoaDon1.Visible = true;
            uC_QlHoaDon1.BringToFront();
        }

        private void quảnLýDụngCụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlDungCu1.Visible = true;
            uC_QlDungCu1.BringToFront();
        }

        private void quảnLýThuêThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlThietBi1.Visible = true;
            uC_QlThietBi1.BringToFront();
        }

        private void danhSáchĐồCướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_DsDoCuoi1.Visible = true;
            uC_DsDoCuoi1.BringToFront();
        }

        private void uC_QlThiepCuoi1_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýThiệpCướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlThiepCuoi1.Visible = true;
            uC_QlThiepCuoi1.BringToFront();
        }

        private void quảnLýNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlNguyenLieu1.Visible = true;
            uC_QlNguyenLieu1.BringToFront();
        }

        private void uC_QlNguyenLieu1_Load(object sender, EventArgs e)
        {

        }

        private void uC_QlNguyenLieu1_Load_1(object sender, EventArgs e)
        {

        }

        private void uC_DsDichVu1_Load(object sender, EventArgs e)
        {

        }

        private void uC_QlNguyenLieu1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
