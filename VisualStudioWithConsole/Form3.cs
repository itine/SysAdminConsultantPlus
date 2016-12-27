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
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            if (listBox1.SelectedIndex == 0)
            {
                new Thread(DoWork).Start("-a");
                return;
            }
                else if (listBox1.SelectedIndex == 1)
                {
                    new Thread(DoWork).Start("-b");
                    return;
                }
                else if (listBox1.SelectedIndex == 2)
                {
                    new Thread(DoWork).Start("-e");
                    return;
                }
                else if (listBox1.SelectedIndex == 3)
                {
                    new Thread(DoWork).Start("-f");
                    return;
                }
                else if (listBox1.SelectedIndex == 4)
                {
                    new Thread(DoWork).Start("-n");
                    return;
                }
                else if (listBox1.SelectedIndex == 5)
                {
                    new Thread(DoWork).Start("-o");
                    return;
                }
                else if (listBox1.SelectedIndex == 6)
                {
                    new Thread(DoWork).Start("-p");
                    return;
                }
                else if (listBox1.SelectedIndex == 7)
                {
                    new Thread(DoWork).Start("-r");
                    return;
                }
                else if (listBox1.SelectedIndex == 8)
                {
                    new Thread(DoWork).Start("-s");
                    return;
                }
                else if (listBox1.SelectedIndex == 9)
                {
                    new Thread(DoWork).Start("-t");
                    return;
                }
                else if (listBox1.SelectedIndex == 10)
                {
                    new Thread(DoWork).Start("-x");
                    return;
                }
                else if (listBox1.SelectedIndex == 11)
                {
                    new Thread(DoWork).Start("-y");
                    return;
                }
                else if (listBox1.SelectedIndex == 12)
                {
                    new Thread(DoWork).Start(""+textBox2.Text);
                    return;
                }
              
        }
        void DoWork (object listBoxSelectedItem) {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Verb = "runas",
                    FileName = "cmd.exe",
                    Arguments = @"/k netstat " + listBoxSelectedItem + "",
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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
       
        
        }
    }

