using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSach
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }

        //SqlConnection conn = null;
        //Tạo đối tượng conn thuộc lớp SqlConnection
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3SIUQHOQ\SQL;Initial Catalog=QLSach;Integrated Security=True");
        //Khởi tại đối tượng DataSet 
        DataSet ds = new DataSet();
        SqlDataAdapter daBanHang;
        SqlDataAdapter daSach;

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = @"Data Source=LAPTOP-3SIUQHOQ\SQL;Initial Catalog=QLSach;Integrated Security=True";

            //Dữ liệu Datagridview Bán hàng
            string sQueryBanHang = @"select b.MaHD, s.MaSach, s.TenSach, b.TGBan, s.GiaBan, b.SLBan, b.ThanhTien, s.SLTon
                                     from BANHANG as b, SACH  as s
                                     where b.MaSach = s.MaSach";  //Câu lệnh truy vấn để đưa vào DataAdapter

            daBanHang = new SqlDataAdapter(sQueryBanHang, conn);  //Tạo 1 đối tượng SqlDataAdapter tên daBanHang
            daBanHang.Fill(ds, "tblBanHang");
            dgBanHang.DataSource = ds.Tables["tblBanHang"];

            //Dữ liệu combobox Sach
            string sQuerySach = @"select * from Sach";  //Câu lệnh truy vấn để đưa vào DataAdapter
            daSach = new SqlDataAdapter(sQuerySach, conn);  //Tạo 1 đối tượng SqlDataAdapter tên daSach
            daSach.Fill(ds, "tblSach");
            cmbMaSach.DataSource = ds.Tables["tblSach"];  //Đưa dữ liệu trong DataSet tên ds lên dataGridview
            cmbMaSach.DisplayMember = "MaSach";   //Hiện tên trường
            cmbMaSach.ValueMember = "MaSach";   //Lấy giá trị của trường

            //// … đặt tiêu đề tiếng Việt, định độ rộng cho các trường 
            dgBanHang.Columns["MaHD"].HeaderText = "Mã HD";
            dgBanHang.Columns["MaHD"].Width = 100;
            dgBanHang.Columns["MaSach"].HeaderText = "Mã sách";
            dgBanHang.Columns["MaSach"].Width = 250;
            dgBanHang.Columns["TenSach"].HeaderText = "Tên sách";
            dgBanHang.Columns["TenSach"].Width = 300;
            dgBanHang.Columns["TGBan"].HeaderText = "Thời gian bán";
            dgBanHang.Columns["TGBan"].Width = 150;
            dgBanHang.Columns["GiaBan"].HeaderText = "Giá bán";
            dgBanHang.Columns["GiaBan"].Width = 120;
            dgBanHang.Columns["SLBan"].HeaderText = "SL bán";
            dgBanHang.Columns["SLBan"].Width = 100;
            dgBanHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgBanHang.Columns["ThanhTien"].Width = 120;
            dgBanHang.Columns["SLTon"].HeaderText = "SL tồn";
            dgBanHang.Columns["SLTon"].Width = 100;   
            
            dgBanHang.Columns["MaSach"].Visible = false; //Ẩn cột Mã sách
            dgBanHang.Columns["SLTon"].Visible = false;

            //Tô màu xen kẽ cho Datagridview 
            dgBanHang.RowsDefaultCellStyle.BackColor = Color.White;
            dgBanHang.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            //Command (hỗ trợ xử lý lệnh) Thêm vào Bán hàng
            //Câu lệnh được tham số hóa
            string sThemBanHang = @"insert into BANHANG values(@MaHD, @MaSach, @TGBan,  @SLBan, @ThanhTien)";
            SqlCommand cmThemBanHang = new SqlCommand(sThemBanHang, conn);
            cmThemBanHang.Parameters.Add("@MaHD", SqlDbType.NVarChar, 10, "MaHD");
            cmThemBanHang.Parameters.Add("@MaSach", SqlDbType.NVarChar, 50, "MaSach");
            cmThemBanHang.Parameters.Add("@TGBan", SqlDbType.SmallDateTime, 50, "TGBan");
            //cmThemBanHang.Parameters.Add("@GiaBan", SqlDbType.Float, 50, "GiaBan");
            cmThemBanHang.Parameters.Add("@SLBan", SqlDbType.Int, 50, "SLBan");
            cmThemBanHang.Parameters.Add("@ThanhTien", SqlDbType.Float, 50, "ThanhTien");

            daBanHang.InsertCommand = cmThemBanHang;

            /*string sUpdateSLSach = @"update SACH set SLTon = @SLTon where MaSach = @MaSach";
             SqlCommand cmUpdateSLSach = new SqlCommand(sUpdateSLSach, conn);
             cmUpdateSLSach.Parameters.Add("@SLTon", SqlDbType.Int, 4, "SLTon");
             daSach.UpdateCommand = cmUpdateSLSach;*/


            //Command Sửa Bán hàng
            string sSuaBanHang = @"update BANHANG set MaSach=@MaSach, TGBan=@TGBan, SLBan=@SLBan, ThanhTien=@ThanhTien
                                   where MaHD=@MaHD";
            SqlCommand cmSuaBanHang = new SqlCommand(sSuaBanHang, conn);
            cmSuaBanHang.Parameters.Add("@MaHD", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaBanHang.Parameters.Add("@MaSach", SqlDbType.NVarChar, 50, "MaSach");
            cmSuaBanHang.Parameters.Add("@TGBan", SqlDbType.SmallDateTime, 50, "TGBan");
            //cmSuaBanHang.Parameters.Add("@GiaBan", SqlDbType.Float, 50, "GiaBan");
            cmSuaBanHang.Parameters.Add("@SLBan", SqlDbType.Int, 50, "SLBan");
            cmSuaBanHang.Parameters.Add("@ThanhTien", SqlDbType.Float, 50, "ThanhTien");

            daBanHang.UpdateCommand = cmSuaBanHang;

            //Command Xóa bán hàng
            string sXoaBanHang = @"delete from BANHANG where MaHD = @MaHD";
            SqlCommand cmXoaBanHang = new SqlCommand(sXoaBanHang, conn);
            cmXoaBanHang.Parameters.Add("@MaHD", SqlDbType.NVarChar, 10, "MaHD");

            daBanHang.DeleteCommand = cmXoaBanHang;
        }

        private void dgBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khi chọn 1 dòng trên DataGridView thông tin sẽ hiển thị lên các control tương ứng trên Form
            DataGridViewRow dr = dgBanHang.SelectedRows[0];
            txtMaHD.Text = dr.Cells["MaHD"].Value.ToString();
            cmbMaSach.Text = dr.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dr.Cells["TenSach"].Value.ToString();
            dtTGBan.Text = dr.Cells["TGBan"].Value.ToString();
            txtGiaBan.Text = dr.Cells["GiaBan"].Value.ToString();
            txtSLBan.Text = dr.Cells["SLBan"].Value.ToString();
            txtThanhTien.Text = dr.Cells["ThanhTien"].Value.ToString();
        }

        //Kiểm tra Mã Hóa đơn trùng
        public int kiemtra()
        {
            for (int i = 0; i < dgBanHang.RowCount - 1; i++)
            {
                if (txtMaHD.Text == dgBanHang.Rows[i].Cells["MaHD"].Value.ToString())
                    return 0;
            }
            return 1;
        }

        private void btnThem_Click(object sender, EventArgs e)  //Thêm dữ liệu vào dâtgridview
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã Hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (kiemtra() == 0)
                    MessageBox.Show("Đã tồn tại Mã Hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Thêm 1 dòng vào bảng tblBanHang
                    DataRow row = ds.Tables["tblBanHang"].NewRow();

                    row["MaHD"] = txtMaHD.Text;                 
                    row["MaSach"] = cmbMaSach.SelectedValue;
                    row["TenSach"] = txtTenSach.Text;
                    row["TGBan"] = dtTGBan.Text;
                    row["GiaBan"] = txtGiaBan.Text;
                    row["SLBan"] = txtSLBan.Text;
                    row["ThanhTien"] = txtThanhTien.Text;
                    row["SLTon"] = txtSLTon.Text;

                    ds.Tables["tblBanHang"].Rows.Add(row);  //Đưa các dòng này vào table tblBanHang
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Không được chỉnh sửa Mã Hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Thêm 1 dòng vào bảng tblBanHang
                DataGridViewRow dr = dgBanHang.SelectedRows[0];
                dgBanHang.BeginEdit(true);

                dr.Cells["MaHD"].Value = txtMaHD.Text;
                dr.Cells["MaSach"].Value =cmbMaSach.SelectedValue;
                dr.Cells["TenSach"].Value = txtTenSach.Text;
                dr.Cells["TGBan"].Value = dtTGBan.Text;
                dr.Cells["GiaBan"].Value = txtGiaBan.Text;
                dr.Cells["SLBan"].Value = txtSLBan.Text;
                dr.Cells["ThanhTien"].Value = txtThanhTien.Text;

                dgBanHang.EndEdit();
                MessageBox.Show("Đã cập nhật vào Thông tin Bán hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgBanHang.SelectedRows.Count > 0) //Lệnh đếm, dòng đã được chọn
            {
                MessageBox.Show("Bạn có muốn xóa thông tin này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                {
                    dgBanHang.Rows.Remove(dgBanHang.SelectedRows[0]);
                    txtMaHD.Clear();
                    cmbMaSach.ResetText();
                    txtTenSach.ResetText();
                    dtTGBan.ResetText();
                    txtGiaBan.Clear();
                    txtSLBan.Clear(); 
                    txtThanhTien.Clear();

                    txtMaHD.Focus();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            daBanHang.Update(ds, "tblBanHang");
                dgBanHang.Refresh();
                MessageBox.Show("Lưu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn hủy các thao tác vừa rồi không?", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Question);
            {
                ds.Tables["tblBanHang"].RejectChanges(); //Hủy các thao tác trước khi lưu
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát Quản lý bán hàng không?", "Thông báo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        public string GetFieldValues(string sql)  //Truy xuất giá trị hiện tại của một trường
        {
            string s = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                s = reader.GetValue(0).ToString();
            reader.Close();
            return s;
        }
        /*private void cmbTenSach_TextChanged(object sender, EventArgs e)
        {
            //if (conn == null)
            //conn = new SqlConnection(conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string str;
            if (cmbMaSach.Text == "")
            {
                txtTenSach.Text = "";
                txtGiaBan.Text = "";
                txtSLTon.Text = "";
            }
            //Khi chọn Mã Sách thì các thông tin của Sách sẽ hiện ra
            str = "Select TenSach from Sach where MaSach = N'" + cmbMaSach.SelectedValue + "'";
            txtTenSach.Text = GetFieldValues(str);
            str = "Select GiaBan from Sach where MaSach = N'" + cmbMaSach.SelectedValue + "'";
            txtGiaBan.Text = GetFieldValues(str);
            str = "Select SLTon from Sach where MaSach = N'" + cmbMaSach.SelectedValue + "'";
            txtSLTon.Text = GetFieldValues(str);
            conn.Close();
        }*/

        private void txtSLBan_TextChanged(object sender, EventArgs e)
        {
            double giaban, thanhtien, soluong;
            if (txtSLBan.Text == "")
            {
                soluong = 0;
            }
            else
            {
                soluong = Convert.ToDouble(txtSLBan.Text);
                giaban = Convert.ToDouble(txtGiaBan.Text);
                thanhtien = giaban * soluong;
                txtThanhTien.Text = thanhtien.ToString();
            }

            double slban, slton;
            if (txtSLBan.Text == "")
            {
                slban = 0;
            }
            else
            {
                slban = Convert.ToDouble(txtSLBan.Text);
                slton = Convert.ToDouble(txtSLTon.Text);
                slton = slton - slban;
                txtSLTon.Text = slton.ToString();
            }
        }

        private void cmbMaSach_TextChanged(object sender, EventArgs e)
        {
            //if (conn == null)
            //conn = new SqlConnection(conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string str;
            if (cmbMaSach.Text == "")
            {
                txtTenSach.Text = "";
                txtGiaBan.Text = "";
                txtSLTon.Text = "";
            }
            //Khi chọn Mã Sách thì các thông tin của Sách sẽ hiện ra
            str = "Select TenSach from Sach where MaSach = N'" + cmbMaSach.SelectedValue + "'";
            txtTenSach.Text = GetFieldValues(str);
            str = "Select GiaBan from Sach where MaSach = N'" + cmbMaSach.SelectedValue + "'";
            txtGiaBan.Text = GetFieldValues(str);
            str = "Select SLTon from Sach where MaSach = N'" + cmbMaSach.SelectedValue + "'";
            txtSLTon.Text = GetFieldValues(str);
            conn.Close();
        }
    }
}