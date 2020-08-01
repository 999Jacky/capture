namespace picShoot
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.相機ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPORTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相機編號ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拍攝樣本數ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋轉角度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析度ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.焦距ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟儲存資料夾ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.medNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.相機ToolStripMenuItem, this.開啟儲存資料夾ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 相機ToolStripMenuItem
            // 
            this.相機ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.cOMPORTToolStripMenuItem, this.相機編號ToolStripMenuItem, this.拍攝樣本數ToolStripMenuItem, this.旋轉角度ToolStripMenuItem, this.解析度ToolStripMenuItem1, this.焦距ToolStripMenuItem});
            this.相機ToolStripMenuItem.Name = "相機ToolStripMenuItem";
            this.相機ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.相機ToolStripMenuItem.Text = "設定";
            // 
            // cOMPORTToolStripMenuItem
            // 
            this.cOMPORTToolStripMenuItem.Name = "cOMPORTToolStripMenuItem";
            this.cOMPORTToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.cOMPORTToolStripMenuItem.Text = "COMPORT";
            this.cOMPORTToolStripMenuItem.Click += new System.EventHandler(this.cOMPORTToolStripMenuItem_Click);
            // 
            // 相機編號ToolStripMenuItem
            // 
            this.相機編號ToolStripMenuItem.Name = "相機編號ToolStripMenuItem";
            this.相機編號ToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.相機編號ToolStripMenuItem.Text = "相機編號";
            this.相機編號ToolStripMenuItem.Click += new System.EventHandler(this.相機編號ToolStripMenuItem_Click);
            // 
            // 拍攝樣本數ToolStripMenuItem
            // 
            this.拍攝樣本數ToolStripMenuItem.Name = "拍攝樣本數ToolStripMenuItem";
            this.拍攝樣本數ToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.拍攝樣本數ToolStripMenuItem.Text = "拍攝樣本數";
            this.拍攝樣本數ToolStripMenuItem.Click += new System.EventHandler(this.拍攝樣本數ToolStripMenuItem_Click);
            // 
            // 旋轉角度ToolStripMenuItem
            // 
            this.旋轉角度ToolStripMenuItem.Name = "旋轉角度ToolStripMenuItem";
            this.旋轉角度ToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.旋轉角度ToolStripMenuItem.Text = "旋轉角度";
            this.旋轉角度ToolStripMenuItem.Click += new System.EventHandler(this.旋轉角度ToolStripMenuItem_Click);
            // 
            // 解析度ToolStripMenuItem1
            // 
            this.解析度ToolStripMenuItem1.Name = "解析度ToolStripMenuItem1";
            this.解析度ToolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
            this.解析度ToolStripMenuItem1.Text = "解析度";
            this.解析度ToolStripMenuItem1.Click += new System.EventHandler(this.解析度ToolStripMenuItem1_Click_1);
            // 
            // 焦距ToolStripMenuItem
            // 
            this.焦距ToolStripMenuItem.Name = "焦距ToolStripMenuItem";
            this.焦距ToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.焦距ToolStripMenuItem.Text = "焦距";
            this.焦距ToolStripMenuItem.Click += new System.EventHandler(this.焦距ToolStripMenuItem_Click);
            // 
            // 開啟儲存資料夾ToolStripMenuItem
            // 
            this.開啟儲存資料夾ToolStripMenuItem.Name = "開啟儲存資料夾ToolStripMenuItem";
            this.開啟儲存資料夾ToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.開啟儲存資料夾ToolStripMenuItem.Text = "開啟儲存資料夾";
            this.開啟儲存資料夾ToolStripMenuItem.Click += new System.EventHandler(this.開啟儲存資料夾ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(314, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 398);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(12, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // medNameTextBox
            // 
            this.medNameTextBox.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.medNameTextBox.Location = new System.Drawing.Point(109, 90);
            this.medNameTextBox.Name = "medNameTextBox";
            this.medNameTextBox.Size = new System.Drawing.Size(199, 33);
            this.medNameTextBox.TabIndex = 3;
            this.medNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(7, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "藥物名稱：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "儲存路徑：";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.Location = new System.Drawing.Point(109, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button2.Location = new System.Drawing.Point(12, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 61);
            this.button2.TabIndex = 7;
            this.button2.Text = "開始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button3.Location = new System.Drawing.Point(163, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 61);
            this.button3.TabIndex = 8;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "已取樣：";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(109, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "0/0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 441);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.medNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem cOMPORTToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox medNameTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripMenuItem 拍攝樣本數ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相機ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相機編號ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 旋轉角度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 焦距ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟儲存資料夾ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析度ToolStripMenuItem1;

        #endregion
    }
}

