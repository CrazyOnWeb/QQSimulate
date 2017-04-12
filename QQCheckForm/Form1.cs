using System;
using System.Windows.Forms;
using CRY.QQ.Simulate.Login;
using CRY.QQ.Simulate.Extensions;
using System.Drawing;
using System.IO;

namespace QQCheckForm {
    public partial class Form1 : Form {
        private QQLogin _qqLogin;
        public Form1() {
            InitializeComponent();
            _qqLogin = new QQLogin();
            _qqLogin.VerifyCodeImageLoad = LoadVerifyCode;
            _qqLogin.LoginStatusReset = LoginStatusReset;
        }

        private void LoginStatusReset(LoginStatus status) {
            if (status == LoginStatus.Logging) {
                this.LoginPanel.Enabled = false;
            } else {
                this.LoginPanel.Enabled = true;
            }
        }

        private void LoadVerifyCode(byte[] imagebytes) {
            ShowVerifyCodeUI();
            MemoryStream ms = new MemoryStream(imagebytes);
            Image img = Image.FromStream(ms);
            this.VerifycodeImage.Image = img;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(this.QQNum.Text) || string.IsNullOrEmpty(this.Password.Text)) {
                MessageBox.Show("please input your qqnumber and password ");
                return;
            }
            if (_qqLogin.Status == LoginStatus.Logoff) {
                var ack = _qqLogin.Login(this.QQNum.Text, this.Password.Text, this.Verifycode.Text);
                if (ack.LoginStatus == LoginStatus.Logged) {
                    SetLoggedUI();
                } else {
                    MessageBox.Show(ack.ErrorMessage);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            if (_qqLogin.Status == LoginStatus.Logoff) {
                MessageBox.Show("login first");
                return;
            }
            this.textBox3.Text = _qqLogin.LoginedQQ.FindQQ(this.textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e) {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void button3_Click_1(object sender, EventArgs e) {
            _qqLogin.VerifyCodeReLoad();
        }

        private void button4_Click(object sender, EventArgs e) {
            _qqLogin.LogOff();
            SetLogoffUI();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            HideVerifyCodeUI();
        }

        private void SetLogoffUI() {
            this.StatusLabel.Text = "logoff";
            this.LogoffBtn.Visible = false;
            this.LoginBtn.Visible = !this.LogoffBtn.Visible;
            this.InputPanel.Visible = true;
            HideVerifyCodeUI();
        }

        private void SetLoggedUI() {
            this.StatusLabel.Text = "logged";
            this.LogoffBtn.Visible = true;
            this.LoginBtn.Visible = !this.LogoffBtn.Visible;
            HideVerifyCodeUI();
            this.LoginBtn.Location = this.LogoffBtn.Location = new Point(this.LogoffBtn.Location.X, this.InputPanel.Location.Y);
            this.InputPanel.Visible = false;
        }

        private void ShowVerifyCodeUI() {
            this.VerifycodePanel.Visible = true;
            this.LoginBtn.Location = this.LogoffBtn.Location = new Point(this.VerifycodePanel.Location.X, this.VerifycodePanel.Location.Y + this.VerifycodePanel.Height);
        }

        private void HideVerifyCodeUI() {
            this.VerifycodePanel.Visible = false;
            this.Verifycode.Text = "";
            this.LoginBtn.Location = this.LogoffBtn.Location = new Point(this.VerifycodePanel.Location.X, this.VerifycodePanel.Location.Y);
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (_qqLogin.Status == LoginStatus.Logged) {
                SetLoggedUI();
            } else {
                SetLogoffUI();
            }
        }
    }
}
