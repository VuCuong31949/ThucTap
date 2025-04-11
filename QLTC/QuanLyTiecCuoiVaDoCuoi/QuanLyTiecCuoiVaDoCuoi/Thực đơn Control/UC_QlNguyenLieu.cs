using Guna.UI2.WinForms;
using System;
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

namespace QuanLyTiecCuoiVaDoCuoi.Thực_đơn_Control
{
    public partial class UC_QlNguyenLieu : UserControl
    {
        function fn = new function();
        String query;
        int id;
        
        public UC_QlNguyenLieu()
        {
            InitializeComponent();
        }

        private void UC_QlNguyenLieu_Load(object sender, EventArgs e)
        {
            query = " Select * from NguyenLieu ";
            DataSet ds = fn.getData(query);
            dataGridViewQlNguyenLieu.DataSource = ds.Tables[0];
            dataGridViewQlNguyenLieu.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }





       

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            if (txtTenNguyenLieu.Text != "" && cbDanhMuc.Text != "" && txtNhaCungCap.Text != "" &&
                txtSoLuong.Text != "" && cbDonViTinh.Text != "" && txtGiaNhap.Text != "" &&
                cbTrangThai.Text != "" && txtGhiChu.Text != "")
            {
                string tenNguyenLieu = txtTenNguyenLieu.Text;
                string danhMuc = cbDanhMuc.Text;
                string nhaCungCap = txtNhaCungCap.Text;
                string soLuongInput = txtSoLuong.Text.Replace(" ", "");
                string donViTinh = cbDonViTinh.Text;
                string ngayNhapKho = dtpNgayNhapKho.Value.ToString("dd/MM/yyyy"); 
                string giaNhapInput = txtGiaNhap.Text.Replace(" ", "");
                string hanSuDung = dtpHanSuDung.Value.ToString("dd/MM/yyyy");
                string trangThai = cbTrangThai.Text;
                string ghiChu = txtGhiChu.Text;

                int soLuong;
                decimal giaNhap;

                
                if (!int.TryParse(soLuongInput, out soLuong))
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }
                if (!decimal.TryParse(giaNhapInput, out giaNhap))
                {
                    MessageBox.Show("Giá nhập không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaNhap.Text = "";
                    txtGiaNhap.Focus();
                    return;
                }

                
                if (!dtpNgayNhapKho.Checked || !dtpHanSuDung.Checked)
                {
                    MessageBox.Show("Vui lòng chọn ngày nhập kho và hạn sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpHanSuDung.Value < dtpNgayNhapKho.Value)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày nhập kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpHanSuDung.Focus();
                    return;
                }

                if (!dtpNgayNhapKho.Checked || !dtpHanSuDung.Checked)
                {
                    MessageBox.Show("Vui lòng chọn ngày nhập kho và hạn sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpHanSuDung.Value < dtpNgayNhapKho.Value)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày nhập kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpHanSuDung.Focus();
                    return;
                }


                string query = "INSERT INTO NguyenLieu (TenNL, DanhMuc, NhaCungCap, SoLuong, DonVi, NgayNhap, GiaNhap, HanSuDung, TrangThai, GhiChu) " +
                               "VALUES (@TenNL, @DanhMuc, @NhaCungCap, @SoLuong, @DonVi, @NgayNhap, @GiaNhap, @HanSuDung, @TrangThai, @GhiChu)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TenNL", SqlDbType.NVarChar) { Value = tenNguyenLieu },
            new SqlParameter("@DanhMuc", SqlDbType.NVarChar) { Value = danhMuc },
            new SqlParameter("@NhaCungCap", SqlDbType.NVarChar) { Value = nhaCungCap },
            new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
            new SqlParameter("@DonVi", SqlDbType.NVarChar) { Value = donViTinh },
            new SqlParameter("@NgayNhap", SqlDbType.NVarChar) { Value = ngayNhapKho }, 
            new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = giaNhap },
            new SqlParameter("@HanSuDung", SqlDbType.NVarChar) { Value = hanSuDung },  
            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai },
            new SqlParameter("@GhiChu", SqlDbType.NVarChar) { Value = ghiChu }
                };

                fn.setData(query, "Đã thêm nguyên liệu", parameters);

                UC_QlNguyenLieu_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtTenNguyenLieu.Clear();
            cbDanhMuc.SelectedIndex = -1;
            txtNhaCungCap.Clear();
            txtSoLuong.Clear();
            cbDonViTinh.SelectedIndex = -1;
            dtpNgayNhapKho.ResetText();
            txtGiaNhap.Clear();
            dtpHanSuDung.ResetText();
            txtGhiChu.Clear();
            cbTrangThai.SelectedIndex = -1;
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayNhapKho_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpHanSuDung_ValueChanged(object sender, EventArgs e)
        {

        }



