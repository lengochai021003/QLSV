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
    public partial class frClasses : Form
    {
        DBAccess db=new DBAccess();
        public frClasses()
        {
            InitializeComponent();
            loadds();
        }
           
        public void loadds(){
            DataTable dt = new DataTable();
            dt = db.DSClasses();
            dataGridView1.DataSource = dt;
            loadCombo();
            reset();
        }
        public void reset()
        {
            txtmalop.Text = "";
            txttenlop.Text = "";
            commahocky.SelectedValue = 1;
            commamon.SelectedValue = 1;

        }
        public void loadCombo()
        {
            DataTable dt1 = db.DSCourses();
            commamon.DataSource = dt1;
            dt1.Columns.Add("DisplayText", typeof(string), "CourseName + ' - ' + CourseCode");
            commamon.DisplayMember = "DisplayText";
            commamon.ValueMember = "CourseID";
            commahocky.DataSource = db.DSSemester();
            commahocky.DisplayMember = "SemesterName";
            commahocky.ValueMember = "SemesterID";
        }
        public bool kiemtradauvao()
        {
            if (String.IsNullOrWhiteSpace(txttenlop.Text))
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
                    db.AddClasses(int.Parse(commamon.SelectedValue.ToString()), commahocky.SelectedValue.ToString(), txttenlop.Text);
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
            txtmalop.Text = row.Cells["ClassID"].Value.ToString();
            commamon.SelectedValue = row.Cells["CourseID"].Value;
            commahocky.SelectedValue = row.Cells["SemesterID"].Value;
            txttenlop.Text = row.Cells["ClassName"].Value.ToString();
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
                    db.UpdateClass(commamon.SelectedValue.ToString(), commahocky.SelectedValue.ToString(), txttenlop.Text,txtmalop.Text);
                    loadds();
                    MessageBox.Show("Sửa thành công");
                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show(sqlEx.Message);

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
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.DeleteClass(txtmalop.Text);
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

        private void frClasses_Load(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
