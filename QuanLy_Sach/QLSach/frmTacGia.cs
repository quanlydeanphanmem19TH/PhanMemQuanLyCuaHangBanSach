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
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        //Khởi tại đối tượng DataSet 
        DataSet ds = new DataSet();
        SqlDataAdapter daTacGia;

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=LAPTOP-3SIUQHOQ\SQL;Initial Catalog=QLSach;Integrated Security=True";

            //Dữ liệu Datagridview NXB
            string sQueryTacGia = @"select * from TacGia";  //Câu lệnh truy vấn để đưa vào DataAdapter
            daTacGia = new SqlDataAdapter(sQueryTacGia, conn);  //Tạo 1 đối tượng SqlDataAdapter tên daTacGia
            daTacGia.Fill(ds, "tblTacGia");
            dgTacGia.DataSource = ds.Tables["tblTacGia"];

            //// … đặt tiêu đề tiếng Việt, định độ rộng cho các trường 
            dgTacGia.Columns["MaTacGia"].HeaderText = "Mã tác giả";
            dgTacGia.Columns["MaTacGia"].Width = 90;
            dgTacGia.Columns["TenTacGia"].HeaderText = "Tên tác giả";
            dgTacGia.Columns["TenTacGia"].Width = 200;
            dgTacGia.Columns["SDT"].HeaderText = "SĐT";
            dgTacGia.Columns["SDT"].Width = 150;
            dgTacGia.Columns["Email"].HeaderText = "E-mail";
            dgTacGia.Columns["Email"].Width = 200;
            dgTacGia.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgTacGia.Columns["DiaChi"].Width = 200;

            //Tô màu xen kẽ cho Datagridview 
            dgTacGia.RowsDefaultCellStyle.BackColor = Color.White;
            dgTacGia.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            //Command Thêm Tác giả
            string sThemTacGia = @"insert into TACGIA values(@MaTacGia, @TenTacGia, @SDT, @Email, @DiaChi)";
            SqlCommand cmThemTacGia = new SqlCommand(sThemTacGia, conn);
            cmThemTacGia.Parameters.Add("@MaTacGia", SqlDbType.NVarChar, 10, "MaTacGia");
            cmThemTacGia.Parameters.Add("@TenTacGia", SqlDbType.NVarChar, 50, "TenTacGia");
            cmThemTacGia.Parameters.Add("@SDT", SqlDbType.Int, 50, "SDT");
            cmThemTacGia.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmThemTacGia.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");

            daTacGia.InsertCommand = cmThemTacGia;

            //Command Sửa Tác giả
            string sSuaTacGia = @"update TACGIA set TenTacGia=@TenTacGia, SDT=@SDT, Email=@Email, DiaChi=@DiaChi where MaTacGia=@MaTacGia";
            SqlCommand cmSuaTacGia = new SqlCommand(sSuaTacGia, conn);
            cmSuaTacGia.Parameters.Add("@MaTacGia", SqlDbType.NVarChar, 10, "MaTacGia");
            cmSuaTacGia.Parameters.Add("@TenTacGia", SqlDbType.NVarChar, 50, "TenTacGia");
            cmSuaTacGia.Parameters.Add("@SDT", SqlDbType.Int, 50, "SDT");
            cmSuaTacGia.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmSuaTacGia.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");

            daTacGia.UpdateCommand = cmSuaTacGia;

            //Command Xóa Tác giả
            string sXoaTacGia = @"delete from TACGIA where MaTacGia = @MaTacGia";
            SqlCommand cmXoaTacGia = new SqlCommand(sXoaTacGia, conn);
            cmXoaTacGia.Parameters.Add("@MaTacGia", SqlDbType.NVarChar, 5, "MaTacGia");

            daTacGia.DeleteCommand = cmXoaTacGia;
        }

        private void dgTacGia_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgTacGia.SelectedRows[0];
            txtMaTacGia.Text = dr.Cells["MaTacGia"].Value.ToString();
            txtTenTacGia.Text = dr.Cells["TenTacGia"].Value.ToString();
            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
        }
        /*private void dgTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khi chọn 1 dòng trên DataGridView thông tin sẽ hiển thị lên các control tương ứng trên Form
            DataGridViewRow dr = dgTacGia.SelectedRows[0];
            txtMaTacGia.Text = dr.Cells["MaTacGia"].Value.ToString();
            txtTenTacGia.Text = dr.Cells["TenTacGia"].Value.ToString();
            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
        }*/
        public int kiemtra()
        {
            for (int i = 0; i < dgTacGia.RowCount - 1; i++)
            {
                if (txtMaTacGia.Text == dgTacGia.Rows[i].Cells["MaTacGia"].Value.ToString())
                    return 0;
            }
            return 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTacGia.Text == "" || txtTenTacGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (kiemtra() == 0)
                    MessageBox.Show("Đã tồn tại Mã tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Thêm 1 dòng vào bảng tblSach
                    DataRow row = ds.Tables["tblTacGia"].NewRow();
                    row["MaTacGia"] = txtMaTacGia.Text;
                    row["TenTacGia"] = txtTenTacGia.Text;
                    row["SDT"] = txtSDT.Text;
                    row["Email"] = txtEmail.Text;
                    row["DiaChi"] = txtDiaChi.Text;

                    ds.Tables["tblTacGia"].Rows.Add(row);  //Đưa các dòng này vào table tblTacGia
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenTacGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Thêm 1 dòng vào bảng tblSach
                DataGridViewRow dr = dgTacGia.SelectedRows[0];
                dgTacGia.BeginEdit(true);

                dr.Cells["MaTacGia"].Value = txtMaTacGia.Text;
                dr.Cells["TenTacGia"].Value = txtTenTacGia.Text;
                dr.Cells["SDT"].Value = txtSDT.Text;
                dr.Cells["Email"].Value = txtEmail.Text;
                dr.Cells["DiaChi"].Value = txtDiaChi.Text;

                dgTacGia.EndEdit();
                MessageBox.Show("Đã cập nhật vào Thông tin Thể loại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgTacGia.SelectedRows.Count > 0) //Lệnh đếm, dòng đã được chọn
            {
                dgTacGia.Rows.Remove(dgTacGia.SelectedRows[0]);
                txtMaTacGia.Clear();
                txtTenTacGia.Clear();

                txtMaTacGia.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.daTacGia.Update(ds, "tblTacGia");
            dgTacGia.Refresh();
            MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn hủy các thao tác vừa rồi không?", "Xác nhận",
                 MessageBoxButtons.OK, MessageBoxIcon.Question);
            {
                ds.Tables["tbTacGia"].RejectChanges(); //Hủy các thao tác trước khi lưu
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
