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
    public partial class frNganhHoc : Form
    {
        DBAccess db=new DBAccess();
        public frNganhHoc()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            DataTable dt = new DataTable();
            dt = db.DSMajors();
            dtgvNH.DataSource = dt;
            reset();
        }
        public void reset()
        {
            txtma.Text = "";
            txtten.Text = "";

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtten.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống tên danh mục");
            }
            else
            {
                db.AddMajor(txtten.Text);
                loadds();
                MessageBox.Show("Thêm ngành thành công");

            }
        }

        private void dtgvNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvNH.CurrentCell.RowIndex;
            txtma.Text = dtgvNH.Rows[i].Cells[0].Value.ToString();
            txtten.Text = dtgvNH.Rows[i].Cells[1].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtten.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống tên danh mục");
            }
            else
            {
                db.UpdateMajor( txtma.Text,txtten.Text);
                loadds();
                MessageBox.Show("Sửa tên danh mục thành công");

            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtten.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống tên danh mục");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.DeleteMajor(txtma.Text);
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
