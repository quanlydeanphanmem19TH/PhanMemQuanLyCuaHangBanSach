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
using QLSach;

namespace QLSach
{
    public partial class frmDangNhap : Form
    {

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if ((this.txtUser.Text == "") || (this.txtPass.Text == ""))
                MessageBox.Show("Vui lòng nhập Tên người dùng hoặc Mật khẩu!", "Cảnh báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if ((this.txtUser.Text == "nguyenvana") && (this.txtPass.Text == "123456"))        
             {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                frmTongQuan t = new frmTongQuan();
                t.Show();
                this.Hide(); //Ẩn form, các thuộc tính của nó vẫn tồn tại trong bộ nhớ

            }
            else
            {
                lblKQ.Text = "*Tên đăng nhập hoặc Mật khẩu không đúng, hãy nhập lại!";
                this.txtPass.Clear();
                this.txtUser.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn đóng Hệ thống đăng nhập không?", "Xác nhận",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }
    }
}
