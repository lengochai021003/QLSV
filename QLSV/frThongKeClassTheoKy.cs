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
    public partial class frThongKeClassTheoKy : Form
    {
        DBAccess db = new DBAccess();
        private bool isFormLoaded = false;
        public frThongKeClassTheoKy()
        {
            InitializeComponent();
            loadds();
            isFormLoaded = true;
        }
        public void loadds()
        {
            sl.Text = "";
            comSemester.DataSource = db.DSSemester();
            comSemester.DisplayMember = "SemesterName";
            comSemester.ValueMember = "SemesterID";
        }

        private void comSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isFormLoaded) // Show the message only if the form has finished loading
            {
                dgv.DataSource = db.DSClassesTheoKy(comSemester.SelectedValue.ToString());
                sl.Text = dgv.RowCount.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
