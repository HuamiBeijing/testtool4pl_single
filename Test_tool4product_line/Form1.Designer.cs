namespace Test_tool4product_line
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_dev1 = new System.Windows.Forms.GroupBox();
            this.lb_dev1_status = new System.Windows.Forms.Label();
            this.lib_dev1_ng = new System.Windows.Forms.ListBox();
            this.lb_dev1_rlt = new System.Windows.Forms.Label();
            this.bt_teststart = new System.Windows.Forms.Button();
            this.lb_ttstatus = new System.Windows.Forms.Label();
            this.pb_dev1_barcode = new System.Windows.Forms.PictureBox();
            this.lb_hiddevice = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rssimin = new System.Windows.Forms.TextBox();
            this.gb_dev1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dev1_barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_dev1
            // 
            this.gb_dev1.Controls.Add(this.rssimin);
            this.gb_dev1.Controls.Add(this.label1);
            this.gb_dev1.Controls.Add(this.lb_dev1_status);
            this.gb_dev1.Controls.Add(this.lib_dev1_ng);
            this.gb_dev1.Controls.Add(this.lb_dev1_rlt);
            this.gb_dev1.Location = new System.Drawing.Point(14, 191);
            this.gb_dev1.Name = "gb_dev1";
            this.gb_dev1.Size = new System.Drawing.Size(398, 222);
            this.gb_dev1.TabIndex = 2;
            this.gb_dev1.TabStop = false;
            this.gb_dev1.Text = "1号设备";
            // 
            // lb_dev1_status
            // 
            this.lb_dev1_status.AutoSize = true;
            this.lb_dev1_status.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_dev1_status.ForeColor = System.Drawing.Color.Gray;
            this.lb_dev1_status.Location = new System.Drawing.Point(32, 42);
            this.lb_dev1_status.Name = "lb_dev1_status";
            this.lb_dev1_status.Size = new System.Drawing.Size(78, 23);
            this.lb_dev1_status.TabIndex = 3;
            this.lb_dev1_status.Text = "等待连接";
            // 
            // lib_dev1_ng
            // 
            this.lib_dev1_ng.FormattingEnabled = true;
            this.lib_dev1_ng.ItemHeight = 12;
            this.lib_dev1_ng.Location = new System.Drawing.Point(6, 104);
            this.lib_dev1_ng.Name = "lib_dev1_ng";
            this.lib_dev1_ng.Size = new System.Drawing.Size(386, 112);
            this.lib_dev1_ng.TabIndex = 2;
            // 
            // lb_dev1_rlt
            // 
            this.lb_dev1_rlt.AutoSize = true;
            this.lb_dev1_rlt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_dev1_rlt.ForeColor = System.Drawing.Color.Blue;
            this.lb_dev1_rlt.Location = new System.Drawing.Point(232, 17);
            this.lb_dev1_rlt.Name = "lb_dev1_rlt";
            this.lb_dev1_rlt.Size = new System.Drawing.Size(92, 27);
            this.lb_dev1_rlt.TabIndex = 1;
            this.lb_dev1_rlt.Text = "测试结果";
            // 
            // bt_teststart
            // 
            this.bt_teststart.Location = new System.Drawing.Point(14, 141);
            this.bt_teststart.Name = "bt_teststart";
            this.bt_teststart.Size = new System.Drawing.Size(198, 44);
            this.bt_teststart.TabIndex = 6;
            this.bt_teststart.Text = "连接设备";
            this.bt_teststart.UseVisualStyleBackColor = true;
            this.bt_teststart.Click += new System.EventHandler(this.bt_teststart_Click);
            // 
            // lb_ttstatus
            // 
            this.lb_ttstatus.AutoSize = true;
            this.lb_ttstatus.Location = new System.Drawing.Point(249, 157);
            this.lb_ttstatus.Name = "lb_ttstatus";
            this.lb_ttstatus.Size = new System.Drawing.Size(89, 12);
            this.lb_ttstatus.TabIndex = 7;
            this.lb_ttstatus.Text = "测试工具等待中";
            // 
            // pb_dev1_barcode
            // 
            this.pb_dev1_barcode.Location = new System.Drawing.Point(14, 419);
            this.pb_dev1_barcode.Name = "pb_dev1_barcode";
            this.pb_dev1_barcode.Size = new System.Drawing.Size(400, 160);
            this.pb_dev1_barcode.TabIndex = 8;
            this.pb_dev1_barcode.TabStop = false;
            // 
            // lb_hiddevice
            // 
            this.lb_hiddevice.FormattingEnabled = true;
            this.lb_hiddevice.ItemHeight = 12;
            this.lb_hiddevice.Location = new System.Drawing.Point(14, 11);
            this.lb_hiddevice.Name = "lb_hiddevice";
            this.lb_hiddevice.Size = new System.Drawing.Size(397, 124);
            this.lb_hiddevice.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "RSSI限值";
            // 
            // rssimin
            // 
            this.rssimin.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rssimin.Location = new System.Drawing.Point(283, 63);
            this.rssimin.Name = "rssimin";
            this.rssimin.Size = new System.Drawing.Size(55, 21);
            this.rssimin.TabIndex = 5;
            this.rssimin.Text = "-95";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 591);
            this.Controls.Add(this.lb_hiddevice);
            this.Controls.Add(this.pb_dev1_barcode);
            this.Controls.Add(this.lb_ttstatus);
            this.Controls.Add(this.bt_teststart);
            this.Controls.Add(this.gb_dev1);
            this.Name = "Form1";
            this.Text = "测试工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gb_dev1.ResumeLayout(false);
            this.gb_dev1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dev1_barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_dev1;
        private System.Windows.Forms.Label lb_dev1_status;
        private System.Windows.Forms.ListBox lib_dev1_ng;
        private System.Windows.Forms.Label lb_dev1_rlt;
        private System.Windows.Forms.Button bt_teststart;
        private System.Windows.Forms.Label lb_ttstatus;
        private System.Windows.Forms.PictureBox pb_dev1_barcode;
        private System.Windows.Forms.ListBox lb_hiddevice;
        private System.Windows.Forms.TextBox rssimin;
        private System.Windows.Forms.Label label1;
    }
}

