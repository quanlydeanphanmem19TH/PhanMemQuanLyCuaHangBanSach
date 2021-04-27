using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Tạo chuỗi kết nối

namespace QLSach
{
    public partial class frmQLThongTinSach : Form
    {
        public frmQLThongTinSach()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        //Khởi tại đối tượng DataSet 
        DataSet ds = new DataSet("dsQLSach");
        SqlDataAdapter daSach;
        SqlDataAdapter daNXB;
        SqlDataAdapter daTheLoai;
        SqlDataAdapter daTacGia;

        private void frmQLThongTinSach_Load(object sender, EventArgs e)
        {         
            //Khai báo chuỗi kết nối để kết nối đến cơ sở dữ liệu QLSach
            conn.ConnectionString = @"Data Source=LAPTOP-3SIUQHOQ\SQL;Initial Catalog=QLSach;Integrated Security=True";

            //Dữ liệu combobox NXB
            string sQueryNXB = @"select * from NXB";  //Câu lệnh truy vấn để đưa vào DataAdapter
            daNXB = new SqlDataAdapter(sQueryNXB, conn);  //Tạo 1 đối tượng SqlDataAdapter tên daNXB
            daNXB.Fill(ds, "tblNXB");
            cmbNXB.DataSource = ds.Tables["tblNXB"];  //Đưa dữ liệu trong DataSet tên ds lên dataGirdview
            cmbNXB.DisplayMember = "TenNXB";   //Hiện tên trường
            cmbNXB.ValueMember = "MaNXB";   //Lấy giá trị của trường

            //Dữ liệu combobox Thể loại
            string sQueryTheLoai = @"select * from TheLoai";
            daTheLoai = new SqlDataAdapter(sQueryTheLoai, conn);  
            daTheLoai.Fill(ds, "tblTheLoai");  //Lấy dữ liệu của table TheLoai đổ vào DataSet ds thông qua lệnh Select
            cmbTheLoai.DataSource = ds.Tables["tblTheLoai"];
            cmbTheLoai.DisplayMember = "TenTheLoai";
            cmbTheLoai.ValueMember = "MaTheLoai";

            //Dữ liệu combobox Tác giả
            string sQueryTacGia = @"select * from TacGia";
            daTacGia = new SqlDataAdapter(sQueryTacGia, conn);
            daTacGia.Fill(ds, "tblTacGia");  //Lấy dữ liệu của table TheLoai đổ vào DataSet ds thông qua lệnh Select
            cmbTacGia.DataSource = ds.Tables["tblTacGia"];
            cmbTacGia.DisplayMember = "TenTacGia";
            cmbTacGia.ValueMember = "MaTacGia";

            //Dữ liệu datagrid DS Sách
            string sQuerySach = @"select n.*, c.TenTheLoai, d.TenNXB, e.TenTacGia 
                                  from Sach n, TheLoai c, NXB d, TacGia e 
                                  where n.MaTheLoai = c.MaTheLoai and n.MaNXB = d.MaNXB and n.MaTacGia = e.MaTacGia";

            daSach = new SqlDataAdapter(sQuerySach, conn); 
            daSach.Fill(ds, "tblSach");
            dgSach.DataSource = ds.Tables["tblSach"];

            //// … đặt tiêu đề tiếng Việt, định độ rộng cho các trường 
            dgSach.Columns["MaSach"].HeaderText = "Mã sách";
            dgSach.Columns["MaSach"].Width = 90;
            dgSach.Columns["TenSach"].HeaderText = "Tên sách";
            dgSach.Columns["TenSach"].Width = 220;
            dgSach.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgSach.Columns["GiaNhap"].Width = 90;
            dgSach.Columns["GiaBan"].HeaderText = "Giá bán";
            dgSach.Columns["GiaBan"].Width = 80;
            dgSach.Columns["SLTon"].HeaderText = "SL tồn";
            dgSach.Columns["SLTon"].Width = 80;
            dgSach.Columns["TenNXB"].HeaderText = "NXB";
            dgSach.Columns["TenNXB"].Width = 80;
            dgSach.Columns["NamXB"].HeaderText = "Năm XB";
            dgSach.Columns["NamXB"].Width = 90;
            dgSach.Columns["TenTheLoai"].HeaderText = "Thể loại";
            dgSach.Columns["TenTheLoai"].Width = 120;
            dgSach.Columns["TenTacGia"].HeaderText = "Tác giả";
            dgSach.Columns["TenTacGia"].Width = 120;

            dgSach.Columns["MaNXB"].Visible = false;
            dgSach.Columns["MaTheLoai"].Visible = false;
            dgSach.Columns["MaTacGia"].Visible = false;
            //dgSach.Columns["MaSach"].Visible = false;  //Ẩn row (cột) Mã Sách

            //Tô màu xen kẽ cho Datagridview DgSach
            dgSach.RowsDefaultCellStyle.BackColor = Color.White;
            dgSach.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            // Command Thêm Sách
            string sThemSach = @"insert into Sach values(@MaSach, @TenSach, @GiaNhap, @GiaBan, @SLTon, @MaTheLoai, @MaTacGia, @MaNXB, @NamXB)"; 
            SqlCommand cmThemSach = new SqlCommand(sThemSach, conn);
            cmThemSach.Parameters.Add("@MaSach",SqlDbType.NVarChar, 10,"MaSach");
            cmThemSach.Parameters.Add("@TenSach", SqlDbType.NVarChar, 50, "TenSach");
            cmThemSach.Parameters.Add("@GiaNhap", SqlDbType.NVarChar, 10, "GiaNhap");
            cmThemSach.Parameters.Add("@GiaBan", SqlDbType.NVarChar, 10, "GiaBan");
            cmThemSach.Parameters.Add("@SLTon", SqlDbType.Int, 3, "SLTon");
            cmThemSach.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar, 50, "MaTheLoai");
            cmThemSach.Parameters.Add("@MaTacGia", SqlDbType.NVarChar, 25, "MaTacGia");
            cmThemSach.Parameters.Add("@MaNXB", SqlDbType.NVarChar, 25, "MaNXB");
            cmThemSach.Parameters.Add("@NamXB", SqlDbType.NVarChar, 25, "NamXB");

