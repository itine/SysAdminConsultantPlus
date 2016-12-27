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
using System.Web;
using System.Security.Principal;
namespace VisualStudioWithConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            ListBox innerListBox = listBox1;
            if (innerListBox.SelectedIndex == 0)
            {
                if (textBox2.TextLength > 0)
                    new Thread(DoWork).Start("ping");
                else
                {
                    textBox1.Text += "Введите IP";
                    return;
                } 
                return;
            }
            else if (innerListBox.SelectedIndex == 1)
            {
                if (textBox2.TextLength > 0)
                    new Thread(DoWork).Start("tracert");
                else
                {
                    textBox1.Text += "Введите IP";
                    return;
                }
                return;
            }
            else if (innerListBox.SelectedIndex == 2)
            {
                textBox2.Clear();
                new Thread(DoWork).Start("ipconfig");
            }
            else if (innerListBox.SelectedIndex == 3)
            {
                Form2 form2 = new Form2();
                this.Visible = false;
                form2.Show();
            }
            else if (innerListBox.SelectedIndex == 4)
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.Verb = "runas";
                StartInfo.FileName = "chrome.exe";
                StartInfo.Arguments = @"http://192.168.0.101/cgi-bin/wappaint?camera_no=0&animation=1&name=sergey&password=150195&time=0&pic_size=11111";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
            }
            else if (innerListBox.SelectedIndex == 5)
            {
                Form3 form3 = new Form3();
                this.Visible = false;
                form3.Show();
            }
            else if (innerListBox.SelectedIndex == 6)
            {
                Form4 form4 = new Form4();
                this.Visible = false;
                form4.Show();
            }
            else if (innerListBox.SelectedIndex == 7)
            {
                Form5 form5 = new Form5();
                this.Visible = false;
                form5.Show();
            }
            
        }
        void DoWork (object listBox1SelectedItem) {
            Process proc = new Process() {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c " + listBox1SelectedItem + " " + textBox2.Text)
                {
                    StandardOutputEncoding = Encoding.GetEncoding(866),
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            proc.Start();
            if (!proc.StartInfo.RedirectStandardOutput)
                return;
 
            string line;
            StreamReader sr = proc.StandardOutput;
 
            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                textBox1.Invoke(new MethodInvoker(() => {
                    textBox1.Text += line + "\r\r\n";
                }), null);
            }
            proc.Close();
        }

        }
}

