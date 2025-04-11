﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiecCuoiVaDoCuoi.Dịch_Vụ_Control
{
    public partial class UC_QlGoi : UserControl
    {

        function fn = new function();
        String query;
        String query1;
        String query2;
        int id;
        public UC_QlGoi()
        {
            InitializeComponent();
        }

        private void UC_QlGoi_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM MonAn";
            DataSet ds = fn.getData(query);
            dataGridViewMonAn.DataSource = ds.Tables[0];

            query1 = "SELECT * FROM DichVu";
            DataSet ds1 = fn.getData(query1);
            dataGridViewDichVu.DataSource = ds1.Tables[0];


            query1 = "SELECT * FROM ThietBi";
            DataSet ds2 = fn.getData(query1);
            dataGridViewThietBi.DataSource = ds2.Tables[0];
            LoadDanhMucMonAn();
            LoadDanhSachMonAn();
            LoadDanhMucDichVu();
            LoadDanhSachDichVu();
        }



        private void cbDanhMucMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedDanhMuc = cbDanhMucMonAn.Text;

            if (selectedDanhMuc != "Tất cả")
            {
                string query = "SELECT * FROM Monan WHERE DanhMuc LIKE N'%" + selectedDanhMuc + "%'";
                DataSet ds = fn.getData(query);
                dataGridViewMonAn.DataSource = ds.Tables[0];
                dataGridViewMonAn.Refresh();

            }
            else
            {
                string query = "SELECT MaMA, TenMA, DanhMuc, GiaTong " +
                               "FROM MonAn";
                DataSet ds = fn.getData(query);
                if (ds.Tables.Count > 0)
                {
                    dataGridViewMonAn.DataSource = ds.Tables[0];
                    dataGridViewMonAn.Refresh();
                }
            }
        }
        private void LoadDanhMucMonAn()
        {
            try
            {
                string query = "SELECT DISTINCT DanhMuc FROM MonAn WHERE DanhMuc IS NOT NULL";
                DataSet ds = fn.getData(query);

                cbDanhMucMonAn.Items.Clear();
                cbDanhMucMonAn.Items.Add("Tất cả"); // Option mặc định

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbDanhMucMonAn.Items.Add(row["DanhMuc"].ToString());
                }

                cbDanhMucMonAn.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachMonAn(string tenMon = "", string danhMuc = "")
        {
            try
            {
                string query = "SELECT DISTINCT TenMA FROM MonAn";
                DataSet ds = fn.getData(query);

                cbTenMonAn.Items.Clear();
                cbTenMonAn.Items.Add("Tất cả");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbTenMonAn.Items.Add(row["TenMA"].ToString());
                }

                cbTenMonAn.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tên món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhMucDichVu()
        {
            try
            {
                string query = "SELECT DISTINCT DanhMuc FROM DichVu WHERE DanhMuc IS NOT NULL";
                DataSet ds = fn.getData(query);

                cbDanhMucDichVu.Items.Clear();
                cbDanhMucDichVu.Items.Add("Tất cả"); // Option mặc định

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbDanhMucDichVu.Items.Add(row["DanhMuc"].ToString());
                }

                cbDanhMucDichVu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachDichVu(string tenMon = "", string danhMuc = "")
        {
            try
            {
                string query = "SELECT DISTINCT TenDV FROM DichVu";
                DataSet ds = fn.getData(query);

                cbTenDichVu.Items.Clear();
                cbTenDichVu.Items.Add("Tất cả");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbTenDichVu.Items.Add(row["TenDV"].ToString());
                }

                cbTenDichVu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tên dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbTenMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            string selectedMonAn = cbTenMonAn.Text;

            if (selectedMonAn != "Tất cả")
            {
                string query = "SELECT * FROM MonAn WHERE TenMA LIKE N'%" + selectedMonAn + "%'";
                DataSet ds = fn.getData(query);
              dataGridViewMonAn.DataSource = ds.Tables[0];
                dataGridViewMonAn.Refresh();
            }
            else
            {
                string query = "SELECT MaMA, TenMA, DanhMuc, GiaTong " +
                               "FROM MonAn";
                DataSet ds = fn.getData(query);
                if (ds.Tables.Count > 0)
                {
                    dataGridViewMonAn.DataSource = ds.Tables[0];
                    dataGridViewMonAn.Refresh();
                }
            }
        }

        private void dataGridViewMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewMonAn.Rows.Count)
            {
                DataGridViewRow row = dataGridViewMonAn.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {

                    if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                    {
                        cbDanhMucMonAn.Text = row.Cells[2].Value?.ToString() ?? "";
                        txtMaMonAn.Text = row.Cells[0].Value?.ToString() ?? "";
                        cbTenMonAn.Text = row.Cells[1].Value?.ToString() ?? "";
                        txtGiaBan.Text = row.Cells[3].Value?.ToString() ?? "";
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void cbDanhMucDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDichVu = cbTenMonAn.Text;

            if (selectedDichVu != "Tất cả")
            {
                string query = "SELECT * FROM DichVu WHERE TenDV LIKE N'%" + selectedDichVu + "%'";
                DataSet ds = fn.getData(query);
                dataGridViewDichVu.DataSource = ds.Tables[0];
                dataGridViewDichVu.Refresh();
            }
            else
            {
                string query = "SELECT MaDV, TenDV, DanhMuc, Gia " +
                               "FROM DichVu";
                DataSet ds = fn.getData(query);
                if (ds.Tables.Count > 0)
                {
                    dataGridViewDichVu.DataSource = ds.Tables[0];
                    dataGridViewDichVu.Refresh();
                }
            }
        }

        private void dataGridViewDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewDichVu.Rows.Count)
            {
                DataGridViewRow row = dataGridViewDichVu.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {

                    if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                    {
                        cbDanhMucDichVu.Text = row.Cells[2].Value?.ToString() ?? "";
                        txtMaDichVu.Text = row.Cells[0].Value?.ToString() ?? "";
                        cbTenDichVu.Text = row.Cells[1].Value?.ToString() ?? "";
                        txtGiaMoiDichVu.Text = row.Cells[3].Value?.ToString() ?? "";
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void cbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
