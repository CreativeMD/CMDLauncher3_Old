using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMDLauncher.Utils
{
    public interface IProgressBar
    {

        void StartProcess(int steps);

        void FinishStep();

        void StartStep(int max);

        void SetProgress(int progress);

    }

    public delegate void TaskManagerEvent(TaskManager manager);

    public delegate void TaskEvent(TaskManager manager, Task task);

    public abstract class LoggingObject
    {
        public LoggingObject parent;

        protected Logger logger;

        public LoggingObject(Logger logger)
        {
            this.logger = logger;
        }

        public Logger Log { get { return parent != null ? parent.Log : logger != null ? logger : Core.MainLog; } }

    }

    public abstract class TaskManager : LoggingObject
    {
        protected Thread process;
        protected List<Task> tasks;
        protected Stopwatch watch;

        public IProgressBar bar;

        public TaskManagerEvent StartEvent;
        public TaskEvent StartTaskEvent;
        public TaskEvent FinishTaskEvent;
        public TaskManagerEvent FinishEvent;
        public TaskManagerEvent NoTaskFoundEvent;

        public Task CurrentTask { get; private set; }
        public bool Idle { get; private set; }
        public bool Active { get; private set; }

        public abstract bool Continuous { get; }

        public TaskManager(Logger logger, List<Task> tasks, IProgressBar bar) : base(logger)
        {
            this.Active = true;
            this.Idle = false;
            this.tasks = tasks != null ? tasks : new List<Task>();
            this.bar = bar;
            this.watch = new Stopwatch();
            process = new Thread(() =>
            {
                Run();
            });
        }

        public void Start()
        {
            process.Start();
        }

        public void AddTask(Task task)
        {
            if (Continuous)
                this.tasks.Add(task);
        }

        protected void OnStart()
        {
            StartEvent?.Invoke(this);
        }

        protected void OnStartTask(Task task)
        {
            StartTaskEvent?.Invoke(this, task);
        }

        protected void OnFinishTask(Task task)
        {
            FinishTaskEvent?.Invoke(this, task);
        }

        protected void OnFinish()
        {
            FinishEvent?.Invoke(this);
        }

        protected void OnNoTaskFound()
        {
            NoTaskFoundEvent?.Invoke(this);
        }

        protected void RunTask(Task task)
        {

        }

        protected void Run()
        {
            bar.StartProcess(tasks.Count);

            OnStart();

            while (!Core.Terminated && (Continuous || tasks.Count > 0))
            {
                if (Core.CloseLauncher)
                    goto TerminateManager;

                if (tasks.Count > 0)
                {
                    CurrentTask = tasks[0];

                    OnStartTask(CurrentTask);
                    Stopwatch watch = Stopwatch.StartNew();
                    try
                    {

                        /*if (CurrentTask.CanBeThreaded()) Not supported yet!!!
                        {

                        }
                        else
                        {

                        }*/

                        RunTask(CurrentTask);
                    }
                    catch (Exception e)
                    {
                        Log.Log("An error occurred! Please report this on github! {0}", e.Message);
                    }

                    watch.Stop();
                    Log.Log("Finished task in " + StringUtils.ToString(watch.Elapsed));

                    OnFinishTask(CurrentTask);
                    bar.FinishStep();

                    tasks.RemoveAt(0);
                }
                else
                {
                    if (CurrentTask != null)
                        OnNoTaskFound();
                    CurrentTask = null;
                    Idle = true;
                }
            }

            TerminateManager:
            Active = false;
        }

        public Thread Process { get { return process; } }

    }

    public class OrdinaryTaskManager : TaskManager
    {
        public OrdinaryTaskManager(Logger logger, List<Task> tasks, IProgressBar bar) : base(logger, tasks, bar)
        {

        }

        public override bool Continuous => true;
    }

    public abstract class Task : LoggingObject
    {
        private static List<Type> RunningTasks = new List<Type>();

        public static bool IsTaskRunning(Type taskType)
        {
            return RunningTasks.Contains(taskType);
        }

        public static bool AddRunningTask(Type taskType)
        {
            if (!RunningTasks.Contains(taskType))
            {
                RunningTasks.Add(taskType);
                return true;
            }
            return false;
        }

        public static bool RemoveRunningTask(Type taskType)
        {
            return RunningTasks.Remove(taskType);
        }

        public String title;

        public Task(String title) : base(null)
        {
            this.title = title;
        }

        protected abstract bool RunTask(IProgressBar bar);

        public virtual bool Run(IProgressBar bar, bool online, bool threaded)
        {
            if(RequiresInternetConnection() && !online)
            {
                Log.Log("This task requires an internet connection, but launcher is running in offline mode!");
                return false;
            }

            if(!CanBeThreaded() && threaded)
            {
                Log.Log("This task cannot be threaded!");
                return false;
            }

            if(!CanDoMultiTasking())
            {
                bool sendMessage = false;
                while (!Core.CloseLauncher && AddRunningTask(this.GetType()))
                {
                    if(!sendMessage)
                    {
                        Log.Log("Waiting for the other task to finish!");
                        sendMessage = true;
                    }
                    Thread.Sleep(1);
                }
            }

            if (Core.CloseLauncher)
                return false;

            bool value = RunTask(bar);
            if (!CanDoMultiTasking())
                RemoveRunningTask(this.GetType());

            return value;
    }

        public abstract bool CanDoMultiTasking();
        public abstract bool CanBeThreaded();
        public abstract bool RequiresInternetConnection();
    }
}
