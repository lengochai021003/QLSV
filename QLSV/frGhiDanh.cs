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
    public partial class frGhiDanh : Form
    {
        DBAccess db = new DBAccess();
        public frGhiDanh()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            DataTable dt = new DataTable();
            dt = db.DSEnrollments();
            dgv.DataSource = dt;
            cbclassid.DataSource = db.DSClasses();
            cbclassid.DisplayMember = "CLassName";
            cbclassid.ValueMember = "ClassID";
            cbclassid.SelectedIndex = 0;

            reset();
                      
        }

  
        bool kiemtradauvao()
        {
            if (string.IsNullOrWhiteSpace(txtExNo.Text) ||
                   string.IsNullOrWhiteSpace(txtIDS.Text) ||
                   string.IsNullOrWhiteSpace(point.Text) ||
                   string.IsNullOrWhiteSpace(txtsbvang.Text)
                )

                return true;
            return false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                string studentCode = txtIDS.Text.Trim(); // Assuming you have a TextBox named txtStudentCode
                string studentID;
                DataTable dt = db.getIDFromCode(studentCode);
                if (dt.Rows.Count > 0)
                {
                    studentID = dt.Rows[0]["StudentID"].ToString();
                }
                else
                {
                    MessageBox.Show("Khong tim thay sinh vien");
                    return;
                }
                try
                {

                    float diemSo;
                    int sbv, bkts;

                    bool isDiemSoValid = float.TryParse(point.Text, out diemSo);
                    bool isSbvValid = int.TryParse(txtsbvang.Text, out sbv);
                    bool isBktsValid = int.TryParse(txtExNo.Text, out bkts);

                    if (isDiemSoValid && isSbvValid && isBktsValid)
                    {
                        db.AddEnrollment(int.Parse(studentID), int.Parse(cbclassid.SelectedValue.ToString()), sbv, bkts, ngay.Value, diemSo);
                        loadds();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("ID không tồn tại");

                    }
                    else
                    {
                        MessageBox.Show(sqlEx.ToString());

                    }

                }


            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex; 
            txtID.Text = dgv.Rows[i].Cells[0].Value.ToString();
            string className = dgv.Rows[i].Cells[1].Value.ToString();
            cbclassid.SelectedValue = db.GetIdFromClassName(className);
            txtIDS.Text = dgv.Rows[i].Cells[2].Value.ToString();
            txtsbvang.Text = dgv.Rows[i].Cells[3].Value.ToString();
            txtExNo.Text = dgv.Rows[i].Cells[4].Value.ToString();
            ngay.Value = DateTime.Parse(dgv.Rows[i].Cells[5].Value.ToString());
            point.Text = dgv.Rows[i].Cells[6].Value.ToString();
        }

        private void btnUDate_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                string studentCode = txtIDS.Text.Trim(); // Assuming you have a TextBox named txtStudentCode
                string studentID;
                DataTable dt = db.getIDFromCode(studentCode);
                if (dt.Rows.Count > 0)
                {
                    studentID = dt.Rows[0]["StudentID"].ToString();
                }
                else
                {
                    MessageBox.Show("Khong tim thay sinh vien");
                    return;
                }
                try
                {

                    float diemSo;
                    int sbv, bkts,id;

                    bool isDiemSoValid = float.TryParse(point.Text, out diemSo);
                    bool isSbvValid = int.TryParse(txtsbvang.Text, out sbv);
                    bool isBktsValid = int.TryParse(txtExNo.Text, out bkts);
                    bool isIdValid = int.TryParse(txtID.Text, out id);

                    if (isDiemSoValid && isSbvValid && isBktsValid)
                    {
                        db.UpdateEnrollment(id,int.Parse(studentID), int.Parse(cbclassid.SelectedValue.ToString()), sbv, bkts, ngay.Value, diemSo);
                        loadds();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("ID không tồn tại");

                    }
                    else
                    {
                        MessageBox.Show(sqlEx.ToString());

                    }

                }


            }
        }
        public void reset()
        {
            txtExNo.Text = "";
            txtID.Text = "";
            txtIDS.Text = "";
            txtsbvang.Text = "";
            ngay.Value=DateTime.Now;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                try
                {
                    int id;
                    bool isIdValid = int.TryParse(txtID.Text, out id);

                    if (isIdValid)
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            db.DeleteEnrollment(id);
                            loadds();
                            MessageBox.Show("Xóa thành công");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại.");
                    }
                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show(sqlEx.Message);

                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbclassid_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbclassid.SelectedValue != null)
            {
                int classID;
                if (int.TryParse(cbclassid.SelectedValue.ToString(), out classID))
                {
                    dgv.DataSource = db.DSEnrollmentsTheoID(classID);
                }

            }
            else
            {
                dgv.DataSource = null;
            }
            reset();
        }
    }
}
