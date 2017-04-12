namespace QQCheckForm {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.LoginBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.QQNum = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.LogoffBtn = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.VerifycodePanel = new System.Windows.Forms.Panel();
            this.VerifycodeImage = new System.Windows.Forms.PictureBox();
            this.Verifycode = new System.Windows.Forms.TextBox();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.LoginPanel.SuspendLayout();
            this.VerifycodePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerifycodeImage)).BeginInit();
            this.InputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(71, 168);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(226, 40);
            this.LoginBtn.TabIndex = 5;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "FindQQ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // QQNum
            // 
            this.QQNum.Location = new System.Drawing.Point(54, 9);
            this.QQNum.Margin = new System.Windows.Forms.Padding(1);
            this.QQNum.Name = "QQNum";
            this.QQNum.Size = new System.Drawing.Size(226, 19);
            this.QQNum.TabIndex = 10;
            this.QQNum.Text = "245818392";
            this.QQNum.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(54, 35);
            this.Password.Margin = new System.Windows.Forms.Padding(1);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(226, 19);
            this.Password.TabIndex = 11;
            this.Password.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(161, 279);
            this.textBox3.Margin = new System.Windows.Forms.Padding(1);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 208);
            this.textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(59, 279);
            this.textBox4.Margin = new System.Windows.Forms.Padding(1);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(78, 19);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "123456";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "QQ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "QQ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(51, 14);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(34, 12);
            this.StatusLabel.TabIndex = 18;
            this.StatusLabel.Text = "logoff";
            // 
            // LogoffBtn
            // 
            this.LogoffBtn.Location = new System.Drawing.Point(71, 168);
            this.LogoffBtn.Name = "LogoffBtn";
            this.LogoffBtn.Size = new System.Drawing.Size(226, 40);
            this.LogoffBtn.TabIndex = 22;
            this.LogoffBtn.Text = "LogOff";
            this.LogoffBtn.UseVisualStyleBackColor = true;
            this.LogoffBtn.Visible = false;
            this.LogoffBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.LoginBtn);
            this.LoginPanel.Controls.Add(this.LogoffBtn);
            this.LoginPanel.Controls.Add(this.StatusLabel);
            this.LoginPanel.Controls.Add(this.VerifycodePanel);
            this.LoginPanel.Controls.Add(this.label4);
            this.LoginPanel.Controls.Add(this.InputPanel);
            this.LoginPanel.Location = new System.Drawing.Point(6, 3);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(324, 211);
            this.LoginPanel.TabIndex = 25;
            // 
            // VerifycodePanel
            // 
            this.VerifycodePanel.Controls.Add(this.VerifycodeImage);
            this.VerifycodePanel.Controls.Add(this.Verifycode);
            this.VerifycodePanel.Controls.Add(this.RefreshBtn);
            this.VerifycodePanel.Location = new System.Drawing.Point(71, 97);
            this.VerifycodePanel.Name = "VerifycodePanel";
            this.VerifycodePanel.Size = new System.Drawing.Size(226, 68);
            this.VerifycodePanel.TabIndex = 23;
            // 
            // VerifycodeImage
            // 
            this.VerifycodeImage.Location = new System.Drawing.Point(0, 8);
            this.VerifycodeImage.Name = "VerifycodeImage";
            this.VerifycodeImage.Size = new System.Drawing.Size(137, 50);
            this.VerifycodeImage.TabIndex = 19;
            this.VerifycodeImage.TabStop = false;
            // 
            // Verifycode
            // 
            this.Verifycode.Location = new System.Drawing.Point(147, 8);
            this.Verifycode.Margin = new System.Windows.Forms.Padding(1);
            this.Verifycode.Name = "Verifycode";
            this.Verifycode.Size = new System.Drawing.Size(78, 19);
            this.Verifycode.TabIndex = 20;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(148, 28);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(78, 30);
            this.RefreshBtn.TabIndex = 21;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.label1);
            this.InputPanel.Controls.Add(this.Password);
            this.InputPanel.Controls.Add(this.QQNum);
            this.InputPanel.Controls.Add(this.label2);
            this.InputPanel.Location = new System.Drawing.Point(17, 29);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(287, 62);
            this.InputPanel.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 221);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LoginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.VerifycodePanel.ResumeLayout(false);
            this.VerifycodePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerifycodeImage)).EndInit();
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox QQNum;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button LogoffBtn;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel VerifycodePanel;
        private System.Windows.Forms.PictureBox VerifycodeImage;
        private System.Windows.Forms.TextBox Verifycode;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Panel InputPanel;
    }
}

