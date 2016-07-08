
namespace Assets.Scripts.Data
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

        public abstract RunType GetRunType();

        public abstract Priority GetPriority();

        public abstract object Execute();
    }
}
