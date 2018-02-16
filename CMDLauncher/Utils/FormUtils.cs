using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace CMDLauncher.Utils
{

    public abstract class HTMLControl
    {
        public readonly string id;
        public CefSharp.IFrame parent;

        public HTMLControl(CefSharp.IFrame parent, string id)
        {
            this.parent = parent;
            this.id = id;
        }

        public abstract HTMLControl Render(List<string> lines);

        public void RunCode(string code)
        {
            if(parent != null)
                parent.ExecuteJavaScriptAsync(code);
        }

        public virtual void SetParent(CefSharp.IFrame parent)
        {
            this.parent = parent;
        }

    }

    public class HTMLProgressBar : HTMLControl, IProgressBar
    {

        public int ProcessPos;
        public int ProcessMax = 0;
        public int StepPos;
        public int StepMax;
        
        public HTMLProgressBar(CefSharp.IFrame frame, string id) : base(frame, id)
        {

        }

        public override HTMLControl Render(List<string> lines)
        {
            lines.Add("<div class='cssProgress'>" +
                "<div class='progress2'>" +
                    "<div class='cssProgress-bar cssProgress-success cssProgress-active' id='" + id + "' data-percent='0' style='width: 0%;'> " +
                        "<span class='cssProgress-label' id='" + id + "_label'>0%</span>" +
	                "</div>" +
                "</div>" +
            "</div>");
            return this;
        }

        public override void SetParent(IFrame parent)
        {
            base.SetParent(parent);
            UpdateProgress();
        }

        public void UpdateProgress()
        {
            double progress;
            if (ProcessMax > 0)
            {
                progress = ProcessPos / (double) ProcessMax;
                if (StepMax > 0)
                    progress += (StepPos / (double)StepMax) / ProcessMax;
                progress *= 100;
            }
            else
                progress = 0;
            RunCode("$('#" + id + "').css('width', '" + progress + "%').attr('data-percent', " + progress + ");$('#" + id + "_label').text('" + ((int) progress) + "%');");
        }

        public void FinishStep()
        {
            if (StepMax > 0)
                StepPos = StepMax;
            else
                StepPos = StepMax = 1;
            UpdateProgress();
        }

        public void SetProgress(int progress)
        {
            if (progress < ProcessMax)
                ProcessPos = progress;
            else
                ProcessPos = ProcessMax;
            UpdateProgress();
        }

        public void StartProcess(int steps)
        {
            ProcessMax = steps;
            ProcessPos = 0;
            StepMax = 0;
            StepPos = 0;
            UpdateProgress();
        }

        public void StartStep(int max)
        {
            if(ProcessPos < ProcessMax)
                ProcessPos++;
            StepMax = max;
            StepPos = 0;
            UpdateProgress();
        }
    }
}
