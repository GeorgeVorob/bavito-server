using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        delegate void Del(string text);

        delegate void Message(string str); // 1. Объявляем делегат
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Message mes;
            mes = test;
            brain b = new brain(mes);
            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(b.Main));
            myThread.Start(); // запускаем поток
        }
        private void test(string str)
        {
            //   label1.Text += "\n"+str;
            textBox1.Invoke(new Del((s) => textBox1.Text += s), Environment.NewLine + str);
        }
    }
}
