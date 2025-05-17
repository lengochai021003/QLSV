using System;
using System.Data;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frSinhVienTruotMon : Form
    {
        DBAccess db = new DBAccess();

        public frSinhVienTruotMon()
        {
            InitializeComponent();
            sl.Text = "";
            combo2.Enabled = false;
        }

        public void LoadCombo2(DataTable dt,string name,string value)
        {
          
            combo2.DataSource = dt;
            combo2.DisplayMember = name;
            combo2.ValueMember = value;     
        }
        public void reset()
        {
            combo2.DataSource = null;
            combo2.Items.Clear();
            combo2.Enabled=false;
        }

        public void comCateCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            int choice = comCateCourse.SelectedIndex;
            switch (choice)
            {
                case 0:
                    reset();
                    UpdateDataSource(db.DSSinhVienTruotSBV());
                    break;
                case 1:
                    reset();
                    UpdateDataSource(db.DSSinhVienTruotDoSoDiem());
                    break;
                case 2:
                    combo2.Enabled=true;
                    LoadCombo2(db.DSSemester(),"SemesterName","SemesterID");
                    UpdateSemesterData();
                    break;
                case 3:
                    combo2.Enabled = true;
                    LoadCombo2(db.DSMajors(), "MajorName", "MajorID");
                    UpdateMajorData();
                    break;
                case 4:
                    combo2.Enabled = true;
                    LoadCombo2(db.DSClasses(), "ClassName", "ClassID");
                    UpdateClassData();
                    break;
            }
        }
        public void UpdateSemesterData()
        {
            if (combo2.Items.Count > 0)
            {
                if (combo2.SelectedValue is int semesterId)
                {
                    UpdateDataSource(db.DSSinhVienTruotTheoKy(semesterId));
                }
            }
        }
        public void UpdateMajorData()
        {
            if (combo2.Items.Count > 0)
            {
                if (combo2.SelectedValue is int MajorId)
                {
                    UpdateDataSource(db.DSSinhVienTruotTheoNganh(MajorId));
                }
            }
        }
        public void UpdateClassData()
        {
            if (combo2.Items.Count > 0)
            {
                if (combo2.SelectedValue is int ClassId)
                {
                    UpdateDataSource(db.DSSinhVienTruotTheoClass(ClassId));
                }
            }
        }


        public void UpdateDataSource(DataTable data)
        {
            dgv.DataSource = data;
            sl.Text = dgv.RowCount.ToString();
        }

        private void combo2_SelectedValueChanged(object sender, EventArgs e)
        {
            int choice = comCateCourse.SelectedIndex;
            switch (choice)
            {    
                case 2:
                    UpdateSemesterData();
                    break;
                case 3:
                    UpdateMajorData();
                    break;
                case 4:
                    UpdateClassData();
                    break;
            }
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}