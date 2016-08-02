using System;

namespace Assets.Scripts.Data.Internal
{
    public abstract class Command
    {
        public enum RunType
        {
            INSTANT = 0,
            INTERVAL = 1,
        }

        public enum Priority
        {
            HIGHEST = 0,
            HIGH = 1,
            NORMAL = 2,
            LOW = 3,
            LOWEST = 4,
            COUNT = LOWEST + 1,
        }

        public string message;

        protected Type[] argsType;

        public abstract void Init(params object[] args);

        public abstract object Execute();

        public virtual RunType GetRunType() { return RunType.INSTANT; }

        public virtual Priority GetPriority() { return Priority.NORMAL; }

        /// <summary>
        /// Verify command arguments
        /// </summary>
        /// <param name="args">args</param>
        public virtual bool Verify(params object[] args)
        {
            if (args.Length < argsType.Length)
            {
                Logger.LogError("Verify command: " + message + " argument num error, need " + argsType.Length + " given " + args.Length);
                return false;
            }

            for (int i = 0; i < argsType.Length; i++)
            {
                if (args[i] == null || !argsType[i].IsInstanceOfType(args[i]))
                {
                    Logger.LogError("Verify command: " + message + " argument " + i + " type error, need " + argsType[i].Name + " given " + args[i].GetType().Name);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Generate command message by arguments
        /// </summary>
        /// <param name="args">args</param>
        public virtual void GenerateMessage(params object[] args)
        {
            message = base.GetType().Name;

            foreach (object arg in args)
            {
                if (typeof(IAvater).IsInstanceOfType(arg))
                {
                    message += " " + ((IAvater)arg).DebugTag();
                }
                else
                {
                    message += " " + arg.ToString();
                }
            }
        }
    }
}
