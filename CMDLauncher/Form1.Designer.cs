namespace CMDLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Create", 4);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Launch", 14);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Edit", 10);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Remove", 19);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Settings", 22);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Reload", 17);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Accounts", 0);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Import", 11);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("About", 5);
            this.launcherIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmdProgressbar1 = new CMDLauncher.CMDProgressbar();
            this.pInstances = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // launcherIcons
            // 
            this.launcherIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("launcherIcons.ImageStream")));
            this.launcherIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.launcherIcons.Images.SetKeyName(0, "Account.png");
            this.launcherIcons.Images.SetKeyName(1, "Changelog.png");
            this.launcherIcons.Images.SetKeyName(2, "ClientServer.png");
            this.launcherIcons.Images.SetKeyName(3, "Console.png");
            this.launcherIcons.Images.SetKeyName(4, "Create.png");
            this.launcherIcons.Images.SetKeyName(5, "CreativeMD.png");
            this.launcherIcons.Images.SetKeyName(6, "Credit.png");
            this.launcherIcons.Images.SetKeyName(7, "Design.png");
            this.launcherIcons.Images.SetKeyName(8, "Diagram.png");
            this.launcherIcons.Images.SetKeyName(9, "Edit.png");
            this.launcherIcons.Images.SetKeyName(10, "EditG.png");
            this.launcherIcons.Images.SetKeyName(11, "Import.png");
            this.launcherIcons.Images.SetKeyName(12, "Java.png");
            this.launcherIcons.Images.SetKeyName(13, "Launch.png");
            this.launcherIcons.Images.SetKeyName(14, "LaunchG.png");
            this.launcherIcons.Images.SetKeyName(15, "Mail.png");
            this.launcherIcons.Images.SetKeyName(16, "Minecraft.png");
            this.launcherIcons.Images.SetKeyName(17, "Reload.png");
            this.launcherIcons.Images.SetKeyName(18, "Remove.png");
            this.launcherIcons.Images.SetKeyName(19, "RemoveG.png");
            this.launcherIcons.Images.SetKeyName(20, "Resourcepack.png");
            this.launcherIcons.Images.SetKeyName(21, "Screenshot.png");
            this.launcherIcons.Images.SetKeyName(22, "Settings.png");
            this.launcherIcons.Images.SetKeyName(23, "Shader.png");
            this.launcherIcons.Images.SetKeyName(24, "User.png");
            this.launcherIcons.Images.SetKeyName(25, "Warning.png");
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(5, 51);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(55, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "${version}";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.GridLines = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            listViewItem8.StateImageIndex = 0;
            listViewItem9.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.listView1.LargeImageList = this.launcherIcons;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(486, 47);
            this.listView1.TabIndex = 3;
            this.listView1.TileSize = new System.Drawing.Size(40, 40);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // cmdProgressbar1
            // 
            this.cmdProgressbar1.BackColor = System.Drawing.SystemColors.Control;
            this.cmdProgressbar1.Location = new System.Drawing.Point(345, 366);
            this.cmdProgressbar1.Maximum = 135;
            this.cmdProgressbar1.Name = "cmdProgressbar1";
            this.cmdProgressbar1.Size = new System.Drawing.Size(135, 20);
            this.cmdProgressbar1.Step = 0;
            this.cmdProgressbar1.StepCount = 10;
            this.cmdProgressbar1.StepIndex = 0;
            this.cmdProgressbar1.StepMax = 1;
            this.cmdProgressbar1.StepPos = 0;
            this.cmdProgressbar1.TabIndex = 0;
            // 
            // pInstances
            // 
            this.pInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pInstances.Location = new System.Drawing.Point(8, 77);
            this.pInstances.Name = "pInstances";
            this.pInstances.Size = new System.Drawing.Size(466, 274);
            this.pInstances.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 391);
            this.Controls.Add(this.pInstances);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.cmdProgressbar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CMDProgressbar cmdProgressbar1;
        private System.Windows.Forms.ImageList launcherIcons;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel pInstances;
    }
}

