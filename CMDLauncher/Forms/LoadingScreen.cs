using CMDLauncher.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDLauncher.Forms
{
    public class LoadingScreen : FormBuilder
    {

        public TaskManager manager;
        public HTMLProgressBar bar;

        public LoadingScreen(List<Task> tasks, string Name, string Title) : base(Name, Title)
        {
            this.bar = new HTMLProgressBar(null, "loading_bar");
            this.manager = new OrdinaryTaskManager(null, tasks, bar);
            this.manager.StartTaskEvent = OnTaskStart;
        }

        public override void LoadPage(List<string> lines)
        {
            lines.Add("<span id='update_text'>Loading ...</span>");
            bar.Render(lines);
        }

        public void UpdateText(string text)
        {
            if(form != null)
                form.chrome.GetBrowser().MainFrame.ExecuteJavaScriptAsync("$('#update_text').html('" + text + "');");
        }

        public override void AfterLoad()
        {
            base.AfterLoad();
            bar.SetParent(form.chrome.GetBrowser().MainFrame);
            manager.Start();            
        }

        public void OnTaskStart(TaskManager manager, Task task)
        {
            UpdateText(task.title + " ...");
        }
    }
}
