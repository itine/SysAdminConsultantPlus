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
namespace VisualStudioWithConsole
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        
        void DoWork(object listBoxSelectedItem)
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Verb = "runas",
                    FileName = "cmd.exe",
                    Arguments = @"/k " + listBoxSelectedItem + "",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    StandardOutputEncoding = Encoding.GetEncoding(866),
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            if (!proc.StartInfo.RedirectStandardOutput)
                return;

            string line;
            StreamReader sr = proc.StandardOutput;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                textBox1.Invoke(new MethodInvoker(() =>
                {
                    textBox1.Text += line + "\r\r\n";
                }), null);
            }
            proc.Close();
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();

            if (listBox1.SelectedIndex == 0)
            {
                new Thread(DoWork).Start("netsh advfirewall firewall show rule name=all");
                return;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k netsh advfirewall set allprofiles state on";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "Брендмауэр включен";
                return;
            }
            else if (listBox1.SelectedIndex == 2)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k netsh advfirewall set allprofiles state off";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "Брендмауэр отключен";
                return;
            }
            else if (listBox1.SelectedIndex == 3)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k netsh advfirewall reset";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "Брандмауэр вернулся к установкам по умолчанию";
                return;
            }
            else if (listBox1.SelectedIndex == 4)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k " + "netsh advfirewall firewall add rule name=\"All ICMP V4\" dir=in action=block protocol=icmpv4 & netsh advfirewall firewall add rule name=\"All ICMP V4\" dir=in action=allow protocol=icmpv4";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "OK.";
                return;
            }
            else if (listBox1.SelectedIndex == 5)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k "+ "netsh advfirewall firewall add rule name=\"Allow Messenger\" dir=in action=allow program=" + textBox2.Text;
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "Программе разрешено работать";
                return;
            }
            else if (listBox1.SelectedIndex == 6)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k " + "netsh advfirewall firewall set rule group=\"remote administration\" new enable=yes";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "Удаленное управление разрешено";
                return;
            }
            else if (listBox1.SelectedIndex == 7)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "cmd.exe";
                StartInfo.Arguments = @"/k " + "netsh advfirewall firewall set rule group=\"remote desktop\" new enable=Yes";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
                textBox1.Text += "Подключение к удаленному рабочему столу завершено";
                return;
            }
            else if (listBox1.SelectedIndex == 8)
            {
                new Thread(DoWork).Start("" + textBox2.Text);
                return;
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}