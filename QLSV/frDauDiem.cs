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
    public partial class frDauDiem : Form
    {
        DBAccess db= new DBAccess();
        public frDauDiem()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            DataTable dt = new DataTable();
            dt = db.DSAssessmentTypes();
            dtgvDD.DataSource = dt;
            txtidmon.DataSource = db.DSCourses();
            txtidmon.DisplayMember = "CourseName";
            txtidmon.ValueMember = "CourseID";
            reset();
        }
        public void reset()
        {
            txtma.Text = "";
            txtidmon.SelectedValue = 1;
            txtsobaikt.Text = "";
            txttendaudiem.Text = "";
            txttyle.Text = "";

        }
        bool kiemtradauvao()
        {
            if (
                   string.IsNullOrWhiteSpace(txtidmon.Text) ||
                   string.IsNullOrWhiteSpace(txttendaudiem.Text) ||
                   string.IsNullOrWhiteSpace(txttyle.Text) ||
                   string.IsNullOrWhiteSpace(txtsobaikt.Text)
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
                    float percent;
                    bool isConverted = float.TryParse(txttyle.Text, out percent);
                    if (!isConverted)
                    {
                        MessageBox.Show("Nhap dung kieu ty le");
                    }
                    db.AddAssessmentType(txtidmon.SelectedValue.ToString(), txttendaudiem.Text,percent, txtsobaikt.Text);
                    loadds();
                    MessageBox.Show("Thêm thành công");
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("ID môn học không tồn tại");

                    }

                }


            }
        }

        private void dtgvDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvDD.CurrentCell.RowIndex;
            txtma.Text = dtgvDD.Rows[i].Cells[0].Value.ToString();
            txtidmon.SelectedValue = dtgvDD.Rows[i].Cells[1].Value.ToString();
            txttendaudiem.Text = dtgvDD.Rows[i].Cells[2].Value.ToString();
            txttyle.Text = dtgvDD.Rows[i].Cells[3].Value.ToString();
            txtsobaikt.Text = dtgvDD.Rows[i].Cells[4].Value.ToString();
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

                    db.UpdateAssessmentType(txtma.Text, txtidmon.SelectedValue.ToString(), txttendaudiem.Text, float.Parse(txttyle.Text), txtsobaikt.Text);
                    loadds();
                    MessageBox.Show("Sửa thành công");
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("ID môn học không tồn tại");

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
                try
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.DeleteAssessmentType(txtma.Text, txtidmon.Text);
                        loadds();
                        MessageBox.Show("Xóa thành công");
                    }
                   
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("ID môn học không tồn tại");

                    }

                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
