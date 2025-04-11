using System;
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
    public partial class UC_QlMonAn : UserControl
    {
        function fn = new function();
        String query;
        String query1;
        String query2;
        int id;
        public UC_QlMonAn()
        {
            InitializeComponent();

        }

        private void UC_QlMonAn_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM MonAn";
            DataSet ds = fn.getData(query);
            dataGridViewQlMonAn.DataSource = ds.Tables[0];

            query1 = "SELECT * FROM NguyenLieu";
            DataSet ds1 = fn.getData(query1);
            dataGridViewThemNguyenLieu.DataSource = ds1.Tables[0];


            query1 = "SELECT * FROM ChiTietMonAnNguyenLieu";
            DataSet ds2 = fn.getData(query1);
            dataGridViewNguyenLieuMonAn.DataSource = ds2.Tables[0];


        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (txtTenMonAn.Text != "" && cbDanhMuc.Text != "" &&
                txtGiaGoc.Text != "" && txtLoiNhuan.Text != "" && txtMoTaMonAn.Text != "" && cbTrangThai.Text != "")
            {
                String tenMonAn = txtTenMonAn.Text;
                String danhMuc = cbDanhMuc.Text;
                String giaGoc = txtGiaGoc.Text.Replace(" ", "");
                String loiNhuan = txtLoiNhuan.Text.Replace(" ", "");
                String moTa = txtMoTaMonAn.Text;
                String trangThai = cbTrangThai.Text;
                String giaTong = txtGiaTong.Text.Replace(" ", "");

                
                string query = "INSERT INTO MonAn (TenMA, DanhMuc, GiaGoc , LoiNhuan , GiaTong, MoTa, TrangThai) " +
                               "VALUES (@TenMA, @DanhMuc, @GiaGoc,@LoiNhuan,  @GiaTong, @MoTa, @TrangThai)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TenMA", SqlDbType.NVarChar) { Value = tenMonAn },
            new SqlParameter("@DanhMuc", SqlDbType.NVarChar) { Value = danhMuc },
            new SqlParameter("@GiaGoc", SqlDbType.Decimal) { Value = giaGoc },
            new SqlParameter("@LoiNhuan", SqlDbType.Decimal) { Value = loiNhuan },
            new SqlParameter("@GiaTong", SqlDbType.Decimal) { Value = giaTong }, 
            new SqlParameter("@MoTa", SqlDbType.NVarChar) { Value = moTa },
            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai }
                };

                fn.setData(query, "Đã thêm món ăn", parameters);

                UC_QlMonAn_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            if (txtTenMonAn.Text != "" && cbDanhMuc.Text != "" &&
                txtGiaGoc.Text != "" && txtLoiNhuan.Text != "" && txtMoTaMonAn.Text != "" && cbTrangThai.Text != "")
            {
                String tenMonAn = txtTenMonAn.Text;
                String danhMuc = cbDanhMuc.Text;
                String giaGoc = txtGiaGoc.Text.Replace(" ", "");
                String loiNhuan = txtLoiNhuan.Text.Replace(" ", "");
                String moTa = txtMoTaMonAn.Text;
                String trangThai = cbTrangThai.Text;
                String giaTong = txtGiaTong.Text.Replace(",", "").Replace(" ", "");


                if (dataGridViewQlMonAn.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần sửa!", "Warning!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string query = "UPDATE MonAn SET TenMA = @TenMA, DanhMuc = @DanhMuc, GiaGoc = @GiaGoc, LoiNhuan = @LoiNhuan, GiaTong = @GiaTong, MoTa = @MoTa, TrangThai = @TrangThai " +
                               "WHERE MaMA = @MaMA";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TenMA", SqlDbType.NVarChar) { Value = tenMonAn },
            new SqlParameter("@DanhMuc", SqlDbType.NVarChar) { Value = danhMuc },
            new SqlParameter("@GiaGoc", SqlDbType.Decimal) { Value = giaGoc },
            new SqlParameter("@LoiNhuan", SqlDbType.Int) { Value = loiNhuan },
            new SqlParameter("@GiaTong", SqlDbType.Decimal) { Value = giaTong },
            new SqlParameter("@MoTa", SqlDbType.NVarChar) { Value = moTa },
            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai },
             new SqlParameter("@MaMA", SqlDbType.Int) { Value = id }
                };

                fn.setData(query, "Đã sửa thông tin món ăn", parameters);

                UC_QlMonAn_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbDanhMucNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDanhMuc = cbDanhMucNguyenLieu.Text;

            if (selectedDanhMuc != "Tất cả")
            {


                string query = "SELECT * FROM NguyenLieu WHERE DanhMuc LIKE N'%" + selectedDanhMuc + "%'";



                DataSet ds = fn.getData(query);


                dataGridViewThemNguyenLieu.DataSource = ds.Tables[0];
                dataGridViewThemNguyenLieu.Refresh();

            }
            else
            {
                string query = "SELECT MaNL, TenNL, DanhMuc, SoLuong, DonVi, NgayNhap, GiaNhap, HanSuDung, TrangThai " +
                               "FROM NguyenLieu";
                DataSet ds = fn.getData(query);
                if (ds.Tables.Count > 0)
                {
                    dataGridViewThemNguyenLieu.DataSource = ds.Tables[0];
                    dataGridViewThemNguyenLieu.Refresh();
                }
            }


        }

        public void clearAll()
        {
            txtTenMonAn.Clear();
            cbDanhMuc.SelectedIndex = -1;
            txtGiaGoc.Clear();
            txtMoTaMonAn.Clear();
            cbTrangThai.SelectedIndex = -1;
            txtGiaTong.Clear();
            txtLoiNhuan.Clear();
            txtMaMonAn.Text = "";
            txtTenNguyenLieu.Text = "";
            txtMaNguyenLieu.Text = "";
            txtDonVi.Text = "";
            txtSoLuong.Text = "";

        }

        private void UC_QlMonAn_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_QlMonAn_Enter(object sender, EventArgs e)
        {
            UC_QlMonAn_Load(this, null);
        }


        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewQlMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewQlMonAn.Rows.Count)
            {
                DataGridViewRow row = dataGridViewQlMonAn.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {

                    if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                    {

                        txtTenMonAn.Text = row.Cells[1].Value?.ToString() ?? "";
                        cbDanhMuc.Text = row.Cells[2].Value?.ToString() ?? "";
                        txtGiaGoc.Text = row.Cells[3].Value?.ToString() ?? "";
                        txtLoiNhuan.Text = row.Cells[4].Value?.ToString() ?? "";
                        txtGiaTong.Text = row.Cells[5].Value?.ToString() ?? "";
                        txtMoTaMonAn.Text = row.Cells[6].Value?.ToString() ?? "";
                        cbTrangThai.Text = row.Cells[7].Value?.ToString() ?? "";
                        txtMaMonAn.Text = row.Cells[0].Value?.ToString() ?? "";



                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnXoaMonAn_Click(object sender, EventArgs e)
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

                string query = "DELETE FROM MonAn WHERE MaMA = " + id;


                fn.setData(query, "Đã xóa nguyên liệu");


                UC_QlMonAn_Load(this, null);
                clearAll();


                id = 0;
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewThemNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewThemNguyenLieu.Rows.Count)
            {
                DataGridViewRow row = dataGridViewThemNguyenLieu.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {

                    if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                    {

                        txtMaNguyenLieu.Text = row.Cells[0].Value?.ToString() ?? "";
                        txtTenNguyenLieu.Text = row.Cells[1].Value?.ToString() ?? "";
                        txtDonVi.Text = row.Cells[4].Value?.ToString() ?? "";
                        txtSoLuong.Text = row.Cells[3].Value?.ToString() ?? "";
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewNguyenLieuMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewNguyenLieuMonAn.Rows.Count)
            {
                DataGridViewRow row = dataGridViewNguyenLieuMonAn.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {

                    if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                    {
                        txtMaMonAn.Text = row.Cells[0].Value?.ToString() ?? "";
                        txtMaNguyenLieu.Text = row.Cells[1].Value?.ToString() ?? "";
                        txtTenNguyenLieu.Text = row.Cells[2].Value?.ToString() ?? "";
                        txtSoLuong.Text = row.Cells[3].Value?.ToString() ?? "";
                        txtDonVi.Text = row.Cells[4].Value?.ToString() ?? "";
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNguyenLieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void TinhGiaTong()
        {
            string giaGocText = txtGiaGoc.Text.Trim();
            string loiNhuanText = txtLoiNhuan.Text.Trim();

            if (decimal.TryParse(giaGocText, out decimal giaGoc) && decimal.TryParse(loiNhuanText, out decimal loiNhuan))
            {
                if (loiNhuan >= 100)
                {
                    MessageBox.Show("Lợi nhuận phải nhỏ hơn 100%! Vui lòng nhập lại.");
                    txtLoiNhuan.Text = "";
                    txtLoiNhuan.Focus();
                }
                else
                {
                    decimal giaTong = giaGoc + (giaGoc * loiNhuan / 100);
                    txtGiaTong.Text = giaTong.ToString("N0");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(giaGocText) && !decimal.TryParse(giaGocText, out _))
                {
                    MessageBox.Show("Giá gốc phải là số! Vui lòng nhập lại.");
                    txtGiaGoc.Text = "";
                    txtGiaGoc.Focus();
                }
                else if (!string.IsNullOrEmpty(loiNhuanText) && !decimal.TryParse(loiNhuanText, out _))
                {
                    MessageBox.Show("Lợi nhuận phải là số! Vui lòng nhập lại.");
                    txtLoiNhuan.Text = "";
                    txtLoiNhuan.Focus();
                }
            }
        }

        private void txtLoiNhuan_TextChanged(object sender, EventArgs e)
        {
            TinhGiaTong();
        }

        private void txtGiaGoc_TextChanged(object sender, EventArgs e)
        {
            TinhGiaTong();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtMaMonAn.Text) || string.IsNullOrEmpty(txtMaNguyenLieu.Text) ||
                string.IsNullOrEmpty(txtTenNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã món ăn, Mã nguyên liệu và Tên nguyên liệu!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string maMonAn = txtMaMonAn.Text.Trim();
            string maNguyenLieu = txtMaNguyenLieu.Text.Trim();
            string tenNguyenLieu = txtTenNguyenLieu.Text;
            string soLuongInput = txtSoLuong.Text.Trim().Replace(" ", "");
            string donVi = txtDonVi.Text.Trim();

            


        

            
            decimal soLuong = 0;
            if (!string.IsNullOrEmpty(soLuongInput) && !decimal.TryParse(soLuongInput, out soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            
            string queryGetNL = "SELECT SoLuong FROM NguyenLieu WHERE MaNL = " + maNguyenLieu;
            DataSet ds = fn.getData(queryGetNL);

         

            
            int soLuongNguyenLieu = Convert.ToInt32(ds.Tables[0].Rows[0]["SoLuong"]);

            
            if (soLuong > soLuongNguyenLieu)
            {
                MessageBox.Show($"Số lượng nhập ({soLuong}) vượt quá số lượng hiện có ({soLuongNguyenLieu}) trong kho! Vui lòng nhập lại.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            
            string query = "INSERT INTO ChiTietMonAnNguyenLieu (MaMA, MaNL, TenNL, SoLuong, DonVi) " +
                           "VALUES (@MaMA, @MaNL, @TenNL, @SoLuong, @DonVi)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaMA", SqlDbType.Int) { Value = maMonAn },
        new SqlParameter("@MaNL", SqlDbType.Int) { Value = maNguyenLieu },
        new SqlParameter("@TenNL", SqlDbType.NVarChar) { Value = tenNguyenLieu },
        new SqlParameter("@SoLuong", SqlDbType.Decimal) { Value = soLuong == 0 ? (object)DBNull.Value : soLuong },
        new SqlParameter("@DonVi", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(donVi) ? (object)DBNull.Value : donVi }
            };

            fn.setData(query, "Đã thêm nguyên liệu vào món ăn", parameters);

            UC_QlMonAn_Load(this, null);

            clearAll();
        }

        

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            string maMonAn = txtMaMonAn.Text.Trim();
            string maNguyenLieu = txtMaNguyenLieu.Text.Trim();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này?", "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string query = "DELETE FROM ChiTietMonAnNguyenLieu WHERE MaMA = " + maMonAn + " AND MaNL = "+ maNguyenLieu + "  ";


                fn.setData(query, "Đã xóa nguyên liệu");


                UC_QlMonAn_Load(this, null);
                clearAll();


                id = 0;
            }
        }
    }

    }
