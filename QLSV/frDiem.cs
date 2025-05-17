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
    public partial class frDiem : Form
    {
        DBAccess db = new DBAccess();
        public frDiem()
        {
            InitializeComponent();
            loadds();
        }
        public void loadds()
        {
            DataTable dt = db.DSDiem();
            dtgvDiem.DataSource = dt;
            comMaLop.DataSource = db.DSClasses();
            comMaLop.DisplayMember = "CLassName";
            comMaLop.ValueMember = "ClassID";
            comMaLop.SelectedIndex = 0;
        }
      
        public void reset()
        {
            txtdiemso.Text = "";
            txtiddiem.Text = "";
            txtmadaudiem.SelectedValue = 1;
            txttmasv.Text = "";
            comMaLop.SelectedValue= 1;
        }
        bool kiemtradauvao()
        {
            if (string.IsNullOrWhiteSpace(txtmadaudiem.Text) ||
                   string.IsNullOrWhiteSpace(txtdiemso.Text) ||
                   string.IsNullOrWhiteSpace(txttmasv.Text) 
                )

                return true;
            return false;
        }
        bool kiemtradiem(float a)
        {
            if(a < 0 || a>10) return true;
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtmadaudiem_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                string studentCode = txttmasv.Text.Trim(); // Assuming you have a TextBox named txtStudentCode
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

                    if (float.TryParse(txtdiemso.Text, out diemSo) && !kiemtradiem(diemSo))
                    {
                        
                        db.AddScores(studentID, comMaLop.SelectedValue.ToString(), txtmadaudiem.SelectedValue.ToString(), diemSo);
                        loadds();
                        reset();

                        MessageBox.Show("Thêm thành công");
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("ID đầu điểm không tồn tại");

                    }
                    else
                    {
                        MessageBox.Show(sqlEx.ToString());

                    }

                }


            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                string studentCode = txttmasv.Text.Trim(); // Assuming you have a TextBox named txtStudentCode
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

                    if (float.TryParse(txtdiemso.Text, out diemSo) && !kiemtradiem(diemSo))
                    {
                        db.UpdateScore(int.Parse(txtiddiem.Text), int.Parse(comMaLop.SelectedValue.ToString()), studentID, txtmadaudiem.SelectedValue.ToString(), diemSo);
                        loadds();
                        reset();

                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng điểm");

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

        private void dtgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvDiem.CurrentCell.RowIndex;

            txtiddiem.Text = dtgvDiem.Rows[i].Cells[0].Value.ToString();
            txttmasv.Text = dtgvDiem.Rows[i].Cells[1].Value.ToString();
            comMaLop.SelectedValue = db.GetIdFromClassName(dtgvDiem.Rows[i].Cells[2].Value.ToString());
            txtmadaudiem.SelectedValue = db.GetIdFromTypeName(dtgvDiem.Rows[i].Cells[3].Value.ToString());
            txtdiemso.Text = dtgvDiem.Rows[i].Cells[4].Value.ToString();
        }

        private void comMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
             int classID;
            if (int.TryParse(comMaLop.SelectedValue.ToString(), out classID))
            {
                
                string CourseID = db.getIDCourseFromClassID(classID.ToString());
                txtmadaudiem.DataSource = db.DSDauDiemTheoMaMon(CourseID);
                txtmadaudiem.DisplayMember = "AssTypeName";
                txtmadaudiem.ValueMember = "AssTypeID";
            }
            dtgvDiem.DataSource = db.DSDiemTheoClass(classID);
            reset();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
