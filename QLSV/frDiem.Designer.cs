namespace QLSV
{
    partial class frDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmadaudiem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comMaLop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdiemso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttmasv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtiddiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvDiem = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(311, 328);
            this.btnsua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(92, 38);
            this.btnsua.TabIndex = 38;
            this.btnsua.Text = "Sửa ";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click_1);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(106, 328);
            this.btnthem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(92, 38);
            this.btnthem.TabIndex = 36;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(512, 328);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 38);
            this.button4.TabIndex = 39;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 32);
            this.label1.TabIndex = 37;
            this.label1.Text = "QUẢN LÝ ĐIỂM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmadaudiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comMaLop);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtdiemso);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txttmasv);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtiddiem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(943, 241);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txtmadaudiem
            // 
            this.txtmadaudiem.FormattingEnabled = true;
            this.txtmadaudiem.Location = new System.Drawing.Point(160, 177);
            this.txtmadaudiem.Name = "txtmadaudiem";
            this.txtmadaudiem.Size = new System.Drawing.Size(244, 28);
            this.txtmadaudiem.TabIndex = 17;
            this.txtmadaudiem.SelectedIndexChanged += new System.EventHandler(this.txtmadaudiem_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mã lớp";
            // 
            // comMaLop
            // 
            this.comMaLop.FormattingEnabled = true;
            this.comMaLop.Location = new System.Drawing.Point(160, 109);
            this.comMaLop.Name = "comMaLop";
            this.comMaLop.Size = new System.Drawing.Size(244, 28);
            this.comMaLop.TabIndex = 15;
            this.comMaLop.SelectedIndexChanged += new System.EventHandler(this.comMaLop_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(496, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Mã sinh viên";
            // 
            // txtdiemso
            // 
            this.txtdiemso.Location = new System.Drawing.Point(656, 109);
            this.txtdiemso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdiemso.Name = "txtdiemso";
            this.txtdiemso.Size = new System.Drawing.Size(246, 26);
            this.txtdiemso.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Điểm số";
            // 
            // txttmasv
            // 
            this.txttmasv.Location = new System.Drawing.Point(656, 44);
            this.txttmasv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttmasv.Name = "txttmasv";
            this.txttmasv.Size = new System.Drawing.Size(246, 26);
            this.txttmasv.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID điểm";
            // 
            // txtiddiem
            // 
            this.txtiddiem.Enabled = false;
            this.txtiddiem.Location = new System.Drawing.Point(160, 48);
            this.txtiddiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtiddiem.Name = "txtiddiem";
            this.txtiddiem.Size = new System.Drawing.Size(246, 26);
            this.txtiddiem.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã đầu điểm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvDiem);
            this.groupBox2.Location = new System.Drawing.Point(24, 388);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(943, 220);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dtgvDiem
            // 
            this.dtgvDiem.AllowUserToAddRows = false;
            this.dtgvDiem.AllowUserToDeleteRows = false;
            this.dtgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDiem.Location = new System.Drawing.Point(3, 23);
            this.dtgvDiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvDiem.Name = "dtgvDiem";
            this.dtgvDiem.ReadOnly = true;
            this.dtgvDiem.RowHeadersWidth = 51;
            this.dtgvDiem.Size = new System.Drawing.Size(937, 193);
            this.dtgvDiem.TabIndex = 0;
            this.dtgvDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDiem_CellClick);
            // 
            // frDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 662);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frDiem";
            this.Text = "Quản lý điểm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox txtmadaudiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comMaLop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtdiemso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttmasv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtiddiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvDiem;
    }
}