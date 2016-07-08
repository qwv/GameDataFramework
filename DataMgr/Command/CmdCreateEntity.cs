
namespace Assets.Scripts.Data
{
    public class CmdCreateEntity : Command
    {
        EntityType type;
        object[] args;

        public CmdCreateEntity(EntityType type, params object[] args)
        {
            this.type = type;
            this.args = args;
        }

        public override object Execute(DataManager dataMgr)
        {
            return dataMgr.CreateEntity(type, args);
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
