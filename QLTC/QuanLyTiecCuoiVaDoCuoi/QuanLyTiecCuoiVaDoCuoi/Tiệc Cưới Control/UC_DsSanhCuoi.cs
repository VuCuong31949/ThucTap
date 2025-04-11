﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiecCuoiVaDoCuoi.Tiệc_Cưới_Control
{
    public partial class UC_DsSanhCuoi : UserControl
    {
        function fn = new function();
        String query;
        int id;
        public UC_DsSanhCuoi()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void DsSanhCuoi_Load(object sender, EventArgs e)
        {
            query = " Select * from SanhCuoi ";
            DataSet ds = fn.getData(query);
            DataGridViewQLSanhCuoi.DataSource = ds.Tables[0];
            DataGridViewQLSanhCuoi.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemSanh_Click(object sender, EventArgs e)
        {
            if (txtTenSanhCuoi.Text != "" && txtSoLuongban.Text != "" && txtDientich.Text != "" && cbLoaiSanh.Text != "" && cbChonDen.Text != "" && txtSoLuongDen.Text != "" && cbChonmayLanh.Text != "" &&
               txtSoLuongMayLanh.Text != "" && cbChonMayChieu.Text != "" && cbChonBackDrop.Text != "" && cbChonManHinh.Text != "" && txtTongChiPhiSanh.Text != "")
            {
                string tenSanhCuoi = txtTenSanhCuoi.Text;
                string SLBan = txtSoLuongban.Text;
                string DienTich = txtDientich.Text;
                string LoaiSanh = cbLoaiSanh.Text;
                string ChonDen = cbChonDen.Text;
                string SLDen = txtSoLuongDen.Text;
                string ChonMaylanh = cbChonmayLanh.Text;
                string SLMayLanh = txtSoLuongMayLanh.Text;
                string ChonMayChieu = cbChonMayChieu.Text;
                string Chonbackdrop = cbChonBackDrop.Text;
                string ChonManHinh = cbChonManHinh.Text;
                string TongPhiSanh = txtTongChiPhiSanh.Text;

                int soLuongBan, soLuongDen, soLuongMayLanh;
                decimal TongPhi;

                if (!int.TryParse(SLBan, out soLuongBan))
                {
                    MessageBox.Show("Số lượng bàn không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongban.Text = "";
                    txtSoLuongban.Focus();
                    return;
                }
                if (!int.TryParse(SLDen, out soLuongDen))
                {
                    MessageBox.Show("Số lượng đèn không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongDen.Text = "";
                    txtSoLuongDen.Focus();
                    return;
                }
                if (!int.TryParse(SLMayLanh, out soLuongMayLanh))
                {
                    MessageBox.Show("Số lượng máy lạnh không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongMayLanh.Text = "";
                    txtSoLuongMayLanh.Focus();
                    return;
                }

                if (!decimal.TryParse(TongPhiSanh, out TongPhi))
                {
                    MessageBox.Show("Tổng chi phí sảnh không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTongChiPhiSanh.Text = "";
                    txtTongChiPhiSanh.Focus();
                    return;
                }


                // Câu lệnh SQL để thêm dữ liệu vào bảng SanhCuoi
                string query = "INSERT INTO SanhCuoi (TenSC, SoLuongBan, DienTich, LoaiSanh, LoaiDen, SoLuongDen, LoaiMayLanh, SLMayLanh, LoaiMayChieu, LoaiBackdrop, LoaiManHinh, TongChiPhi) " +
                               "VALUES (@TenSC, @SoLuongBan, @DienTich, @LoaiSanh, @LoaiDen, @SoLuongDen, @LoaiMayLanh, @SLMayLanh, @LoaiMayChieu, @LoaiBackdrop, @LoaiManHinh, @TongChiPhi)";

                // Tạo mảng tham số SQL
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TenSC", SqlDbType.NVarChar) { Value = tenSanhCuoi },
            new SqlParameter("@SoLuongBan", SqlDbType.Int) { Value = soLuongBan },
            new SqlParameter("@DienTich", SqlDbType.NVarChar) { Value = DienTich },
            new SqlParameter("@LoaiSanh", SqlDbType.NVarChar) { Value = LoaiSanh },
            new SqlParameter("@LoaiDen", SqlDbType.NVarChar) { Value = ChonDen },
            new SqlParameter("@SoLuongDen", SqlDbType.Int) { Value = soLuongDen },
            new SqlParameter("@LoaiMayLanh", SqlDbType.NVarChar) { Value = ChonMaylanh },
            new SqlParameter("@SLMayLanh", SqlDbType.Int) { Value = soLuongMayLanh },
            new SqlParameter("@LoaiMayChieu", SqlDbType.NVarChar) { Value = ChonMayChieu },
            new SqlParameter("@LoaiBackdrop", SqlDbType.NVarChar) { Value = Chonbackdrop },
            new SqlParameter("@LoaiManHinh", SqlDbType.NVarChar) { Value = ChonManHinh },
            new SqlParameter("@TongChiPhi", SqlDbType.Decimal) { Value = TongPhiSanh }
                };

                fn.setData(query, "Đã thêm nguyên liệu", parameters);

                DsSanhCuoi_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
             txtTenSanhCuoi.Clear();
            txtSoLuongban.Clear();
            txtDientich.Clear();
            cbLoaiSanh.SelectedIndex = -1;
            cbChonDen.SelectedIndex = -1;
            txtSoLuongDen.Clear();
            cbChonmayLanh.SelectedIndex = -1;
            txtSoLuongMayLanh.Clear();
            cbChonMayChieu.SelectedIndex = -1;
            cbChonBackDrop.SelectedIndex = -1;
            cbChonManHinh.SelectedIndex = -1;
            txtTongChiPhiSanh.Clear();
           
        }

        private void DataGridViewQLSanhCuoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewQLSanhCuoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridViewQLSanhCuoi.Rows.Count)
    {
        DataGridViewRow row = DataGridViewQLSanhCuoi.Rows[e.RowIndex];
        if (row.Cells[0].Value != null)
        {
            if (int.TryParse(row.Cells[0].Value.ToString(), out int id))
            {
                this.id = id; // Lưu id để sử dụng cho sửa/xóa
                txtTenSanhCuoi.Text = row.Cells[1].Value?.ToString() ?? "";
                txtSoLuongban.Text = row.Cells[2].Value?.ToString() ?? "";
                txtDientich.Text = row.Cells[3].Value?.ToString() ?? "";
                cbLoaiSanh.Text = row.Cells[4].Value?.ToString() ?? "";
                cbChonDen.Text = row.Cells[5].Value?.ToString() ?? "";
                txtSoLuongDen.Text = row.Cells[6].Value?.ToString() ?? "";
                cbChonmayLanh.Text = row.Cells[7].Value?.ToString() ?? "";
                txtSoLuongMayLanh.Text = row.Cells[8].Value?.ToString() ?? "";
                cbChonMayChieu.Text = row.Cells[9].Value?.ToString() ?? "";
                cbChonBackDrop.Text = row.Cells[10].Value?.ToString() ?? "";
                cbChonManHinh.Text = row.Cells[11].Value?.ToString() ?? "";
                txtTongChiPhiSanh.Text = row.Cells[12].Value?.ToString() ?? "";
            }
            else
            {
                MessageBox.Show("Không thể lấy mã sảnh cưới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
        }

        private void btnSuaSanh_Click(object sender, EventArgs e)
        {
            if (txtTenSanhCuoi.Text != "" && txtSoLuongban.Text != "" && txtDientich.Text != "" && cbLoaiSanh.Text != "" && cbChonDen.Text != "" && txtSoLuongDen.Text != "" && cbChonmayLanh.Text != "" &&
                txtSoLuongMayLanh.Text != "" && cbChonMayChieu.Text != "" && cbChonBackDrop.Text != "" && cbChonManHinh.Text != "" && txtTongChiPhiSanh.Text != "")
            {
                string tenSanhCuoi = txtTenSanhCuoi.Text;
                string SLBan = txtSoLuongban.Text;
                string DienTich = txtDientich.Text;
                string LoaiSanh = cbLoaiSanh.Text;
                string ChonDen = cbChonDen.Text;
                string SLDen = txtSoLuongDen.Text;
                string ChonMaylanh = cbChonmayLanh.Text;
                string SLMayLanh = txtSoLuongMayLanh.Text;
                string ChonMayChieu = cbChonMayChieu.Text;
                string Chonbackdrop = cbChonBackDrop.Text;
                string ChonManHinh = cbChonManHinh.Text;
                string TongPhiSanh = txtTongChiPhiSanh.Text;

                int soLuongBan, soLuongDen, soLuongMayLanh;
                decimal TongPhi;

                if (!int.TryParse(SLBan, out soLuongBan))
                {
                    MessageBox.Show("Số lượng bàn không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongban.Text = "";
                    txtSoLuongban.Focus();
                    return;
                }
                if (!int.TryParse(SLDen, out soLuongDen))
                {
                    MessageBox.Show("Số lượng đèn không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongDen.Text = "";
                    txtSoLuongDen.Focus();
                    return;
                }
                if (!int.TryParse(SLMayLanh, out soLuongMayLanh))
                {
                    MessageBox.Show("Số lượng máy lạnh không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongMayLanh.Text = "";
                    txtSoLuongMayLanh.Focus();
                    return;
                }

                if (!decimal.TryParse(TongPhiSanh, out TongPhi))
                {
                    MessageBox.Show("Tổng chi phí sảnh không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTongChiPhiSanh.Text = "";
                    txtTongChiPhiSanh.Focus();
                    return;
                }

                // Câu lệnh SQL để sửa dữ liệu
               string query = "UPDATE SanhCuoi SET " +
                        "TenSC = @TenSC, " +
                        "SoLuongBan = @SoLuongBan, " +
                        "DienTich = @DienTich, " +
                        "LoaiSanh = @LoaiSanh, " +
                        "LoaiDen = @LoaiDen, " +
                        "SoLuongDen = @SoLuongDen, " +
                        "LoaiMayLanh = @LoaiMayLanh, " +
                        "SLMayLanh = @SLMayLanh, " +
                        "LoaiMayChieu = @LoaiMayChieu, " +
                        "LoaiBackdrop = @LoaiBackdrop, " +
                        "LoaiManHinh = @LoaiManHinh, " +
                        "TongChiPhi = @TongChiPhi " +
                        "WHERE MaSC = @MaSC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSC", SqlDbType.NVarChar) { Value = tenSanhCuoi },
                    new SqlParameter("@SoLuongBan", SqlDbType.Int) { Value = soLuongBan },
                    new SqlParameter("@DienTich", SqlDbType.NVarChar) { Value = DienTich },
                    new SqlParameter("@LoaiSanh", SqlDbType.NVarChar) { Value = LoaiSanh },
                    new SqlParameter("@LoaiDen", SqlDbType.NVarChar) { Value = ChonDen },
                    new SqlParameter("@SoLuongDen", SqlDbType.Int) { Value = soLuongDen },
                    new SqlParameter("@LoaiMayLanh", SqlDbType.NVarChar) { Value = ChonMaylanh },
                    new SqlParameter("@SLMayLanh", SqlDbType.Int) { Value = soLuongMayLanh },
                    new SqlParameter("@LoaiMayChieu", SqlDbType.NVarChar) { Value = ChonMayChieu},
                    new SqlParameter("@LoaiBackdrop", SqlDbType.NVarChar) { Value = Chonbackdrop },
                    new SqlParameter("@LoaiManHinh", SqlDbType.NVarChar) { Value = ChonManHinh },
                    new SqlParameter("@TongChiPhi", SqlDbType.Decimal) { Value = TongPhi },
                    new SqlParameter("@MaSC", SqlDbType.Int) { Value = id }
                };

                fn.setData(query, "Đã sửa sảnh cưới", parameters);
                DsSanhCuoi_Load(this, null);
                clearAll();
                id = 0; // Reset ID sau khi sửa
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc (Tên sảnh, Số lượng bàn, Tổng chi phí)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaSanh_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Vui lòng chọn sảnh cưới cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sảnh cưới này?", "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                query = "DELETE FROM SanhCuoi WHERE MaSC = @MaSC";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaSC", SqlDbType.Int) { Value = id }
                };

                fn.setData(query, "Đã xóa sảnh cưới", parameters);
                DsSanhCuoi_Load(this, null);
                clearAll();
                id = 0;
            }
        }
    }
}
