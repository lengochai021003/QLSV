using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frMenu : Form
    {
        public frMenu()
        {
            InitializeComponent();
        }

        private void quanLySinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frSinhVien f=new frSinhVien();
            f.ShowDialog();
        }

        private void nganhHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frNganhHoc f=new frNganhHoc();
            f.ShowDialog();
        }

      

        private void danhMucMônHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDanhMucMonHoc fr= new frDanhMucMonHoc();
            fr.ShowDialog();
        }

        private void mônHocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frMonHoc fr= new frMonHoc();
            fr.ShowDialog();
        }

        private void đâuĐiêmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frDauDiem fr= new frDauDiem();
            fr.ShowDialog();
        }

        private void điêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDiem fr= new frDiem();
            fr.ShowDialog();
        }

        private void lơpHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frClasses fr= new frClasses();
            fr.ShowDialog();
        }

        private void ghiDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGhiDanh fr= new frGhiDanh();
            fr.ShowDialog();
        }

        private void hocKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frHocKy fr= new frHocKy();
            fr.ShowDialog();
        }

        private void thongKeTheoSinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThongKeSinhVien fr=new frThongKeSinhVien();
            fr.ShowDialog();
        }

        private void thongKeNghanhHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThongKeNganhHoc fr=new frThongKeNganhHoc();
            fr.ShowDialog();
        }

        private void danhSachLopHocTheoKiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThongKeClassTheoKy fr=new frThongKeClassTheoKy();
            fr.ShowDialog();
        }

        private void thongKeSinhVienTruotMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frSinhVienTruotMon fr=new frSinhVienTruotMon();
            fr.ShowDialog();
        }

        private void danhSachMônHocTheoMucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThongKeCacMonHoc fr =new frThongKeCacMonHoc();
            fr.ShowDialog();
        }
    }
}
