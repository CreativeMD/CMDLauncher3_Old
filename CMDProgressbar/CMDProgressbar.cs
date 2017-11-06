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
    public partial class CMDProgressbar : ProgressBar
    {
    
        private int FStepCount = 1;
        private int FStepIndex = 0;
        private int FStepPos = 0;
        private int FStepMax = 1;

        [Category("Data")]
        public int StepCount
        {
            get { return FStepCount; }
            set { this.FStepCount = value; refreshPosition(); }
        }

        [Category("Data")]
        public int StepIndex
        {
            get { return FStepIndex; }
            set { this.FStepIndex = value; refreshPosition(); }
        }

        [Category("Data")]
        public int StepPos {
            get { return FStepPos; }
            set { this.FStepPos = value; refreshPosition(); }
        }

        [Category("Data")]
        public int StepMax
        {
            get { return FStepMax; }
            set { this.FStepMax = value; refreshPosition(); }
        }

        private void refreshPosition()
        {
            Maximum = Width;
            float StepWidth = 0;
            if (FStepCount > 0)
                StepWidth = (float) Width / FStepCount;
            int tempPos = (int) (StepWidth * FStepIndex);
            if (FStepMax > 0)
                tempPos += (int) Math.Round(((double) FStepPos / (double) FStepMax) * StepWidth);

            if (tempPos != this.Value)
                this.Value = Math.Min(tempPos, Maximum);
        }

        public CMDProgressbar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        const int WmPaint = 15;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WmPaint:
                    using (var graphics = Graphics.FromHwnd(Handle))
                    {
                        base.WndProc(ref m);
                        //ProgressBarRenderer.DrawVerticalBar(graphics, ClientRectangle);

                        Pen pen = new Pen(Color.Black, 1);
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        float StepWidth = 0;
                        if (FStepCount > 0)
                            StepWidth = (float) Width / FStepCount;
                        for(int i = 1; i <= FStepCount; i++)
                            graphics.DrawLine(pen, new Point((int) (StepWidth * i), 0), new Point((int) (StepWidth * i), Height));
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
