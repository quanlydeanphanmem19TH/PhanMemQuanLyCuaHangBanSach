using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmQLThongTinSach());
            //Application.Run(new frmNXB());
            //Application.Run(new frmTheLoai());
            //Application.Run(new frmTacGia());
            //Application.Run(new frmDangNhap());
            //Application.Run(new frmBanHang());
            Application.Run(new frmGiaoDien());
        }
    }
}
