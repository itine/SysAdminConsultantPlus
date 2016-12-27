using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Security.Principal;

namespace VisualStudioWithConsole
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.Verb = "runas";
            StartInfo.FileName = "cmd.exe";
            StartInfo.Arguments = @"/k netsh wlan set hostednetwork mode=allow ssid=" + textBox1.Text + " key=" + textBox2.Text +" & netsh wlan start hostednetwork";
            StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(StartInfo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.Verb = "runas";
            StartInfo.FileName = "cmd.exe";
            StartInfo.Arguments = @"/k netsh wlan stop hostednetwork";
            StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(StartInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Visible = false;
            form1.Show();
        } 
        }
    }
