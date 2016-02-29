namespace LastFM_Now_Playing
{
    partial class Settings
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.dividerText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReverseStatus = new System.Windows.Forms.CheckBox();
            this.nowplayingTitle = new System.Windows.Forms.Label();
            this.nowplayingPrefix = new System.Windows.Forms.TextBox();
            this.lastplayedPrefix = new System.Windows.Forms.TextBox();
            this.fillEntire = new System.Windows.Forms.CheckBox();
            this.nowplayingText = new System.Windows.Forms.Label();
            this.lastplayedText = new System.Windows.Forms.Label();
            this.nowplayingUsage = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dividerText
            // 
            this.dividerText.Location = new System.Drawing.Point(85, 23);
            this.dividerText.Name = "dividerText";
            this.dividerText.Size = new System.Drawing.Size(52, 20);
            this.dividerText.TabIndex = 0;
            this.dividerText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Divider";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(52, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Result";
            // 
            // ReverseStatus
            // 
            this.ReverseStatus.AutoSize = true;
            this.ReverseStatus.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReverseStatus.Location = new System.Drawing.Point(182, 20);
            this.ReverseStatus.Name = "ReverseStatus";
            this.ReverseStatus.Size = new System.Drawing.Size(80, 20);
            this.ReverseStatus.TabIndex = 4;
            this.ReverseStatus.Text = "Reverse";
            this.ReverseStatus.UseVisualStyleBackColor = true;
            this.ReverseStatus.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // nowplayingTitle
            // 
            this.nowplayingTitle.AutoSize = true;
            this.nowplayingTitle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowplayingTitle.Location = new System.Drawing.Point(12, 61);
            this.nowplayingTitle.Name = "nowplayingTitle";
            this.nowplayingTitle.Size = new System.Drawing.Size(92, 17);
            this.nowplayingTitle.TabIndex = 5;
            this.nowplayingTitle.Text = "Now Playing:";
            // 
            // nowplayingPrefix
            // 
            this.nowplayingPrefix.Location = new System.Drawing.Point(182, 86);
            this.nowplayingPrefix.Name = "nowplayingPrefix";
            this.nowplayingPrefix.Size = new System.Drawing.Size(100, 20);
            this.nowplayingPrefix.TabIndex = 6;
            this.nowplayingPrefix.Click += new System.EventHandler(this.textBox2_Click);
            this.nowplayingPrefix.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lastplayedPrefix
            // 
            this.lastplayedPrefix.Location = new System.Drawing.Point(182, 113);
            this.lastplayedPrefix.Name = "lastplayedPrefix";
            this.lastplayedPrefix.Size = new System.Drawing.Size(100, 20);
            this.lastplayedPrefix.TabIndex = 7;
            this.lastplayedPrefix.Click += new System.EventHandler(this.textBox3_Click);
            this.lastplayedPrefix.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // fillEntire
            // 
            this.fillEntire.AutoSize = true;
            this.fillEntire.Location = new System.Drawing.Point(182, 139);
            this.fillEntire.Name = "fillEntire";
            this.fillEntire.Size = new System.Drawing.Size(38, 17);
            this.fillEntire.TabIndex = 8;
            this.fillEntire.Text = "Fill";
            this.fillEntire.UseVisualStyleBackColor = true;
            this.fillEntire.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // nowplayingText
            // 
            this.nowplayingText.AutoSize = true;
            this.nowplayingText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowplayingText.Location = new System.Drawing.Point(52, 91);
            this.nowplayingText.Name = "nowplayingText";
            this.nowplayingText.Size = new System.Drawing.Size(114, 15);
            this.nowplayingText.TabIndex = 9;
            this.nowplayingText.Text = "\"Now playing\" prefix";
            // 
            // lastplayedText
            // 
            this.lastplayedText.AutoSize = true;
            this.lastplayedText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastplayedText.Location = new System.Drawing.Point(52, 118);
            this.lastplayedText.Name = "lastplayedText";
            this.lastplayedText.Size = new System.Drawing.Size(124, 15);
            this.lastplayedText.TabIndex = 10;
            this.lastplayedText.Text = "If currently not playing";
            // 
            // nowplayingUsage
            // 
            this.nowplayingUsage.AutoSize = true;
            this.nowplayingUsage.Checked = true;
            this.nowplayingUsage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nowplayingUsage.Location = new System.Drawing.Point(120, 63);
            this.nowplayingUsage.Name = "nowplayingUsage";
            this.nowplayingUsage.Size = new System.Drawing.Size(73, 17);
            this.nowplayingUsage.TabIndex = 11;
            this.nowplayingUsage.Text = "Add prefix";
            this.nowplayingUsage.UseVisualStyleBackColor = true;
            this.nowplayingUsage.CheckedChanged += new System.EventHandler(this.nowplayingUsage_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(178, 206);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 238);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nowplayingUsage);
            this.Controls.Add(this.lastplayedText);
            this.Controls.Add(this.nowplayingText);
            this.Controls.Add(this.fillEntire);
            this.Controls.Add(this.lastplayedPrefix);
            this.Controls.Add(this.nowplayingPrefix);
            this.Controls.Add(this.nowplayingTitle);
            this.Controls.Add(this.ReverseStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dividerText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dividerText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ReverseStatus;
        private System.Windows.Forms.Label nowplayingTitle;
        private System.Windows.Forms.TextBox nowplayingPrefix;
        private System.Windows.Forms.TextBox lastplayedPrefix;
        private System.Windows.Forms.CheckBox fillEntire;
        private System.Windows.Forms.Label nowplayingText;
        private System.Windows.Forms.Label lastplayedText;
        private System.Windows.Forms.CheckBox nowplayingUsage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}