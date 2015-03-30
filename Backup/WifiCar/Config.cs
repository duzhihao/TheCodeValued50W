namespace WifiCar
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class Config : Form
    {
        private TextBox bizhang;
        private Button button1;
        private Button button2;
        private IContainer components = null;
        public string FileName;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox hongwai;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBoxControlPort;
        private TextBox textBoxVideo;
        private TextBox textControlURL;
        private TextBox txtBackward;
        private TextBox txtEngineCenter;
        private TextBox txtEngineLeft;
        private TextBox txtEngineRight;
        private TextBox txtForward;
        private TextBox txtLeft;
        private TextBox txtRight;
        private TextBox txtStop;
        private TextBox wangluo;
        private TextBox wudao;
        private TextBox xunxian;
        private TextBox zhuiguang;

        public Config()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WriteIni("VideoUrl", "videourl", this.textBoxVideo.Text);
            this.WriteIni("ControlUrl", "controlUrl", this.textControlURL.Text);
            this.WriteIni("ControlPort", "controlPort", this.textBoxControlPort.Text);
            this.WriteIni("ControlCommand", "CMD_Forward", this.txtForward.Text);
            this.WriteIni("ControlCommand", "CMD_Backward", this.txtBackward.Text);
            this.WriteIni("ControlCommand", "CMD_TurnLeft", this.txtLeft.Text);
            this.WriteIni("ControlCommand", "CMD_TurnRight", this.txtRight.Text);
            this.WriteIni("ControlCommand", "CMD_Stop", this.txtStop.Text);
            this.WriteIni("ControlCommand", "CMD_EngineLeft", this.txtEngineLeft.Text);
            this.WriteIni("ControlCommand", "CMD_EngineCenter", this.txtEngineCenter.Text);
            this.WriteIni("ControlCommand", "CMD_EngineRight", this.txtEngineRight.Text);
            this.WriteIni("ControlCommand", "CMD_Xunxian", this.xunxian.Text);
            this.WriteIni("ControlCommand", "CMD_Hongwai", this.hongwai.Text);
            this.WriteIni("ControlCommand", "CMD_Zhuiguang", this.zhuiguang.Text);
            this.WriteIni("ControlCommand", "CMD_Bizhang", this.bizhang.Text);
            this.WriteIni("ControlCommand", "CMD_Wudao", this.wudao.Text);
            this.WriteIni("ControlCommand", "CMD_Wangluo", this.wangluo.Text);
            MessageBox.Show("配置成功！请重启程序以使配置生效。", "配置信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            base.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            this.GetIni();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GetIni()
        {
            this.FileName = Application.StartupPath + @"\Config.ini";
            this.textBoxVideo.Text = this.ReadIni("VideoUrl", "videourl", "");
            this.textControlURL.Text = this.ReadIni("ControlUrl", "controlUrl", "");
            this.textBoxControlPort.Text = this.ReadIni("ControlPort", "controlPort", "");
            this.txtForward.Text = this.ReadIni("ControlCommand", "CMD_Forward", "");
            this.txtBackward.Text = this.ReadIni("ControlCommand", "CMD_Backward", "");
            this.txtLeft.Text = this.ReadIni("ControlCommand", "CMD_TurnLeft", "");
            this.txtRight.Text = this.ReadIni("ControlCommand", "CMD_TurnRight", "");
            this.txtStop.Text = this.ReadIni("ControlCommand", "CMD_Stop", "");
            this.txtEngineLeft.Text = this.ReadIni("ControlCommand", "CMD_EngineLeft", "");
            this.txtEngineCenter.Text = this.ReadIni("ControlCommand", "CMD_EngineCenter", "");
            this.txtEngineRight.Text = this.ReadIni("ControlCommand", "CMD_EngineRight", "");
            this.xunxian.Text = this.ReadIni("ControlCommand", "CMD_Xunxian", "");
            this.hongwai.Text = this.ReadIni("ControlCommand", "CMD_Hongwai", "");
            this.zhuiguang.Text = this.ReadIni("ControlCommand", "CMD_Zhuiguang", "");
            this.bizhang.Text = this.ReadIni("ControlCommand", "CMD_Bizhang", "");
            this.wudao.Text = this.ReadIni("ControlCommand", "CMD_Wudao", "");
            this.wangluo.Text = this.ReadIni("ControlCommand", "CMD_Wangluo", "");
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Config));
            this.button1 = new Button();
            this.button2 = new Button();
            this.groupBox1 = new GroupBox();
            this.txtEngineRight = new TextBox();
            this.label11 = new Label();
            this.txtEngineCenter = new TextBox();
            this.txtEngineLeft = new TextBox();
            this.label10 = new Label();
            this.label9 = new Label();
            this.txtBackward = new TextBox();
            this.txtStop = new TextBox();
            this.txtLeft = new TextBox();
            this.txtRight = new TextBox();
            this.txtForward = new TextBox();
            this.label8 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label4 = new Label();
            this.groupBox2 = new GroupBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.textBoxControlPort = new TextBox();
            this.textControlURL = new TextBox();
            this.textBoxVideo = new TextBox();
            this.groupBox3 = new GroupBox();
            this.label17 = new Label();
            this.wangluo = new TextBox();
            this.label16 = new Label();
            this.wudao = new TextBox();
            this.label15 = new Label();
            this.bizhang = new TextBox();
            this.label14 = new Label();
            this.zhuiguang = new TextBox();
            this.label13 = new Label();
            this.hongwai = new TextBox();
            this.label12 = new Label();
            this.xunxian = new TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.button1.Location = new Point(0x19d, 0x110);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(0x1f1, 0x110);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox1.Controls.Add(this.txtEngineRight);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEngineCenter);
            this.groupBox1.Controls.Add(this.txtEngineLeft);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBackward);
            this.groupBox1.Controls.Add(this.txtStop);
            this.groupBox1.Controls.Add(this.txtLeft);
            this.groupBox1.Controls.Add(this.txtRight);
            this.groupBox1.Controls.Add(this.txtForward);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new Point(12, 0x6b);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x18b, 0xc2);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指令设置";
            this.txtEngineRight.Location = new Point(0x138, 0x77);
            this.txtEngineRight.Name = "txtEngineRight";
            this.txtEngineRight.Size = new Size(0x3e, 0x15);
            this.txtEngineRight.TabIndex = 0x25;
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0xf8, 0x7a);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x35, 12);
            this.label11.TabIndex = 0x24;
            this.label11.Text = "舵机右转";
            this.txtEngineCenter.Location = new Point(0x138, 0x4a);
            this.txtEngineCenter.Name = "txtEngineCenter";
            this.txtEngineCenter.Size = new Size(0x3e, 0x15);
            this.txtEngineCenter.TabIndex = 0x23;
            this.txtEngineLeft.Location = new Point(0x138, 0x19);
            this.txtEngineLeft.Name = "txtEngineLeft";
            this.txtEngineLeft.Size = new Size(0x3e, 0x15);
            this.txtEngineLeft.TabIndex = 0x22;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0xf8, 0x4d);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x35, 12);
            this.label10.TabIndex = 0x21;
            this.label10.Text = "舵机居中";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0xf8, 0x1c);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x35, 12);
            this.label9.TabIndex = 0x20;
            this.label9.Text = "舵机左转";
            this.txtBackward.Location = new Point(0xa6, 0x19);
            this.txtBackward.Name = "txtBackward";
            this.txtBackward.Size = new Size(0x3f, 0x15);
            this.txtBackward.TabIndex = 0x1f;
            this.txtStop.Location = new Point(0x35, 0x77);
            this.txtStop.Name = "txtStop";
            this.txtStop.Size = new Size(0x3e, 0x15);
            this.txtStop.TabIndex = 30;
            this.txtLeft.Location = new Point(0x35, 0x4a);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new Size(0x3f, 0x15);
            this.txtLeft.TabIndex = 0x1d;
            this.txtRight.Location = new Point(0xa6, 0x4a);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new Size(0x3f, 0x15);
            this.txtRight.TabIndex = 0x1c;
            this.txtForward.Location = new Point(0x35, 0x19);
            this.txtForward.Name = "txtForward";
            this.txtForward.Size = new Size(0x3f, 0x15);
            this.txtForward.TabIndex = 0x1b;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(20, 0x7a);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x1d, 12);
            this.label8.TabIndex = 0x1a;
            this.label8.Text = "停止";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x83, 0x4d);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x1d, 12);
            this.label7.TabIndex = 0x19;
            this.label7.Text = "右转";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x12, 0x4d);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1d, 12);
            this.label6.TabIndex = 0x18;
            this.label6.Text = "左转";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x83, 0x1c);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x1d, 12);
            this.label5.TabIndex = 0x17;
            this.label5.Text = "后退";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x12, 0x1c);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1d, 12);
            this.label4.TabIndex = 0x16;
            this.label4.Text = "前进";
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxControlPort);
            this.groupBox2.Controls.Add(this.textControlURL);
            this.groupBox2.Controls.Add(this.textBoxVideo);
            this.groupBox2.Location = new Point(12, 0x12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x18b, 0x53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WIFI设置";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xec, 0x37);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "控制端口";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(9, 0x37);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "控制地址";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "视频地址";
            this.textBoxControlPort.Location = new Point(0x127, 50);
            this.textBoxControlPort.Name = "textBoxControlPort";
            this.textBoxControlPort.Size = new Size(0x5b, 0x15);
            this.textBoxControlPort.TabIndex = 8;
            this.textControlURL.Location = new Point(0x44, 50);
            this.textControlURL.Name = "textControlURL";
            this.textControlURL.Size = new Size(0x83, 0x15);
            this.textControlURL.TabIndex = 7;
            this.textBoxVideo.Location = new Point(0x44, 0x15);
            this.textBoxVideo.Name = "textBoxVideo";
            this.textBoxVideo.Size = new Size(0x13e, 0x15);
            this.textBoxVideo.TabIndex = 6;
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.wangluo);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.wudao);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.bizhang);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.zhuiguang);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.hongwai);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.xunxian);
            this.groupBox3.Location = new Point(0x19d, 0x16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x9e, 0xf2);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模式指令";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(6, 0xda);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x35, 12);
            this.label17.TabIndex = 11;
            this.label17.Text = "网络模式";
            this.wangluo.Location = new Point(0x42, 0xd7);
            this.wangluo.Name = "wangluo";
            this.wangluo.Size = new Size(0x42, 0x15);
            this.wangluo.TabIndex = 10;
            this.label16.AutoSize = true;
            this.label16.Location = new Point(6, 0xb6);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x35, 12);
            this.label16.TabIndex = 9;
            this.label16.Text = "舞蹈模式";
            this.wudao.Location = new Point(0x42, 0xb3);
            this.wudao.Name = "wudao";
            this.wudao.Size = new Size(0x42, 0x15);
            this.wudao.TabIndex = 8;
            this.label15.AutoSize = true;
            this.label15.Location = new Point(6, 0x90);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x35, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "避障模式";
            this.bizhang.Location = new Point(0x42, 0x8d);
            this.bizhang.Name = "bizhang";
            this.bizhang.Size = new Size(0x42, 0x15);
            this.bizhang.TabIndex = 6;
            this.label14.AutoSize = true;
            this.label14.Location = new Point(6, 0x6b);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x35, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "追光模式";
            this.zhuiguang.Location = new Point(0x42, 0x68);
            this.zhuiguang.Name = "zhuiguang";
            this.zhuiguang.Size = new Size(0x42, 0x15);
            this.zhuiguang.TabIndex = 4;
            this.label13.AutoSize = true;
            this.label13.Location = new Point(6, 0x47);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x35, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "红外模式";
            this.hongwai.Location = new Point(0x42, 0x44);
            this.hongwai.Name = "hongwai";
            this.hongwai.Size = new Size(0x42, 0x15);
            this.hongwai.TabIndex = 2;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(6, 0x21);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x35, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "循线模式";
            this.xunxian.Location = new Point(0x42, 30);
            this.xunxian.Name = "xunxian";
            this.xunxian.Size = new Size(0x42, 0x15);
            this.xunxian.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x247, 0x130);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "Config";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "设置";
            base.Load += new EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            base.ResumeLayout(false);
        }

        public string ReadIni(string Section, string Ident, string Default)
        {
            byte[] Buffer = new byte[0xffff];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), this.FileName);
            return Encoding.GetEncoding(0).GetString(Buffer).Substring(0, bufLen).Trim();
        }

        public void WriteIni(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, Value, this.FileName))
            {
                throw new ApplicationException("写入配置文件出错");
            }
        }

        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}

