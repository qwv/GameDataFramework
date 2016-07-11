
namespace Assets.Scripts.Data.Internal
{
    public class CmdCreateEntity : Command
    {
        EntityType type;
        object[] args;

        public CmdCreateEntity() { }

        /// <summary>
        /// Command create entity
        /// </summary>
        /// <param name="args">args[0]:entity type</param>
        public CmdCreateEntity(params object[] args)
        {
            Init(args);
        }

        public override void Init(params object[] args)
        {
            this.type = (EntityType)args[0];
            this.args = args;
        }

        public override object Execute()
        {
            return DataManager.Instance.CreateEntity(type, args);
        }

        public override RunType GetRunType()
        {
            return RunType.INSTANT;
        }

        public override Priority GetPriority()
        {
            return Priority.NORMAL;
        }
    }
}
