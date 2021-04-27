using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class frmTongQuan : Form
    {
        public frmTongQuan()
        {
            InitializeComponent();
        }

        private void quảnLýThôngTinSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLThongTinSach sach = new frmQLThongTinSach();
            this.Hide();    //Ẩn form, các thuộc tính của nó vẫn tồn tại trong bộ nhớ
            sach.ShowDialog(); 
            this.Show();   //Để trở lại Form Tổng quan
        }
        private void quanLyTheLoaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheLoai theloai = new frmTheLoai();
            this.Hide();    //Ẩn form, các thuộc tính của nó vẫn tồn tại trong bộ nhớ
            theloai.ShowDialog();
            this.Show();  //Để trở lại Form Tổng quan
        }

        private void quảnLýTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTacGia tacgia = new frmTacGia();
            this.Hide();    //Ẩn form, các thuộc tính của nó vẫn tồn tại trong bộ nhớ
            tacgia.ShowDialog();
            this.Show();  //Để trở lại Form Tổng quan
        }

        private void quanLyNXBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNXB nxb = new frmNXB();
            this.Hide();    //Ẩn form, các thuộc tính của nó vẫn tồn tại trong bộ nhớ
            nxb.ShowDialog();
            this.Show();  //Để trở lại Form Tổng quan
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanHang banhang = new frmBanHang();
            this.Hide();   //Ẩn form, các thuộc tính của nó vẫn tồn tại trong bộ nhớ
            banhang.ShowDialog();
            this.Show();  //Để trở lại Form Tổng quan
        }

        private void dangXuatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Đăng xuất khỏi hệ thống không?", "Thông báo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                frmGiaoDien giaodien = new frmGiaoDien();
                this.Hide();
                giaodien.ShowDialog();
                this.Show();
            }
        }
    }
}
