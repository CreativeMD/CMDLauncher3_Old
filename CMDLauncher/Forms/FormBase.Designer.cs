namespace CMDLauncher.Forms
{
    partial class FormBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.launcherIcons = new System.Windows.Forms.ImageList(this.components);
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
            // pInstances
            // 
            this.pInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pInstances.Location = new System.Drawing.Point(0, 0);
            this.pInstances.Name = "pInstances";
            this.pInstances.Size = new System.Drawing.Size(685, 474);
            this.pInstances.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 474);
            this.Controls.Add(this.pInstances);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList launcherIcons;
        private System.Windows.Forms.Panel pInstances;
    }
}

