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
    public partial class frDanhMucMonHoc : Form
    {
        DBAccess db= new DBAccess();
        public frDanhMucMonHoc()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            DataTable dt = new DataTable();
            dt = db.DSCourseCategories();
            dtgvDMMH.DataSource = dt;
            reset();
        }
        public void reset()
        {
            txtma.Text = "";
            txttendanhmuc.Text = "";
         

        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txttendanhmuc.Text.Length == 0) {
                MessageBox.Show("Không được để trống tên danh mục");
            }
            else
            {
                db.InsertCourseCategory(txttendanhmuc.Text);
                loadds();
                MessageBox.Show("Thêm tên danh mục thành công");

            }
        }

        private void dtgvDMMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvDMMH.CurrentCell.RowIndex;
            txtma.Text = dtgvDMMH.Rows[i].Cells[0].Value.ToString();
            txttendanhmuc.Text = dtgvDMMH.Rows[i].Cells[1].Value.ToString();

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttendanhmuc.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống tên danh mục");
            }
            else
            {
                db.UpdateCourseCategory(txttendanhmuc.Text,txtma.Text);
                loadds();
                MessageBox.Show("Sửa tên danh mục thành công");

            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txttendanhmuc.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống tên danh mục");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.DeleteCourseCategory(txtma.Text);
                    loadds();
                    MessageBox.Show("Xóa tên danh mục thành công");
                }
               

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
