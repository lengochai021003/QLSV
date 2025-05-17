using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frThongKeSinhVien : Form
    {
        DBAccess db= new DBAccess();
        public frThongKeSinhVien()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            
            else
            {
                if (kiemtradauvaotontai())
                {
                    MessageBox.Show("Mã sinh viên không tồn tại");
                    return;
                }
                else
                {
                    if (radioClass.Checked)
                    {

                        DataTable dt = db.ClassFromID(txtTimKiem.Text);
                        dgv.DataSource = dt;
                    }
                    else if (radioCourse.Checked)
                    {

                        DataTable dt = db.CourseFromClassID(txtTimKiem.Text);
                        dgv.DataSource = dt;

                    }
                }


            }
        }
        public bool kiemtradauvaotontai()
        {
            if (db.CountStudentsByID(txtTimKiem.Text) == 0) return true;
            else return false;
        }
        public bool kiemtradauvao()
        {
            if(String.IsNullOrWhiteSpace(txtTimKiem.Text)) return true;
            else return false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
