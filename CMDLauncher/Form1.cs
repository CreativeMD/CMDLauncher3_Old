using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMDLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        ChromiumWebBrowser chrome;

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            chrome = new ChromiumWebBrowser("http://google.de");
            this.pInstances.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmdProgressbar1.StepIndex++;
        }
    }
}
