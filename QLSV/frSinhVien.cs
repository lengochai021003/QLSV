using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLSV
{
    public partial class frSinhVien : Form
    {
        DBAccess db = new DBAccess();
        public frSinhVien()
        {
            InitializeComponent();
            LoadDS();
        }
        public void LoadDS()
        {
            DataTable dt = db.DSSinhVien();
            viewSV.DataSource = dt;
            txtchuyennganh.DataSource = db.DSMajors();
            txtchuyennganh.DisplayMember= "MajorName";
            txtchuyennganh.ValueMember = "MajorID";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {

                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo");
            }
            else
            {
                try
                {
                    db.UpdateSV(txtho.Text, txtTen.Text, txtemail.Text, txtsdt.Text, txtchuyennganh.SelectedValue.ToString(), comgt.Text, txtdiachi.Text, txtcccd.Text, txtkhoahoc.Text, ngaysinh.Value, txtNote.Text, txtma.Text);
                    LoadDS();
                    reset();
                    MessageBox.Show("Sửa thành công", "Thông báo");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi trong quá trình xóa!" + ex, "Thông báo");
                }
            }
        }

        private void viewSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = viewSV.CurrentCell.RowIndex;
            txtho.Text = viewSV.Rows[i].Cells[0].Value.ToString().Trim();
            txtTen.Text = viewSV.Rows[i].Cells[1].Value.ToString().Trim();
            txtma.Text = viewSV.Rows[i].Cells[2].Value.ToString().Trim();
            txtemail.Text = viewSV.Rows[i].Cells[3].Value.ToString().Trim();
            txtsdt.Text = viewSV.Rows[i].Cells[4].Value.ToString().Trim();
            txtchuyennganh.SelectedValue = viewSV.Rows[i].Cells[5].Value;
            comgt.Text = viewSV.Rows[i].Cells[6].Value.ToString().Trim();
            txtdiachi.Text = viewSV.Rows[i].Cells[7].Value.ToString().Trim();
            txtcccd.Text = viewSV.Rows[i].Cells[8].Value.ToString().Trim();
            txtkhoahoc.Text = viewSV.Rows[i].Cells[9].Value.ToString().Trim();
            ngaysinh.Value = DateTime.Parse(viewSV.Rows[i].Cells[10].Value.ToString());
            txtNote.Text = viewSV.Rows[i].Cells[11].Value.ToString().Trim();


        }
        bool kiemtradauvao()
        {
            if (string.IsNullOrWhiteSpace(txtma.Text) ||
                   string.IsNullOrWhiteSpace(txtho.Text) ||
                   string.IsNullOrWhiteSpace(txtemail.Text) ||
                   string.IsNullOrWhiteSpace(txtsdt.Text) ||
                   string.IsNullOrWhiteSpace(txtchuyennganh.Text) ||
                   string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                   string.IsNullOrWhiteSpace(txtcccd.Text) ||
                   string.IsNullOrWhiteSpace(txtkhoahoc.Text)
                )

                return true;
            return false;
        }
        bool kiemtrasdt(string sdt)
        {
            if (sdt.Length < 10 || sdt.Length > 11 || !sdt.All(char.IsDigit))
            {
                return true;
            }
            if (sdt[0] != '0')
            {
                return true;
            }
            return false;
        }
        public void reset()
        {
            txtma.Text = "";
            txtho.Text = "";
            txtTen.Text = "";
            txtNote.Text = "";
            txtemail.Text = "";
            txtsdt.Text = "";
            txtchuyennganh.SelectedValue = 1;
            comgt.Text = "";
            txtdiachi.Text = "";
            txtcccd.Text = "";
            txtkhoahoc.Text = "";
            ngaysinh.Value = DateTime.Now;
        }
        public static bool kiemtraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo");
            }
            else if (kiemtrasdt(txtsdt.Text))
            {
                MessageBox.Show("Nhập sai số điện thoại", "Thông báo");
                txtsdt.Focus();
            }
            else if (!kiemtraEmail(txtemail.Text)){
                MessageBox.Show("Nhạp không đúng định dạng emai", "Thông báo");

            }
            else
            {
                try
                {
                    db.InsertSV(txtho.Text, txtTen.Text, txtma.Text, txtemail.Text, txtsdt.Text, txtchuyennganh.SelectedValue.ToString(), comgt.Text, txtdiachi.Text, txtcccd.Text, txtkhoahoc.Text, ngaysinh.Value, txtNote.Text);
                    reset();
                    LoadDS();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                catch (SqlException sqlEx)
                {
                    int startIndex = sqlEx.Message.IndexOf("'") + 1;
                    int endIndex = sqlEx.Message.IndexOf("'", startIndex);
                    string constraintName = "";
                    if (startIndex > 0 && endIndex > startIndex)
                    {
                        constraintName = sqlEx.Message.Substring(startIndex, endIndex - startIndex); // Lấy tên ràng buộc
                    }
                    if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi trùng lặp khóa chính hoặc duy nhất
                    {   
                        // Kiểm tra tên ràng buộc và hiển thị thông báo phù hợp
                        if (constraintName.Equals("UQ__Students__A9D105346936CFC0", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Email bạn nhập đã bị trùng: " + txtemail.Text, "Thông báo");
                        }
                        else if (constraintName == "UQ__Students__1FC88604777F06F7") // Giả sử đây là tên ràng buộc cho mã sinh viên
                        {
                            MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo");
                        }
                        else if (constraintName == "UQ_Students_IdentityNumber") // Giả sử đây là tên ràng buộc cho CCCD
                        {
                            MessageBox.Show("CCCD bạn nhập đã bị trùng", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi không xác định với ràng buộc: " +sqlEx.Message, "Thông báo");
                        }
                    }
                    else if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Mã ngành học không tồn tại", "Thông báo");

                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi không xác định: " + sqlEx.Message+"\n"+sqlEx.Number, "Thông báo");
                    }
                }
            }
        }

            private void viewSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void btnxoa_Click(object sender, EventArgs e)
            {
                if (kiemtradauvao())
                {

                    MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    try
                    {

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.DeleteSV(1, txtma.Text);
                        reset();
                        LoadDS();
                        MessageBox.Show("Xoá thành công", "Thông báo");
                    }

                   

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi trong quá trình xóa!" + ex, "Thông báo");
                    }
                }
            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
    }
