namespace MouseSpeedSwitcher
{
    partial class MouseSwitcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.tB_Sensitivity1 = new System.Windows.Forms.TrackBar();
            this.tB_Sensitivity2 = new System.Windows.Forms.TrackBar();
            this.tB_Sensitivity3 = new System.Windows.Forms.TrackBar();
            this.lbl_Sensitivity1 = new System.Windows.Forms.Label();
            this.lbl_Sensitivity2 = new System.Windows.Forms.Label();
            this.lbl_Sensitivity3 = new System.Windows.Forms.Label();
            this.lbl_Sensitivity1_Value = new System.Windows.Forms.Label();
            this.lbl_Sensitivity2_Value = new System.Windows.Forms.Label();
            this.lbl_HotKey = new System.Windows.Forms.Label();
            this.lbl_Ctrl = new System.Windows.Forms.Label();
            this.txt_HotKey = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.lbl_Sensitivity3_Value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Sensitivity1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Sensitivity2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Sensitivity3)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_Sensitivity1
            // 
            this.tB_Sensitivity1.LargeChange = 2;
            this.tB_Sensitivity1.Location = new System.Drawing.Point(100, 28);
            this.tB_Sensitivity1.Maximum = 20;
            this.tB_Sensitivity1.Name = "tB_Sensitivity1";
            this.tB_Sensitivity1.Size = new System.Drawing.Size(267, 45);
            this.tB_Sensitivity1.TabIndex = 0;
            this.tB_Sensitivity1.ValueChanged += new System.EventHandler(this.tB_Sensitivity1_ValueChanged);
            // 
            // tB_Sensitivity2
            // 
            this.tB_Sensitivity2.LargeChange = 2;
            this.tB_Sensitivity2.Location = new System.Drawing.Point(100, 71);
            this.tB_Sensitivity2.Maximum = 20;
            this.tB_Sensitivity2.Name = "tB_Sensitivity2";
            this.tB_Sensitivity2.Size = new System.Drawing.Size(267, 45);
            this.tB_Sensitivity2.TabIndex = 1;
            this.tB_Sensitivity2.ValueChanged += new System.EventHandler(this.tB_Sensitivity2_ValueChanged);
            // 
            // tB_Sensitivity3
            // 
            this.tB_Sensitivity3.LargeChange = 2;
            this.tB_Sensitivity3.Location = new System.Drawing.Point(100, 112);
            this.tB_Sensitivity3.Maximum = 20;
            this.tB_Sensitivity3.Name = "tB_Sensitivity3";
            this.tB_Sensitivity3.Size = new System.Drawing.Size(267, 45);
            this.tB_Sensitivity3.TabIndex = 2;
            this.tB_Sensitivity3.ValueChanged += new System.EventHandler(this.tB_Sensitivity3_ValueChanged);
            // 
            // lbl_Sensitivity1
            // 
            this.lbl_Sensitivity1.AutoSize = true;
            this.lbl_Sensitivity1.Location = new System.Drawing.Point(12, 28);
            this.lbl_Sensitivity1.Name = "lbl_Sensitivity1";
            this.lbl_Sensitivity1.Size = new System.Drawing.Size(60, 13);
            this.lbl_Sensitivity1.TabIndex = 3;
            this.lbl_Sensitivity1.Text = "Sensitivity1";
            // 
            // lbl_Sensitivity2
            // 
            this.lbl_Sensitivity2.AutoSize = true;
            this.lbl_Sensitivity2.Location = new System.Drawing.Point(12, 71);
            this.lbl_Sensitivity2.Name = "lbl_Sensitivity2";
            this.lbl_Sensitivity2.Size = new System.Drawing.Size(60, 13);
            this.lbl_Sensitivity2.TabIndex = 4;
            this.lbl_Sensitivity2.Text = "Sensitivity2";
            // 
            // lbl_Sensitivity3
            // 
            this.lbl_Sensitivity3.AutoSize = true;
            this.lbl_Sensitivity3.Location = new System.Drawing.Point(12, 112);
            this.lbl_Sensitivity3.Name = "lbl_Sensitivity3";
            this.lbl_Sensitivity3.Size = new System.Drawing.Size(60, 13);
            this.lbl_Sensitivity3.TabIndex = 5;
            this.lbl_Sensitivity3.Text = "Sensitivity3";
            // 
            // lbl_Sensitivity1_Value
            // 
            this.lbl_Sensitivity1_Value.AutoSize = true;
            this.lbl_Sensitivity1_Value.Location = new System.Drawing.Point(367, 39);
            this.lbl_Sensitivity1_Value.Name = "lbl_Sensitivity1_Value";
            this.lbl_Sensitivity1_Value.Size = new System.Drawing.Size(0, 13);
            this.lbl_Sensitivity1_Value.TabIndex = 6;
            // 
            // lbl_Sensitivity2_Value
            // 
            this.lbl_Sensitivity2_Value.AutoSize = true;
            this.lbl_Sensitivity2_Value.Location = new System.Drawing.Point(367, 76);
            this.lbl_Sensitivity2_Value.Name = "lbl_Sensitivity2_Value";
            this.lbl_Sensitivity2_Value.Size = new System.Drawing.Size(0, 13);
            this.lbl_Sensitivity2_Value.TabIndex = 7;
            // 
            // lbl_HotKey
            // 
            this.lbl_HotKey.AutoSize = true;
            this.lbl_HotKey.Location = new System.Drawing.Point(14, 168);
            this.lbl_HotKey.Name = "lbl_HotKey";
            this.lbl_HotKey.Size = new System.Drawing.Size(45, 13);
            this.lbl_HotKey.TabIndex = 8;
            this.lbl_HotKey.Text = "HotKey:";
            // 
            // lbl_Ctrl
            // 
            this.lbl_Ctrl.AutoSize = true;
            this.lbl_Ctrl.Location = new System.Drawing.Point(89, 168);
            this.lbl_Ctrl.Name = "lbl_Ctrl";
            this.lbl_Ctrl.Size = new System.Drawing.Size(38, 13);
            this.lbl_Ctrl.TabIndex = 9;
            this.lbl_Ctrl.Text = "lbl_Ctrl";
            // 
            // txt_HotKey
            // 
            this.txt_HotKey.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_HotKey.Location = new System.Drawing.Point(133, 165);
            this.txt_HotKey.Name = "txt_HotKey";
            this.txt_HotKey.ReadOnly = true;
            this.txt_HotKey.Size = new System.Drawing.Size(116, 20);
            this.txt_HotKey.TabIndex = 10;
            this.txt_HotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_HotKey_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(78, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(78, 70);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(78, 111);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // lbl_Sensitivity3_Value
            // 
            this.lbl_Sensitivity3_Value.AutoSize = true;
            this.lbl_Sensitivity3_Value.Location = new System.Drawing.Point(367, 119);
            this.lbl_Sensitivity3_Value.Name = "lbl_Sensitivity3_Value";
            this.lbl_Sensitivity3_Value.Size = new System.Drawing.Size(0, 13);
            this.lbl_Sensitivity3_Value.TabIndex = 14;
            // 
            // MouseSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 206);
            this.Controls.Add(this.lbl_Sensitivity3_Value);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt_HotKey);
            this.Controls.Add(this.lbl_Ctrl);
            this.Controls.Add(this.lbl_HotKey);
            this.Controls.Add(this.lbl_Sensitivity2_Value);
            this.Controls.Add(this.lbl_Sensitivity1_Value);
            this.Controls.Add(this.lbl_Sensitivity3);
            this.Controls.Add(this.lbl_Sensitivity2);
            this.Controls.Add(this.lbl_Sensitivity1);
            this.Controls.Add(this.tB_Sensitivity3);
            this.Controls.Add(this.tB_Sensitivity2);
            this.Controls.Add(this.tB_Sensitivity1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseSwitcher";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Mouse Switcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MouseSwitcher_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tB_Sensitivity1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Sensitivity2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Sensitivity3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_Sensitivity3;
        public System.Windows.Forms.TrackBar tB_Sensitivity1;
        public System.Windows.Forms.TrackBar tB_Sensitivity2;
        public System.Windows.Forms.Label lbl_Sensitivity1;
        public System.Windows.Forms.Label lbl_Sensitivity2;
        public System.Windows.Forms.TrackBar tB_Sensitivity3;
        public System.Windows.Forms.Label lbl_Sensitivity1_Value;
        public System.Windows.Forms.Label lbl_Sensitivity2_Value;
        private System.Windows.Forms.Label lbl_HotKey;
        public System.Windows.Forms.TextBox txt_HotKey;
        public System.Windows.Forms.Label lbl_Ctrl;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.Label lbl_Sensitivity3_Value;
    }
}

