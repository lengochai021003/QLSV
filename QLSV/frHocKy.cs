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
using static System.Net.Mime.MediaTypeNames;

namespace QLSV
{
    public partial class frHocKy : Form
    {
        DBAccess db=new DBAccess();
        public frHocKy()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            dataGridView1.DataSource = db.DSSemester();
            reset();
        }
        public void reset()
        {
            txtmahocky.Text = "";
            txtnam.Text = "";
            txttenhocky.Text = "";


        }
        public bool kiemtradauvao()
        {
            if (String.IsNullOrWhiteSpace(txttenhocky.Text)||
                String.IsNullOrWhiteSpace(txtnam.Text))
            {
                return true;
            }
            else return false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                try
                {
                    if (!int.TryParse(txtnam.Text, out int nam))
                    {
                        MessageBox.Show("Vui lòng nhập một năm hợp lệ (số nguyên).");
                        return;
                    }
                    db.AddSemester(txttenhocky.Text,nam);
                    loadds();
                    MessageBox.Show("Thêm thành công");
                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show(sqlEx.Message);

                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtmahocky.Text = row.Cells[0].Value.ToString();
            txttenhocky.Text = row.Cells[1].Value.ToString();
            txtnam.Text = row.Cells[2].Value.ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                try
                {
                    if (!int.TryParse(txtnam.Text, out int nam))
                    {

                        MessageBox.Show("Vui lòng nhập một năm hợp lệ (số nguyên).");
                        return;
                    }
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.DeleteSemesters(txtmahocky.Text);
                        loadds();
                        MessageBox.Show("Xóa thành công");
                    }
                    
                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show(sqlEx.Message);

                }

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                try
                {
                    if (!int.TryParse(txtnam.Text, out int nam))
                    {
                        MessageBox.Show("Vui lòng nhập một năm hợp lệ (số nguyên).");
                        return;
                    }
                    db.UpdateSemester(txttenhocky.Text,txtnam.Text,txtmahocky.Text);
                    loadds();
                    MessageBox.Show("Sửa thành công");
                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show(sqlEx.Message);

                }

            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
