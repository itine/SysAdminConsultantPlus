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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        void DoWork(object listBoxSelectedItem)
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = @"/k ipconfig " + listBoxSelectedItem + "",
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
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            if (listBox1.SelectedIndex == 0)
            {
                new Thread(DoWork).Start("");
                return;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                new Thread(DoWork).Start("/all");
                return;
            }
            else if (listBox1.SelectedIndex == 2)
            {
                new Thread(DoWork).Start("/renew");
                return;
            }
            else if (listBox1.SelectedIndex == 3)
            {
                new Thread(DoWork).Start("/renew " + textBox2.Text);
                return;
            }
            else if (listBox1.SelectedIndex == 4)
            {
                new Thread(DoWork).Start("/release " + textBox2.Text);
                return;
            }
            else if (listBox1.SelectedIndex == 5)
            {
                new Thread(DoWork).Start("/allcompartments");
                return;
            }
            else if (listBox1.SelectedIndex == 6)
            {
                new Thread(DoWork).Start("/allcompartments /all");
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
