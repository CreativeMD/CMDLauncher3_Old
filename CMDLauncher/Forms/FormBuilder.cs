using CMDLauncher.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher.Utils
{
    public abstract class FormBuilder
    {

        public readonly string Name;
        public string Title;
        public FormBase form;

        public FormBuilder(string Name, string Title)
        {
            this.Name = Name;
            this.Title = Title;
        }

        public void SetupForm(FormBase form)
        {
            form.Text = Title;
            this.form = form;
        }

        public FormBase Build()
        {
            FormBase form = new FormBase(this);
            SetupForm(form);
            return form;
        }

        public string Load()
        {
            List<String> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(Core.HTMLFolder + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "header"));

            LoadPage(lines);

            lines.Add("</body></html>");
            File.WriteAllLines(Core.HTMLFolder + this.Name, lines.ToArray());
            return "file:///" + Core.HTMLFolder + this.Name;
        }

        public abstract void LoadPage(List<string> lines);

        public virtual void AfterLoad()
        {

        }

    }
}
