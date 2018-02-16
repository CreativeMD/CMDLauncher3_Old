using CefSharp;
using CefSharp.WinForms;
using CMDLauncher.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMDLauncher.Forms
{
    public partial class FormBase : Form
    {

        public FormBuilder builder;
        public ChromiumWebBrowser chrome;

        public FormBase(FormBuilder builder)
        {
            InitializeComponent();
            this.builder = builder;
        }

        public void LoadBuilder(FormBuilder builder)
        {
            this.builder = builder;
            this.builder.SetupForm(this);
            chrome.Load(builder.Load());
            builder.AfterLoad();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            chrome = new ChromiumWebBrowser(builder.Load());
            this.pInstances.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.FrameLoadEnd += Loaded;
        }
        
        public virtual void Loaded(object sender, FrameLoadEndEventArgs args)
        {
            builder.AfterLoad();
        }
        
    }
}