            daSach.InsertCommand = cmThemSach;

            //Command Sửa Sách
            string sSuaSach = @"update Sach set TenSach=@TenSach, GiaNhap=@GiaNhap, GiaBan=@GiaBan, SLTon=@SLTon, 
                    MaTheLoai=@MaTheLoai, MaTacGia=@MaTacGia, MaNXB=@MaNXB, NamXB=@NamXB 
                                where MaSach=@MaSach";
            SqlCommand cmSuaSach = new SqlCommand(sSuaSach, conn);
            cmSuaSach.Parameters.Add("@MaSach", SqlDbType.NVarChar, 10, "MaSach");
            cmSuaSach.Parameters.Add("@TenSach", SqlDbType.NVarChar, 50, "TenSach");
            cmSuaSach.Parameters.Add("@GiaNhap", SqlDbType.NVarChar, 10, "GiaNhap");
            cmSuaSach.Parameters.Add("@GiaBan", SqlDbType.NVarChar, 10, "GiaBan");
            cmSuaSach.Parameters.Add("@SLTon", SqlDbType.Int, 3, "SLTon");
            cmSuaSach.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar, 50, "MaTheLoai");
            cmSuaSach.Parameters.Add("@MaTacGia", SqlDbType.NVarChar, 25, "MaTacGia");
            cmSuaSach.Parameters.Add("@MaNXB", SqlDbType.NVarChar, 25, "MaNXB");
            cmSuaSach.Parameters.Add("@NamXB", SqlDbType.NVarChar, 25, "NamXB");

            daSach.UpdateCommand = cmSuaSach;

            //Command Xóa Sách
            string sXoaSach = @"delete from Sach where MaSach = @MaSach";
            SqlCommand cmXoaSach = new SqlCommand(sXoaSach, conn);
            cmXoaSach.Parameters.Add("@MaSach", SqlDbType.NVarChar, 5, "MaSach");

