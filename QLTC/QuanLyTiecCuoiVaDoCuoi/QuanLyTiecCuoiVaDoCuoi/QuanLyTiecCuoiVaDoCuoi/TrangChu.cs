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
            uC_DsTiecCuoi.Visible = false;
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
            uC_DsTiecCuoi.Visible = true;
            uC_DsTiecCuoi.BringToFront();
        }



        private void quảnLýMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_QlMonAn.Visible = true;
            uC_QlMonAn.BringToFront();
        }

        private void danhSáchSảnhCướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_DsSanhCuoi.Visible = true;
            uC_DsSanhCuoi.BringToFront();

        }

        private void uC_DsSanhCuoi_Load(object sender, EventArgs e)
        {

        }

        private void danhSachKhachMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //uC_DsKhachMoi.Visible = true;
            //uC_DsKhachMoi.BringToFront();
        }

        private void uC_DsKhachMoi1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void uC_DsKhachMoi1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
