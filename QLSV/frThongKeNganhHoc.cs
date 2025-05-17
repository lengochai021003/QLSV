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
    public partial class frThongKeNganhHoc : Form
    {
        DBAccess db= new DBAccess();
        private bool isFormLoaded = false;
        public frThongKeNganhHoc()
        {
            InitializeComponent();
            loadds();
            isFormLoaded = true;
        }
        public void loadds()
        {
            sl.Text = "";
            comMajor.DataSource = db.DSMajors();
            comMajor.DisplayMember = "MajorName";
            comMajor.ValueMember = "MajorID";
        }
        private void comMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (isFormLoaded) // Show the message only if the form has finished loading
            {
                dgv.DataSource=db.DSMajorsTheoID(comMajor.SelectedValue.ToString());
                sl.Text=dgv.RowCount.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
