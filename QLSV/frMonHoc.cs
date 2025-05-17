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
    public partial class frMonHoc : Form
    {
        DBAccess db=new DBAccess();

        public frMonHoc()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            DataTable dt = new DataTable();
            dt = db.DSCourses();
            dtgvMH.DataSource = dt;
            txtphanloai.DataSource = db.DSCourseCategories();
            txtphanloai.DisplayMember = "CourseCatName";
            txtphanloai.ValueMember = "CourseCatID";
            reset();
        }
        public void reset()
        {
            txtbuoivang.Text = "";
            txtma.Text = "";
            txtPass.Text = "";
            txtphanloai.Text = "";
            txtsobuoi.Text = "";
            txtsotinchi.Text = "";
            txtten.Text = "";

        }
        bool kiemtradauvao()
        {
            if (string.IsNullOrWhiteSpace(txtma.Text) ||
                   string.IsNullOrWhiteSpace(txtten.Text) ||
                   string.IsNullOrWhiteSpace(txtsotinchi.Text) ||
                   string.IsNullOrWhiteSpace(txtphanloai.Text) ||
                   string.IsNullOrWhiteSpace(txtbuoivang.Text) ||
                   string.IsNullOrWhiteSpace(txtsobuoi.Text)
                )

                return true;
            return false;
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
                    float point;
                    bool isConverted = float.TryParse(txtPass.Text, out point);

                    db.InsertCourse(txtma.Text, txtten.Text, txtsotinchi.Text, txtphanloai.SelectedValue.ToString(), txtsobuoi.Text, txtbuoivang.Text,point);
                    loadds();
                    MessageBox.Show("Thêm thành công");
                }
                catch(SqlException sqlEx)
                {
                    if(sqlEx.Number == 2627)
                    {
                        MessageBox.Show("Mã môn học đã tồn tại");

                    }
                    else
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                }

            }
        }

        private void dtgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvMH.CurrentCell.RowIndex;
            txtma.Text = dtgvMH.Rows[i].Cells[1].Value.ToString().Trim();
            txtten.Text = dtgvMH.Rows[i].Cells[2].Value.ToString();
            txtsotinchi.Text = dtgvMH.Rows[i].Cells[3].Value.ToString();
            txtphanloai.SelectedValue = dtgvMH.Rows[i].Cells[4].Value;
            txtsobuoi.Text = dtgvMH.Rows[i].Cells[5].Value.ToString();
            txtbuoivang.Text = dtgvMH.Rows[i].Cells[6].Value.ToString();
            txtPass.Text = dtgvMH.Rows[i].Cells[7].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                float point;
                bool isConverted = float.TryParse(txtPass.Text, out point);

                if (!isConverted)
                {
                    MessageBox.Show("Nhap diem la 1 so thuc.");
                    return;
                }
              
                db.UpdateCourse(txtten.Text, txtsotinchi.Text, txtphanloai.SelectedValue.ToString(), txtsobuoi.Text, txtbuoivang.Text,point , txtma.Text);
                loadds();
                MessageBox.Show("Sửa thành công");

                try
                {
                   
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        MessageBox.Show("Mã môn học đã tồn tại");

                    }
                    else
                    {
                        MessageBox.Show(sqlEx.Message);

                    }
                }


            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.DeleteCourse(txtma.Text);
                    loadds();
                    MessageBox.Show("Xóa thành công");
                }
               

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
