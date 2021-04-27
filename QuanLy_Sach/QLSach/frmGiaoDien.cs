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
    public partial class frmGiaoDien : Form
    {
        public frmGiaoDien()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.ShowDialog();
            this.Hide();
        }

        private void btnGioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieu ff = new frmGioiThieu();
            ff.ShowDialog();
            this.Hide();
            
        }
    }
}
