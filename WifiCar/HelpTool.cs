namespace WifiCar
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class HelpTool : Form
    {
        private IContainer components = null;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private LinkLabel linkLabel1;

        public HelpTool()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(HelpTool));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.linkLabel1 = new LinkLabel();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x1f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序使用帮助:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x143, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "本软件为wifi网络智能小车以及多功能智能小车PC控制软件.";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x2b, 0x58);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x131, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "主要针对于自行设计的智能车的控制，同时也支持感兴趣";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1b, 0x74);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "朋友拓展使用。";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(12, 0x97);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "控制说明：";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x1d, 0xb6);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x11f, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "键盘按键W/A/S/D/X  分别对应软件的前/左/后/右/停";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x1f, 0xd4);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0xd7, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "键盘按键H/J/K  分别对应舵机左/中/右";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(12, 0xf3);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x3b, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "配置说明:";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x21, 0x10d);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0xd1, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "使用单字符ASCLL发送,可通过串口调试";
            this.label10.AutoSize = true;
            this.label10.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.label10.Location = new Point(0xca, 0x163);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x77, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "网站：WWW.HJMCU.COM";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0x23, 0x12d);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0xad, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "模式设置支持智能车多功能扩展";
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new Point(0x1f, 0x160);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x35, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "慧净电子";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x183, 0x178);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.linkLabel1);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.Name = "HelpTool";
            this.Text = "WifiCarHelp";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.hjmcu.com");
        }
    }
}

