using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher.Module
{

    public enum ModuleState
    {
        Unloaded,
        Loaded,
        Failed,
        Missing_Dependency
    }

    public class Module
    {

        private static Dictionary<string, Module> modules = new Dictionary<string, Module>();

        public static Module GetModule(string name)
        {
            return modules[name];
        }

        public readonly string Name;
        public ModuleState State { get; private set; }

        public readonly Module[] Dependencies;

        public Module(string Name, string[] Dependencies)
        {
            modules.Add(Name, this);
            this.Name = Name;
            this.Dependencies = new Module[Dependencies.Length];
            for (int i = 0; i < Dependencies.Length; i++)
                this.Dependencies[i] = GetModule(Dependencies[i]);

            State = ModuleState.Unloaded;
        }

        public void ChangeState(ModuleState State)
        {
            this.State = State;
        }
    }
}
