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
    public partial class frThongKeCacMonHoc : Form
    {
        DBAccess db = new DBAccess();
        private bool isFormLoaded = false;
        public frThongKeCacMonHoc()
        {
            InitializeComponent();
            loadds();
            isFormLoaded = true;
        }
        public void loadds()
        {
            sl.Text = "";
            comCateCourse.DataSource = db.DSCourseCategories();
            comCateCourse.DisplayMember = "CourseCatName";
            comCateCourse.ValueMember = "CourseCatID";
        }

        private void comCateCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoaded) // Show the message only if the form has finished loading
            {
                dgv.DataSource = db.DSCoursesTheoCourseCate(comCateCourse.SelectedValue.ToString());
                sl.Text = dgv.RowCount.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
    
}