            daSach.DeleteCommand = cmXoaSach;
        }

        private void dgSach_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgSach.SelectedRows[0];
            txtMaSach.Text = dr.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dr.Cells["TenSach"].Value.ToString();
            txtGiaNhap.Text = dr.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = dr.Cells["GiaBan"].Value.ToString();
            txtSLTon.Text = dr.Cells["SLTon"].Value.ToString();
            cmbTheLoai.Text = dr.Cells["TenTheLoai"].Value.ToString();
            cmbTacGia.Text = dr.Cells["TenTacGia"].Value.ToString();
            cmbNXB.Text = dr.Cells["TenNXB"].Value.ToString();
            txtNamXB.Text = dr.Cells["NamXB"].Value.ToString();
        }

        private void dgSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khi chọn 1 dòng trên DataGridView thông tin sẽ hiển thị lên các control tương ứng trên Form
            DataGridViewRow dr = dgSach.SelectedRows[0];
            txtMaSach.Text = dr.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dr.Cells["TenSach"].Value.ToString();
            txtGiaNhap.Text = dr.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = dr.Cells["GiaBan"].Value.ToString();
            txtSLTon.Text = dr.Cells["SLTon"].Value.ToString();
            cmbTheLoai.Text = dr.Cells["TenTheLoai"].Value.ToString();
            cmbTacGia.Text = dr.Cells["TenTacGia"].Value.ToString();
            cmbNXB.Text = dr.Cells["TenNXB"].Value.ToString();
            txtNamXB.Text = dr.Cells["NamXB"].Value.ToString();
        }
        //Kiểm tra Mã sách trùng
        public int kiemtra()
        {
            for (int i = 0; i < dgSach.RowCount - 1; i++)
            {
                if (txtMaSach.Text == dgSach.Rows[i].Cells["MaSach"].Value.ToString())
                    return 0;
            }
            return 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtGiaNhap.Text == "" || txtGiaBan.Text == "" || txtSLTon.Text == "" ||
                cmbTheLoai.Text == "" || cmbTacGia.Text == "" || cmbNXB.Text == "" || txtNamXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (kiemtra() == 0)
                    MessageBox.Show("Đã tồn tại Mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Thêm 1 dòng vào bảng tblSach
                    DataRow row = ds.Tables["tblSach"].NewRow();
                    row["MaSach"] = txtMaSach.Text;
                    row["TenSach"] = txtTenSach.Text;
                    row["GiaNhap"] = txtGiaNhap.Text;
                    row["GiaBan"] = txtGiaBan.Text;
                    row["SLTon"] = txtSLTon.Text;                   
                    row["TenTheLoai"] = cmbTheLoai.Text;
                    row["MaTheLoai"] = cmbTheLoai.SelectedValue;
                    row["TenTacGia"] = cmbTacGia.Text;
                    row["MaTacGia"] = cmbTacGia.SelectedValue;
                    row["TenNXB"] = cmbNXB.Text;
                    row["MaNXB"] = cmbNXB.SelectedValue;
                    row["NamXB"] = txtNamXB.Text;
                    ds.Tables["tblSach"].Rows.Add(row);  //Đưa các dòng này vào table tblSach
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text == "" || txtGiaNhap.Text == "" || txtGiaBan.Text == "" || txtSLTon.Text == "" ||
                cmbTheLoai.Text == "" || cmbTacGia.Text == "" || cmbNXB.Text == "" || txtNamXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                    DataGridViewRow dr = dgSach.SelectedRows[0];
                    dgSach.BeginEdit(true);

                    dr.Cells["MaSach"].Value = txtMaSach.Text;
                    dr.Cells["TenSach"].Value = txtTenSach.Text;
                    dr.Cells["GiaNhap"].Value = txtGiaNhap.Text;
                    dr.Cells["GiaBan"].Value = txtGiaBan.Text;
                    dr.Cells["SLTon"].Value = txtSLTon.Text;
                    dr.Cells["TenTheLoai"].Value = cmbTheLoai.Text;
                    dr.Cells["MaTheLoai"].Value = cmbTheLoai.SelectedValue;
                    dr.Cells["TenTacGia"].Value = cmbTacGia.Text;
                    dr.Cells["MaTacGia"].Value = cmbTacGia.SelectedValue;
                    dr.Cells["TenNXB"].Value = cmbNXB.Text;
                    dr.Cells["MaNXB"].Value = cmbNXB.SelectedValue;
                    dr.Cells["NamXB"].Value = txtNamXB.Text;

                    dgSach.EndEdit();
                    MessageBox.Show("Đã cập nhật vào Thông tin Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgSach.SelectedRows.Count > 0) //Lệnh đếm, dòng đã được chọn
            {
                dgSach.Rows.Remove(dgSach.SelectedRows[0]);
                txtMaSach.Clear();
                txtTenSach.Clear();
                txtGiaNhap.Clear();
                txtGiaBan.Clear();
                txtSLTon.Clear();
                cmbTheLoai.ResetText();
                cmbTacGia.ResetText();
                cmbNXB.ResetText();
                txtNamXB.Clear();

                txtMaSach.Focus();
            }    
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.daSach.Update(ds, "tblSach");
                 dgSach.Refresh();
            MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn hủy các thao tác vừa rồi không?", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Question);
            {
                ds.Tables["tblSach"].RejectChanges(); //Hủy các thao tác trước khi lưu
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            double gianhap, giaban;
            if(txtGiaNhap.Text == "")
            {
                gianhap = 0;
            }
            else
            {
                gianhap = Convert.ToDouble(txtGiaNhap.Text);
            }
            giaban = gianhap + (gianhap * 0.1);
            txtGiaBan.Text = giaban.ToString();
        }
    }
}
