namespace WifiCar
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class WifiCar : Form
    {
        private Button btnEngineCenter;
        private Button btnEngineLeft;
        private Button btnEngineRight;
        private Button buttonBackward;
        private Button buttonForward;
        private Button buttonLeft;
        private Button buttonRight;
        private Button buttonStop;
        private Socket c;
        private string CameraIp = "";
        private Button CloseBtn;
        private string CMD_Backward = "";
        private string CMD_Bizhang = "";
        private string CMD_EngineCenter = "";
        private string CMD_EngineLeft = "";
        private string CMD_EngineRight = "";
        private string CMD_Forward = "";
        private string CMD_Hongwai = "";
        private string CMD_Stop = "";
        private string CMD_TurnLeft = "";
        private string CMD_TurnRight = "";
        private string CMD_Wangluo = "";
        private string CMD_Wudao = "";
        private string CMD_Xunxian = "";
        private string CMD_Zhuiguang = "";
        private IContainer components = null;
        private Button ConfigBtn;
        private Button ConnectBtn;
        private string ControlIp = "192.168.1.1";
        private RadioButton Dance_mode;
        private static string FileName = (Application.StartupPath + @"\Config.ini");
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ToolStripStatusLabel Helplable;
        private RadioButton IR_mode;
        private bool isConnect = false;
        private bool isOpen = false;
        private RadioButton light_control;
        private RadioButton Net_mode;
        private PictureBox pictureBox1;
        private string Port = "2001";
        private RadioButton Sleep_mode;
        private StatusStrip statusStrip1;
        private bool stopflag = true;
        private ToolStripStatusLabel SystemStatus;
        private System.Windows.Forms.Timer timer1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private RadioButton Tracking_mode;
        private RadioButton Ultrasonic_mode;
        private Button VideoBtn;

        public WifiCar()
        {
            this.InitializeComponent();
        }

        private void btnEngineCenter_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_EngineCenter);
        }

        private void btnEngineLeft_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_EngineLeft);
        }

        private void btnEngineRight_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_EngineRight);
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_Backward);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_Forward);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_Stop);
        }

        private void buttonTurnLeft_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_TurnLeft);
        }

        private void buttonTurnRight_Click(object sender, EventArgs e)
        {
            this.SendData(this.CMD_TurnRight);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否确定退出程序", "提示", MessageBoxButtons.YesNo))
            {
                base.Close();
            }
        }

        private void ConfigBtn_Click(object sender, EventArgs e)
        {
            new Config().ShowDialog();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (!this.isConnect)
            {
                try
                {
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(this.ControlIp.ToString()), Convert.ToInt32(this.Port.ToString()));
                    this.c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.c.Connect(ipe);
                    this.ConnectBtn.BackgroundImage = Image.FromFile(Application.StartupPath + "/Connect.png");
                    this.SystemStatus.Text = "远程连接成功！！！";
                    this.isConnect = true;
                }
                catch
                {
                    this.isConnect = false;
                    this.SystemStatus.Text = "远程连接失败！！！";
                }
            }
            else
            {
                try
                {
                    this.c.Close();
                    this.isConnect = false;
                    this.SystemStatus.Text = "远程连接以及断开！！！";
                    this.ConnectBtn.BackgroundImage = Image.FromFile(Application.StartupPath + "/DisConnect.png");
                }
                catch
                {
                    this.isConnect = true;
                    this.SystemStatus.Text = "远程连接断开失败！！！";
                }
            }
        }

        private void Dance_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.Dance_mode.Checked)
            {
                this.SendData(this.CMD_Wudao);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                this.buttonForward.BackColor = Color.DarkGray;
                this.buttonForward.PerformClick();
                this.stopflag = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                this.buttonBackward.BackColor = Color.DarkGray;
                this.buttonBackward.PerformClick();
                this.stopflag = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                this.buttonLeft.BackColor = Color.DarkGray;
                this.buttonLeft.PerformClick();
                this.stopflag = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                this.buttonRight.BackColor = Color.DarkGray;
                this.buttonRight.PerformClick();
                this.stopflag = true;
            }
            else if (e.KeyCode == Keys.X)
            {
                this.buttonStop.BackColor = Color.DarkGray;
                this.buttonStop.PerformClick();
                this.stopflag = true;
            }
            else if (e.KeyCode == Keys.K)
            {
                this.btnEngineCenter.BackColor = Color.DarkGray;
                this.btnEngineCenter.PerformClick();
                this.stopflag = false;
            }
            else if (e.KeyCode == Keys.J)
            {
                this.btnEngineRight.BackColor = Color.DarkGray;
                this.btnEngineRight.PerformClick();
                this.stopflag = false;
            }
            else if (e.KeyCode == Keys.H)
            {
                this.btnEngineLeft.BackColor = Color.DarkGray;
                this.btnEngineLeft.PerformClick();
                this.stopflag = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.stopflag)
            {
                this.buttonStop.PerformClick();
            }
            this.buttonForward.BackColor = Color.LightBlue;
            this.buttonBackward.BackColor = Color.LightBlue;
            this.buttonLeft.BackColor = Color.LightBlue;
            this.buttonRight.BackColor = Color.LightBlue;
            this.btnEngineCenter.BackColor = Color.LightBlue;
            this.btnEngineRight.BackColor = Color.LightBlue;
            this.btnEngineLeft.BackColor = Color.LightBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GetIni();
            this.buttonForward.BackColor = Color.LightBlue;
            this.buttonBackward.BackColor = Color.LightBlue;
            this.buttonLeft.BackColor = Color.LightBlue;
            this.buttonRight.BackColor = Color.LightBlue;
            this.buttonStop.BackColor = Color.LightBlue;
            this.btnEngineCenter.BackColor = Color.LightBlue;
            this.btnEngineRight.BackColor = Color.LightBlue;
            this.btnEngineLeft.BackColor = Color.LightBlue;
            this.Sleep_mode.Checked = true;
        }

        private void GetIni()
        {
            this.CameraIp = this.ReadIni("VideoUrl", "videoUrl", "");
            this.ControlIp = this.ReadIni("ControlUrl", "controlUrl", "");
            this.Port = this.ReadIni("ControlPort", "controlPort", "");
            this.CMD_Forward = this.ReadIni("ControlCommand", "CMD_Forward", "");
            this.CMD_Backward = this.ReadIni("ControlCommand", "CMD_Backward", "");
            this.CMD_TurnLeft = this.ReadIni("ControlCommand", "CMD_TurnLeft", "");
            this.CMD_TurnRight = this.ReadIni("ControlCommand", "CMD_TurnRight", "");
            this.CMD_Stop = this.ReadIni("ControlCommand", "CMD_Stop", "");
            this.CMD_EngineRight = this.ReadIni("ControlCommand", "CMD_EngineRight", "");
            this.CMD_EngineCenter = this.ReadIni("ControlCommand", "CMD_EngineCenter", "");
            this.CMD_EngineLeft = this.ReadIni("ControlCommand", "CMD_EngineLeft", "");
            this.CMD_Xunxian = this.ReadIni("ControlCommand", "CMD_Xunxian", "");
            this.CMD_Hongwai = this.ReadIni("ControlCommand", "CMD_Hongwai", "");
            this.CMD_Zhuiguang = this.ReadIni("ControlCommand", "CMD_Zhuiguang", "");
            this.CMD_Bizhang = this.ReadIni("ControlCommand", "CMD_Bizhang", "");
            this.CMD_Wudao = this.ReadIni("ControlCommand", "CMD_Wudao", "");
            this.CMD_Wangluo = this.ReadIni("ControlCommand", "CMD_Wangluo", "");
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        private void Helplable_Click(object sender, EventArgs e)
        {
            new HelpTool().ShowDialog();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(WifiCar.WifiCar));
            this.pictureBox1 = new PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new GroupBox();
            this.CloseBtn = new Button();
            this.ConnectBtn = new Button();
            this.btnEngineLeft = new Button();
            this.btnEngineRight = new Button();
            this.btnEngineCenter = new Button();
            this.buttonStop = new Button();
            this.ConfigBtn = new Button();
            this.buttonBackward = new Button();
            this.buttonRight = new Button();
            this.buttonLeft = new Button();
            this.buttonForward = new Button();
            this.VideoBtn = new Button();
            this.groupBox2 = new GroupBox();
            this.Sleep_mode = new RadioButton();
            this.Net_mode = new RadioButton();
            this.Dance_mode = new RadioButton();
            this.Ultrasonic_mode = new RadioButton();
            this.light_control = new RadioButton();
            this.IR_mode = new RadioButton();
            this.Tracking_mode = new RadioButton();
            this.statusStrip1 = new StatusStrip();
            this.SystemStatus = new ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new ToolStripStatusLabel();
            this.Helplable = new ToolStripStatusLabel();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            base.SuspendLayout();
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.Image = (Image) resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new Point(4, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(740, 0x1a7);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.timer1.Interval = 50;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.groupBox1.Controls.Add(this.CloseBtn);
            this.groupBox1.Controls.Add(this.ConnectBtn);
            this.groupBox1.Controls.Add(this.btnEngineLeft);
            this.groupBox1.Controls.Add(this.btnEngineRight);
            this.groupBox1.Controls.Add(this.btnEngineCenter);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.ConfigBtn);
            this.groupBox1.Controls.Add(this.buttonBackward);
            this.groupBox1.Controls.Add(this.buttonRight);
            this.groupBox1.Controls.Add(this.buttonLeft);
            this.groupBox1.Controls.Add(this.buttonForward);
            this.groupBox1.Controls.Add(this.VideoBtn);
            this.groupBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.groupBox1.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.groupBox1.Location = new Point(4, 0x1b9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1c0, 0xd8);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台";
            this.CloseBtn.BackgroundImage = (Image) resources.GetObject("CloseBtn.BackgroundImage");
            this.CloseBtn.BackgroundImageLayout = ImageLayout.Stretch;
            this.CloseBtn.Location = new Point(0x18a, 0x9e);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new Size(0x30, 0x30);
            this.CloseBtn.TabIndex = 0x15;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new EventHandler(this.CloseBtn_Click);
            this.ConnectBtn.BackgroundImage = (Image) resources.GetObject("ConnectBtn.BackgroundImage");
            this.ConnectBtn.BackgroundImageLayout = ImageLayout.Stretch;
            this.ConnectBtn.Location = new Point(0xd4, 0x9e);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new Size(0x30, 0x30);
            this.ConnectBtn.TabIndex = 20;
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new EventHandler(this.ConnectBtn_Click);
            this.btnEngineLeft.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnEngineLeft.Location = new Point(0x133, 0x1a);
            this.btnEngineLeft.Name = "btnEngineLeft";
            this.btnEngineLeft.Size = new Size(0x71, 0x22);
            this.btnEngineLeft.TabIndex = 0x13;
            this.btnEngineLeft.Text = "舵机左转(H)";
            this.btnEngineLeft.UseVisualStyleBackColor = true;
            this.btnEngineLeft.Click += new EventHandler(this.btnEngineLeft_Click);
            this.btnEngineRight.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnEngineRight.Location = new Point(0x133, 0x6b);
            this.btnEngineRight.Name = "btnEngineRight";
            this.btnEngineRight.Size = new Size(0x71, 0x22);
            this.btnEngineRight.TabIndex = 0x12;
            this.btnEngineRight.Text = "舵机右转(K)";
            this.btnEngineRight.UseVisualStyleBackColor = true;
            this.btnEngineRight.Click += new EventHandler(this.btnEngineRight_Click);
            this.btnEngineCenter.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnEngineCenter.Location = new Point(0x133, 0x42);
            this.btnEngineCenter.Name = "btnEngineCenter";
            this.btnEngineCenter.Size = new Size(0x71, 0x23);
            this.btnEngineCenter.TabIndex = 0x11;
            this.btnEngineCenter.Text = "舵机居中(J)";
            this.btnEngineCenter.UseVisualStyleBackColor = true;
            this.btnEngineCenter.Click += new EventHandler(this.btnEngineCenter_Click);
            this.buttonStop.BackgroundImage = (Image) resources.GetObject("buttonStop.BackgroundImage");
            this.buttonStop.BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonStop.Location = new Point(0x48, 0x4d);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new Size(0x40, 0x40);
            this.buttonStop.TabIndex = 0x10;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new EventHandler(this.buttonStop_Click);
            this.ConfigBtn.BackgroundImage = (Image) resources.GetObject("ConfigBtn.BackgroundImage");
            this.ConfigBtn.BackgroundImageLayout = ImageLayout.Stretch;
            this.ConfigBtn.Location = new Point(0x14f, 0x9e);
            this.ConfigBtn.Name = "ConfigBtn";
            this.ConfigBtn.Size = new Size(0x30, 0x30);
            this.ConfigBtn.TabIndex = 15;
            this.ConfigBtn.UseVisualStyleBackColor = true;
            this.ConfigBtn.Click += new EventHandler(this.ConfigBtn_Click);
            this.buttonBackward.BackgroundImage = (Image) resources.GetObject("buttonBackward.BackgroundImage");
            this.buttonBackward.BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonBackward.Location = new Point(0x47, 0x8e);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.Size = new Size(0x40, 0x40);
            this.buttonBackward.TabIndex = 14;
            this.buttonBackward.UseVisualStyleBackColor = true;
            this.buttonBackward.Click += new EventHandler(this.buttonBackward_Click);
            this.buttonRight.BackgroundImage = (Image) resources.GetObject("buttonRight.BackgroundImage");
            this.buttonRight.BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonRight.Location = new Point(0x88, 0x4d);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new Size(0x40, 0x40);
            this.buttonRight.TabIndex = 13;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new EventHandler(this.buttonTurnRight_Click);
            this.buttonLeft.BackgroundImage = (Image) resources.GetObject("buttonLeft.BackgroundImage");
            this.buttonLeft.BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonLeft.Location = new Point(8, 0x4d);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new Size(0x40, 0x40);
            this.buttonLeft.TabIndex = 12;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new EventHandler(this.buttonTurnLeft_Click);
            this.buttonForward.BackgroundImage = (Image) resources.GetObject("buttonForward.BackgroundImage");
            this.buttonForward.BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonForward.Location = new Point(0x48, 12);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new Size(0x40, 0x41);
            this.buttonForward.TabIndex = 11;
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new EventHandler(this.buttonForward_Click);
            this.VideoBtn.BackgroundImage = (Image) resources.GetObject("VideoBtn.BackgroundImage");
            this.VideoBtn.BackgroundImageLayout = ImageLayout.Stretch;
            this.VideoBtn.Location = new Point(0x111, 0x9e);
            this.VideoBtn.Name = "VideoBtn";
            this.VideoBtn.Size = new Size(0x30, 0x30);
            this.VideoBtn.TabIndex = 10;
            this.VideoBtn.UseVisualStyleBackColor = true;
            this.VideoBtn.Click += new EventHandler(this.VideoBtn_Click);
            this.groupBox2.Controls.Add(this.Sleep_mode);
            this.groupBox2.Controls.Add(this.Net_mode);
            this.groupBox2.Controls.Add(this.Dance_mode);
            this.groupBox2.Controls.Add(this.Ultrasonic_mode);
            this.groupBox2.Controls.Add(this.light_control);
            this.groupBox2.Controls.Add(this.IR_mode);
            this.groupBox2.Controls.Add(this.Tracking_mode);
            this.groupBox2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.groupBox2.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.groupBox2.Location = new Point(0x1ca, 0x1ba);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x117, 0xd7);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模式选择";
            this.Sleep_mode.AutoSize = true;
            this.Sleep_mode.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.Sleep_mode.ForeColor = Color.Red;
            this.Sleep_mode.Location = new Point(14, 0xa1);
            this.Sleep_mode.Name = "Sleep_mode";
            this.Sleep_mode.Size = new Size(110, 0x1d);
            this.Sleep_mode.TabIndex = 6;
            this.Sleep_mode.TabStop = true;
            this.Sleep_mode.Text = "休息模式";
            this.Sleep_mode.UseVisualStyleBackColor = true;
            this.Sleep_mode.CheckedChanged += new EventHandler(this.Sleep_mode_CheckedChanged);
            this.Net_mode.AutoSize = true;
            this.Net_mode.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.Net_mode.ForeColor = Color.Red;
            this.Net_mode.Location = new Point(0x95, 0x7c);
            this.Net_mode.Name = "Net_mode";
            this.Net_mode.Size = new Size(110, 0x1d);
            this.Net_mode.TabIndex = 5;
            this.Net_mode.TabStop = true;
            this.Net_mode.Text = "网络模式";
            this.Net_mode.UseVisualStyleBackColor = true;
            this.Net_mode.CheckedChanged += new EventHandler(this.Net_mode_CheckedChanged);
            this.Dance_mode.AutoSize = true;
            this.Dance_mode.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.Dance_mode.ForeColor = Color.Red;
            this.Dance_mode.Location = new Point(0x95, 0x57);
            this.Dance_mode.Name = "Dance_mode";
            this.Dance_mode.Size = new Size(110, 0x1d);
            this.Dance_mode.TabIndex = 4;
            this.Dance_mode.TabStop = true;
            this.Dance_mode.Text = "舞蹈模式";
            this.Dance_mode.UseVisualStyleBackColor = true;
            this.Dance_mode.CheckedChanged += new EventHandler(this.Dance_mode_CheckedChanged);
            this.Ultrasonic_mode.AutoSize = true;
            this.Ultrasonic_mode.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.Ultrasonic_mode.ForeColor = Color.Red;
            this.Ultrasonic_mode.Location = new Point(0x95, 0x33);
            this.Ultrasonic_mode.Name = "Ultrasonic_mode";
            this.Ultrasonic_mode.Size = new Size(110, 0x1d);
            this.Ultrasonic_mode.TabIndex = 3;
            this.Ultrasonic_mode.TabStop = true;
            this.Ultrasonic_mode.Text = "壁障模式";
            this.Ultrasonic_mode.UseVisualStyleBackColor = true;
            this.Ultrasonic_mode.CheckedChanged += new EventHandler(this.Ultrasonic_mode_CheckedChanged);
            this.light_control.AutoSize = true;
            this.light_control.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.light_control.ForeColor = Color.Red;
            this.light_control.Location = new Point(14, 0x7d);
            this.light_control.Name = "light_control";
            this.light_control.Size = new Size(110, 0x1d);
            this.light_control.TabIndex = 2;
            this.light_control.TabStop = true;
            this.light_control.Text = "追光模式";
            this.light_control.UseVisualStyleBackColor = true;
            this.light_control.CheckedChanged += new EventHandler(this.light_control_CheckedChanged);
            this.IR_mode.AutoSize = true;
            this.IR_mode.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.IR_mode.ForeColor = Color.Red;
            this.IR_mode.Location = new Point(14, 0x57);
            this.IR_mode.Name = "IR_mode";
            this.IR_mode.Size = new Size(110, 0x1d);
            this.IR_mode.TabIndex = 1;
            this.IR_mode.TabStop = true;
            this.IR_mode.Text = "红外遥控";
            this.IR_mode.UseVisualStyleBackColor = true;
            this.IR_mode.CheckedChanged += new EventHandler(this.IR_mode_CheckedChanged);
            this.Tracking_mode.AutoSize = true;
            this.Tracking_mode.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.Tracking_mode.ForeColor = Color.Red;
            this.Tracking_mode.Location = new Point(14, 0x33);
            this.Tracking_mode.Name = "Tracking_mode";
            this.Tracking_mode.Size = new Size(110, 0x1d);
            this.Tracking_mode.TabIndex = 0;
            this.Tracking_mode.TabStop = true;
            this.Tracking_mode.Text = "循线模式";
            this.Tracking_mode.UseVisualStyleBackColor = true;
            this.Tracking_mode.CheckedChanged += new EventHandler(this.Tracking_mode_CheckedChanged);
            this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.SystemStatus, this.toolStripStatusLabel1, this.toolStripStatusLabel2, this.Helplable });
            this.statusStrip1.Location = new Point(0, 0x296);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(0x2ed, 0x16);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            this.SystemStatus.ForeColor = Color.Red;
            this.SystemStatus.Image = (Image) resources.GetObject("SystemStatus.Image");
            this.SystemStatus.Name = "SystemStatus";
            this.SystemStatus.Size = new Size(120, 0x11);
            this.SystemStatus.Text = "系统运行状态消息";
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new Size(0x1e1, 0x11);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "慧净电子  ";
            this.toolStripStatusLabel1.Click += new EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel2.ForeColor = Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new Size(0x3d, 0x11);
            this.toolStripStatusLabel2.Text = "版本：2.0";
            this.Helplable.Image = (Image) resources.GetObject("Helplable.Image");
            this.Helplable.Name = "Helplable";
            this.Helplable.Size = new Size(0x48, 0x11);
            this.Helplable.Text = "使用帮助";
            this.Helplable.Click += new EventHandler(this.Helplable_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.ClientSize = new Size(0x2ed, 0x2ac);
            base.Controls.Add(this.statusStrip1);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.pictureBox1);
            base.HelpButton = true;
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.Name = "WifiCar";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "慧净电子网 WWW.HJMCU.COM";
            base.Load += new EventHandler(this.Form1_Load);
            base.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            base.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void IR_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.IR_mode.Checked)
            {
                this.SendData(this.CMD_Hongwai);
            }
        }

        private bool IsConnection()
        {
            if (this.isConnect)
            {
                return true;
            }
            this.SystemStatus.Text = "请检查连接是否开启！！";
            return false;
        }

        private void light_control_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.light_control.Checked)
            {
                this.SendData(this.CMD_Zhuiguang);
            }
        }

        private void Net_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.Net_mode.Checked)
            {
                this.SendData(this.CMD_Wangluo);
            }
        }

        public string ReadIni(string Section, string Ident, string Default)
        {
            byte[] Buffer = new byte[0xffff];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            return Encoding.GetEncoding(0).GetString(Buffer).Substring(0, bufLen).Trim();
        }

        private void SendData(string data)
        {
            try
            {
                byte[] bs = Encoding.ASCII.GetBytes(data);
                this.c.Send(bs, bs.Length, SocketFlags.None);
            }
            catch
            {
                this.SystemStatus.Text = "请检查连接是否开启！！";
            }
        }

        private void Sleep_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.Sleep_mode.Checked)
            {
                this.SendData(this.CMD_Stop);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.CameraIp;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.hjmcu.com");
        }

        private void Tracking_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.Tracking_mode.Checked)
            {
                this.SendData(this.CMD_Xunxian);
            }
        }

        private void Ultrasonic_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsConnection() && this.Ultrasonic_mode.Checked)
            {
                this.SendData(this.CMD_Bizhang);
            }
        }

        private void VideoBtn_Click(object sender, EventArgs e)
        {
            if (this.isConnect)
            {
                if (!this.isOpen)
                {
                    this.timer1.Enabled = true;
                    this.VideoBtn.BackColor = Color.LightBlue;
                    this.VideoBtn.BackgroundImage = Image.FromFile(Application.StartupPath + "/web_camera.png");
                    this.isOpen = true;
                }
                else
                {
                    this.timer1.Enabled = false;
                    this.VideoBtn.BackColor = Color.DarkGray;
                    this.VideoBtn.BackgroundImage = Image.FromFile(Application.StartupPath + "/web_cameraStop.png");
                    this.pictureBox1.ImageLocation = Application.StartupPath + "/car.jpg";
                    this.isOpen = false;
                }
            }
            else
            {
                MessageBox.Show("请检查是否连接网络！！");
            }
        }

        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}

