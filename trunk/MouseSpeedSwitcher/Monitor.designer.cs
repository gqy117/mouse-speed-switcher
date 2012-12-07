namespace MouseSpeedSwitcher
{
    partial class Monitor_Form
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
            this.lbl_Interval = new System.Windows.Forms.Label();
            this.txt_Interval = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Interval
            // 
            this.lbl_Interval.AutoSize = true;
            this.lbl_Interval.Location = new System.Drawing.Point(13, 27);
            this.lbl_Interval.Name = "lbl_Interval";
            this.lbl_Interval.Size = new System.Drawing.Size(67, 13);
            this.lbl_Interval.TabIndex = 0;
            this.lbl_Interval.Text = "Interval(min):";
            // 
            // txt_Interval
            // 
            this.txt_Interval.Location = new System.Drawing.Point(86, 24);
            this.txt_Interval.Name = "txt_Interval";
            this.txt_Interval.Size = new System.Drawing.Size(42, 20);
            this.txt_Interval.TabIndex = 1;
            this.txt_Interval.TextChanged += new System.EventHandler(this.txt_Interval_TextChanged);
            // 
            // Monitor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 110);
            this.Controls.Add(this.txt_Interval);
            this.Controls.Add(this.lbl_Interval);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor_Form";
            this.ShowInTaskbar = false;
            this.Text = "Close Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Interval;
        public System.Windows.Forms.TextBox txt_Interval;

    }
}

