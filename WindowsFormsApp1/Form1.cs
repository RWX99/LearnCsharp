using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static bool IsRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsRunning) return;
            label1.Text = "0";
            progressBar1.Value = 0;
            progressBar1.Maximum = 30;
            new Thread(() =>
            {
                IsRunning = true;
                for (int i = 0; i < progressBar1.Maximum; i++)
                {
                    ShowMessager(i);
                }
                IsRunning = false;
            }).Start();
        }

        private void ShowMessager(int i)
        {
            richTextBox1.Invoke(new Action<string>(s =>
            {
                progressBar1.Value += 1;
                label1.Text = $"{i}";
                richTextBox1.AppendText(s + "\n");
            }), $"查找用户应用文件夹......{i}");
            richTextBox1.ScrollToCaret();
            Thread.Sleep(100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
