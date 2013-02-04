namespace SerialDownload
{
    partial class Download
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
            this.components = new System.ComponentModel.Container();
            this.FileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NumTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.WorkTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KeyIDTextBox = new System.Windows.Forms.TextBox();
            this.DepTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logInfo = new System.Windows.Forms.TextBox();
            this.ComComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.OverTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownLoadLable = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(12, 431);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(75, 23);
            this.FileButton.TabIndex = 7;
            this.FileButton.Text = "选择文件";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NumTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.WorkTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.KeyIDTextBox);
            this.groupBox1.Controls.Add(this.DepTextBox);
            this.groupBox1.Controls.Add(this.NameTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员信息";
            // 
            // NumTextBox
            // 
            this.NumTextBox.Location = new System.Drawing.Point(91, 162);
            this.NumTextBox.MaxLength = 8;
            this.NumTextBox.Name = "NumTextBox";
            this.NumTextBox.Size = new System.Drawing.Size(102, 21);
            this.NumTextBox.TabIndex = 5;
            this.NumTextBox.Text = "输入工号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "工号：";
            // 
            // WorkTextBox
            // 
            this.WorkTextBox.Location = new System.Drawing.Point(91, 121);
            this.WorkTextBox.MaxLength = 8;
            this.WorkTextBox.Name = "WorkTextBox";
            this.WorkTextBox.Size = new System.Drawing.Size(102, 21);
            this.WorkTextBox.TabIndex = 4;
            this.WorkTextBox.Text = "输入工种";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "工种：";
            // 
            // KeyIDTextBox
            // 
            this.KeyIDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.KeyIDTextBox.Location = new System.Drawing.Point(91, 200);
            this.KeyIDTextBox.MaxLength = 16;
            this.KeyIDTextBox.Name = "KeyIDTextBox";
            this.KeyIDTextBox.Size = new System.Drawing.Size(102, 21);
            this.KeyIDTextBox.TabIndex = 6;
            this.KeyIDTextBox.Text = "015C10BC000D0A66";
            // 
            // DepTextBox
            // 
            this.DepTextBox.Location = new System.Drawing.Point(91, 82);
            this.DepTextBox.MaxLength = 8;
            this.DepTextBox.Name = "DepTextBox";
            this.DepTextBox.Size = new System.Drawing.Size(102, 21);
            this.DepTextBox.TabIndex = 3;
            this.DepTextBox.Text = "输入单位";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(91, 40);
            this.NameTextBox.MaxLength = 8;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 21);
            this.NameTextBox.TabIndex = 2;
            this.NameTextBox.Text = "输入姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "KeyID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "单位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PictureBox);
            this.groupBox2.Location = new System.Drawing.Point(418, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "照片";
            // 
            // PictureBox
            // 
            this.PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBox.Location = new System.Drawing.Point(6, 20);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(188, 230);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logInfo);
            this.groupBox3.Location = new System.Drawing.Point(12, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 130);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消息";
            // 
            // logInfo
            // 
            this.logInfo.AllowDrop = true;
            this.logInfo.Location = new System.Drawing.Point(14, 20);
            this.logInfo.Multiline = true;
            this.logInfo.Name = "logInfo";
            this.logInfo.ReadOnly = true;
            this.logInfo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.logInfo.Size = new System.Drawing.Size(580, 96);
            this.logInfo.TabIndex = 0;
            // 
            // ComComboBox
            // 
            this.ComComboBox.FormattingEnabled = true;
            this.ComComboBox.Location = new System.Drawing.Point(103, 19);
            this.ComComboBox.Name = "ComComboBox";
            this.ComComboBox.Size = new System.Drawing.Size(102, 20);
            this.ComComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "串口:";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(546, 431);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 8;
            this.DownloadButton.Text = "下载";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(93, 431);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(423, 23);
            this.DownloadProgressBar.TabIndex = 6;
            // 
            // DownLoadLable
            // 
            this.DownLoadLable.AutoSize = true;
            this.DownLoadLable.Location = new System.Drawing.Point(526, 437);
            this.DownLoadLable.Name = "DownLoadLable";
            this.DownLoadLable.Size = new System.Drawing.Size(0, 12);
            this.DownLoadLable.TabIndex = 6;
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(630, 485);
            this.Controls.Add(this.DownLoadLable);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComComboBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FileButton);
            this.MaximizeBox = false;
            this.Name = "Download";
            this.Text = "人员信息下载软件";
            this.Load += new System.EventHandler(this.Download_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox KeyIDTextBox;
        private System.Windows.Forms.TextBox DepTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ComComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logInfo;
        private System.Windows.Forms.Button DownloadButton;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer OverTimeTimer;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label DownLoadLable;
        private System.Windows.Forms.TextBox NumTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WorkTextBox;
        private System.Windows.Forms.Label label5;
    }
}