        private void dataGridViewQlNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewQlNguyenLieu.Rows.Count)
            {
                DataGridViewRow row = dataGridViewQlNguyenLieu.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    if (int.TryParse(row.Cells[0].Value.ToString(), out int id))
                    {
                        txtTenNguyenLieu.Text = row.Cells[1].Value?.ToString() ?? "";
                        cbDanhMuc.Text = row.Cells[2].Value?.ToString() ?? "";
                        txtNhaCungCap.Text = row.Cells[3].Value?.ToString() ?? "";
                        txtSoLuong.Text = row.Cells[4].Value?.ToString() ?? "";
                        cbDonViTinh.Text = row.Cells[5].Value?.ToString() ?? "";

                        
                        string ngayNhap = row.Cells[6].Value?.ToString() ?? "";
                        if (DateTime.TryParseExact(ngayNhap, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ngayNhapDate))
                        {
                            dtpNgayNhapKho.Value = ngayNhapDate;
                        }
                        else
                        {
                            MessageBox.Show("Ngày nhập kho không hợp lệ: " + ngayNhap, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtpNgayNhapKho.Value = DateTime.Now;
                        }

                        txtGiaNhap.Text = row.Cells[7].Value?.ToString() ?? "";

                        
                        string hanSuDung = row.Cells[8].Value?.ToString() ?? "";
                        if (DateTime.TryParseExact(hanSuDung, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime hanSuDungDate))
                        {
                            dtpHanSuDung.Value = hanSuDungDate;
                        }
                        else
                        {
                            MessageBox.Show("Hạn sử dụng không hợp lệ: " + hanSuDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtpHanSuDung.Value = DateTime.Now;
                        }

                        cbTrangThai.Text = row.Cells[9].Value?.ToString() ?? "";
                        txtGhiChu.Text = row.Cells[10].Value?.ToString() ?? "";
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }






        private void btnSuaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (txtTenNguyenLieu.Text != "" && cbDanhMuc.Text != "" && txtNhaCungCap.Text != "" &&
                txtSoLuong.Text != "" && cbDonViTinh.Text != "" && txtGiaNhap.Text != "" &&
                cbTrangThai.Text != "" && txtGhiChu.Text != "")
            {
                
                string tenNguyenLieu = txtTenNguyenLieu.Text;
                string danhMuc = cbDanhMuc.Text;
                string nhaCungCap = txtNhaCungCap.Text;
                string soLuongInput = txtSoLuong.Text.Replace(" ", "");
                string donViTinh = cbDonViTinh.Text;
                string ngayNhapKho = dtpNgayNhapKho.Value.ToString("dd/MM/yyyy");
                string giaNhapInput = txtGiaNhap.Text.Replace(" ", "");
                string hanSuDung = dtpHanSuDung.Value.ToString("dd/MM/yyyy");
                string trangThai = cbTrangThai.Text;
                string ghiChu = txtGhiChu.Text;

                int soLuong;
                decimal giaNhap;

                
                if (!int.TryParse(soLuongInput, out soLuong))
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }
                if (!decimal.TryParse(giaNhapInput, out giaNhap))
                {
                    MessageBox.Show("Giá nhập không hợp lệ. Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaNhap.Text = "";
                    txtGiaNhap.Focus();
                    return;
                }

                
                if (!dtpNgayNhapKho.Checked || !dtpHanSuDung.Checked)
                {
                    MessageBox.Show("Vui lòng chọn ngày nhập kho và hạn sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpHanSuDung.Value < dtpNgayNhapKho.Value)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày nhập kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpHanSuDung.Focus();
                    return;
                }

                
                if (id == 0)
                {
                    MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                string query = "UPDATE NguyenLieu SET " +
                               "TenNL = @TenNL, " +
                               "DanhMuc = @DanhMuc, " +
                               "NhaCungCap = @NhaCungCap, " +
                               "SoLuong = @SoLuong, " +
                               "DonVi = @DonVi, " +
                               "NgayNhap = @NgayNhap, " +
                               "GiaNhap = @GiaNhap, " +
                               "HanSuDung = @HanSuDung, " +
                               "TrangThai = @TrangThai, " +
                               "GhiChu = @GhiChu " +
                               "WHERE MaNL = @MaNL";

                
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TenNL", SqlDbType.NVarChar) { Value = tenNguyenLieu },
            new SqlParameter("@DanhMuc", SqlDbType.NVarChar) { Value = danhMuc },
            new SqlParameter("@NhaCungCap", SqlDbType.NVarChar) { Value = nhaCungCap },
            new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
            new SqlParameter("@DonVi", SqlDbType.NVarChar) { Value = donViTinh },
            new SqlParameter("@NgayNhap", SqlDbType.VarChar) { Value = ngayNhapKho }, 
            new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = giaNhap },
            new SqlParameter("@HanSuDung", SqlDbType.VarChar) { Value = hanSuDung },  
            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai },
            new SqlParameter("@GhiChu", SqlDbType.NVarChar) { Value = ghiChu },
            new SqlParameter("@MaNL", SqlDbType.Int) { Value = id }
                };

                
                fn.setData(query, "Đã sửa nguyên liệu", parameters);

                
                UC_QlNguyenLieu_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            
            if (id == 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này?", "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                string query = "DELETE FROM NguyenLieu WHERE MaNL = " + id;

                
                fn.setData(query, "Đã xóa nguyên liệu");

                
                UC_QlNguyenLieu_Load(this, null);
                clearAll();

                
                id = 0;
            }
        }
        private void txtTimKiemNguyenLieu_TextChanged(object sender, EventArgs e)
        {
            
            string searchText = txtTimKiemNguyenLieu.Text.Trim();

            
            string query = "SELECT * " +
                           "FROM NguyenLieu " + 
                           "WHERE TenNL LIKE '%" + searchText + "%'";

            
            DataSet ds = fn.getData(query);

            
            if (ds.Tables.Count > 0)
            {
                dataGridViewQlNguyenLieu.DataSource = ds.Tables[0];
            }
        }

        private void txtDanhMuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



      
    }
}