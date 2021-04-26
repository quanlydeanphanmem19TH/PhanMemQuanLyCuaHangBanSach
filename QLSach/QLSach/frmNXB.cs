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
    public partial class frmNXB : Form
    {
        public frmNXB()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        //Khởi tại đối tượng DataSet 
        DataSet ds = new DataSet("dsNXB");
        SqlDataAdapter daNXB;

        private void frmNXB_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=LAPTOP-3SIUQHOQ\SQL;Initial Catalog=QLSach;Integrated Security=True";

            //Dữ liệu Datagridview NXB
            string sQueryNXB = @"select n.* from NXB n";  //Câu lệnh truy vấn để đưa vào DataAdapter
            daNXB = new SqlDataAdapter(sQueryNXB, conn);  //Tạo 1 đối tượng SqlDataAdapter tên daNXB
            daNXB.Fill(ds, "tblNXB");
            dgNXB.DataSource = ds.Tables["tblNXB"];

            //// … đặt tiêu đề tiếng Việt, định độ rộng cho các trường 
            dgNXB.Columns["MaNXB"].HeaderText = "Mã NXB";
            dgNXB.Columns["MaNXB"].Width = 120;
            dgNXB.Columns["TenNXB"].HeaderText = "Tên NXB";
            dgNXB.Columns["TenNXB"].Width = 200;
            dgNXB.Columns["SDT"].HeaderText = "SĐT";
            dgNXB.Columns["SDT"].Width = 150;
            dgNXB.Columns["Email"].HeaderText = "E-mail";
            dgNXB.Columns["Email"].Width = 280;
            dgNXB.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgNXB.Columns["DiaChi"].Width = 250;

            //Tô màu xen kẽ cho Datagridview 
            dgNXB.RowsDefaultCellStyle.BackColor = Color.White;
            dgNXB.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            //Command Thêm NXB
            string sThemNXB = @"insert into NXB values(@MaNXB, @TenNXB, @SDT, @Email, @DiaChi)";
            SqlCommand cmThemNXB = new SqlCommand(sThemNXB, conn);
            cmThemNXB.Parameters.Add("@MaNXB", SqlDbType.NVarChar, 10, "MaNXB");
            cmThemNXB.Parameters.Add("@TenNXB", SqlDbType.NVarChar, 50, "TenNXB");
            cmThemNXB.Parameters.Add("@SDT", SqlDbType.Int, 10, "SDT");
            cmThemNXB.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmThemNXB.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");

            daNXB.InsertCommand = cmThemNXB;

            //Command Sửa NXB
            string sSuaNXB = @"update NXB set TenNXB=@TenNXB, SDT=@SDT, Email=@Email, DiaChi=@DiaChi where MaNXB=@MaNXB";
            SqlCommand cmSuaNXB = new SqlCommand(sSuaNXB, conn);
            cmSuaNXB.Parameters.Add("@MaNXB", SqlDbType.NVarChar, 10, "MaNXB");
            cmSuaNXB.Parameters.Add("@TenNXB", SqlDbType.NVarChar, 50, "TenNXB");
            cmSuaNXB.Parameters.Add("@SDT", SqlDbType.Int, 10, "SDT");
            cmSuaNXB.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmSuaNXB.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");

            daNXB.UpdateCommand = cmSuaNXB;

            //Command Xóa NXB
            string sXoaNXB = @"delete from NXB where MaNXB = @MaNXB";
            SqlCommand cmXoaNXB = new SqlCommand(sXoaNXB, conn);
            cmXoaNXB.Parameters.Add("@MaNXB", SqlDbType.NVarChar, 5, "MaNXB");

            daNXB.DeleteCommand = cmXoaNXB;

        } 

        private void dgNXB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgNXB_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgNXB.SelectedRows[0];
            txtMaNXB.Text = dr.Cells["MaNXB"].Value.ToString();
            txtTenNXB.Text = dr.Cells["TenNXB"].Value.ToString();
            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
        }

        private void dgNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khi chọn 1 dòng trên DataGridView thông tin sẽ hiển thị lên các control tương ứng trên Form
            DataGridViewRow dr = dgNXB.SelectedRows[0];
            txtMaNXB.Text = dr.Cells["MaNXB"].Value.ToString();
            txtTenNXB.Text = dr.Cells["TenNXB"].Value.ToString();
            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
        }

        //Kiểm tra Mã NXB trùng
        public int kiemtra()
        {
            for (int i = 0; i < dgNXB.RowCount - 1; i++)
            {
                if (txtMaNXB.Text == dgNXB.Rows[i].Cells["MaNXB"].Value.ToString())
                    return 0;
            }
            return 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "" || txtTenNXB.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (kiemtra() == 0)
                    MessageBox.Show("Đã tồn tại Mã NXB!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Thêm 1 dòng vào bảng tblSach
                    DataRow row = ds.Tables["tblNXB"].NewRow();
                    row["MaNXB"] = txtMaNXB.Text;
                    row["TenNXB"] = txtTenNXB.Text;
                    row["SDT"] = txtSDT.Text;
                    row["Email"] = txtEmail.Text;
                    row["DiaChi"] = txtDiaChi.Text;

                    ds.Tables["tblNXB"].Rows.Add(row);  //Đưa các dòng này vào table tblNXB
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                else
                {
                    //Thêm 1 dòng vào bảng tblNXB
                    DataGridViewRow dr = dgNXB.SelectedRows[0];
                    dgNXB.BeginEdit(true);

                    dr.Cells["MaNXB"].Value = txtMaNXB.Text;
                    dr.Cells["TenNXB"].Value = txtTenNXB.Text;
                    dr.Cells["SDT"].Value = txtSDT.Text;
                    dr.Cells["Email"].Value = txtEmail.Text;
                    dr.Cells["DiaChi"].Value = txtDiaChi.Text;

                    dgNXB.EndEdit();
                    MessageBox.Show("Đã cập nhật vào Thông tin NXB!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgNXB.SelectedRows.Count > 0) //Lệnh đếm, dòng đã được chọn
            {
                dgNXB.Rows.Remove(dgNXB.SelectedRows[0]);
                txtMaNXB.Clear();
                txtTenNXB.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtDiaChi.Clear();

                txtMaNXB.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.daNXB.Update(ds, "tblNXB");
            dgNXB.Refresh();
            MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn hủy các thao tác vừa rồi không?", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Question);
            {
                ds.Tables["tbNXB"].RejectChanges(); //Hủy các thao tác trước khi lưu
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
    }
}
