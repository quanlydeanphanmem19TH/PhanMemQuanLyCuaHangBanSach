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
    public partial class frmGioiThieu : Form
    {
        public frmGioiThieu()
        {
            InitializeComponent();
        }

        private void frmGioiThieu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            frmGiaoDien f = new frmGiaoDien();
            f.Show();
            this.Hide();
            
        }

        private void btnTroLai_Click_1(object sender, EventArgs e)
        {
            frmGiaoDien f = new frmGiaoDien();
            f.Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
