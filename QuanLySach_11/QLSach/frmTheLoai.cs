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
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        //Khởi tại đối tượng DataSet 
        DataSet ds = new DataSet();
        SqlDataAdapter daTheLoai;

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=LAPTOP-3SIUQHOQ\SQL;Initial Catalog=QLSach;Integrated Security=True";

            //Dữ liệu Datagridview NXB
            string sQueryTheLoai = @"select * from TheLoai";  //Câu lệnh truy vấn để đưa vào DataAdapter
            daTheLoai = new SqlDataAdapter(sQueryTheLoai, conn);  //Tạo 1 đối tượng SqlDataAdapter tên daNXB
            daTheLoai.Fill(ds, "tblTheLoai");
            dgTheLoai.DataSource = ds.Tables["tblTheLoai"];

            //// … đặt tiêu đề tiếng Việt, định độ rộng cho các trường 
            dgTheLoai.Columns["MaTheLoai"].HeaderText = "Mã thể loại";
            dgTheLoai.Columns["MaTheLoai"].Width = 300;
            dgTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
            dgTheLoai.Columns["TenTheLoai"].Width = 700;

            //Tô màu xen kẽ cho Datagridview 
            dgTheLoai.RowsDefaultCellStyle.BackColor = Color.White;
            dgTheLoai.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;


            //Command Thêm Thể loại
            string sThemTheLoai = @"insert into TheLoai values(@MaTheLoai, @TenTheLoai)";
            SqlCommand cmThemTheLoai = new SqlCommand(sThemTheLoai, conn);
            cmThemTheLoai.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar, 10, "MaTheLoai");
            cmThemTheLoai.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar, 50, "TenTheLoai");

            daTheLoai.InsertCommand = cmThemTheLoai;

            //Command Sửa Thể loại
            string sSuaTheLoai = @"update TheLoai set TenTheLoai=@TenTheLoai where MaTheLoai=@MaTheLoai";
            SqlCommand cmSuaTheLoai = new SqlCommand(sSuaTheLoai, conn);
            cmSuaTheLoai.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar, 10, "MaTheLoai");
            cmSuaTheLoai.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar, 50, "TenTheLoai");

            daTheLoai.UpdateCommand = cmSuaTheLoai;

            //Command Xóa Thể loại
            string sXoaTheLoai = @"delete from TheLoai where MaTheLoai = @MaTheLoai";
            SqlCommand cmXoaTheLoai = new SqlCommand(sXoaTheLoai, conn);
            cmXoaTheLoai.Parameters.Add("@MaTheLoai", SqlDbType.NVarChar, 10, "MaTheLoai");

            daTheLoai.DeleteCommand = cmXoaTheLoai;
        }

        private void dgTheLoai_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgTheLoai.SelectedRows[0];
            txtMaTheLoai.Text = dr.Cells["MaTheLoai"].Value.ToString();
            txtTenTheLoai.Text = dr.Cells["TenTheLoai"].Value.ToString();
        }

        private void dgTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khi chọn 1 dòng trên DataGridView thông tin sẽ hiển thị lên các control tương ứng trên Form
            DataGridViewRow dr = dgTheLoai.SelectedRows[0];
            txtMaTheLoai.Text = dr.Cells["MaTheLoai"].Value.ToString();
            txtTenTheLoai.Text = dr.Cells["TenTheLoai"].Value.ToString();
        }

        //Kiểm tra Mã NXB trùng
        public int kiemtra()
        {
            for (int i = 0; i < dgTheLoai.RowCount - 1; i++)
            {
                if (txtMaTheLoai.Text == dgTheLoai.Rows[i].Cells["MaTheLoai"].Value.ToString())
                    return 0;
            }
            return 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTheLoai.Text == "" || txtTenTheLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (kiemtra() == 0)
                    MessageBox.Show("Đã tồn tại Mã thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Thêm 1 dòng vào bảng tblSach
                    DataRow row = ds.Tables["tblTheLoai"].NewRow();
                    row["MaTheLoai"] = txtMaTheLoai.Text;
                    row["TenTheLoai"] = txtTenTheLoai.Text;

                    ds.Tables["tblTheLoai"].Rows.Add(row);  //Đưa các dòng này vào table tblTheLoai
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenTheLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Thêm 1 dòng vào bảng tblSach
                DataGridViewRow dr = dgTheLoai.SelectedRows[0];
                dgTheLoai.BeginEdit(true);

                dr.Cells["MaTheLoai"].Value = txtMaTheLoai.Text;
                dr.Cells["TenTheLoai"].Value = txtTenTheLoai.Text;

                dgTheLoai.EndEdit();
                MessageBox.Show("Đã cập nhật vào Thông tin Thể loại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgTheLoai.SelectedRows.Count > 0) //Lệnh đếm, dòng đã được chọn
            {
                dgTheLoai.Rows.Remove(dgTheLoai.SelectedRows[0]);
                txtMaTheLoai.Clear();
                txtTenTheLoai.Clear();

                txtMaTheLoai.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.daTheLoai.Update(ds, "tblTheLoai");
            dgTheLoai.Refresh();
            MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn hủy các thao tác vừa rồi không?", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Question);
            {
                ds.Tables["tbTheLoai"].RejectChanges(); //Hủy các thao tác trước khi lưu
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
