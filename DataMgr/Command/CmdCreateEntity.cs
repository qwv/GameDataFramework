using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdCreateEntity : Command
    {
        private EntityType type;
        private object[] args;

        public CmdCreateEntity() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args">args[0]:<see cref="EntityType"/></param>
        public override bool Verify(params object[] args)
        {
            return true;
        }

        public override void Init(params object[] args)
        {
            this.type = (EntityType)args[0];
            this.args = new object[args.Length - 1]; 
            Array.Copy(args, 1, this.args, 0, args.Length - 1);
        }

        public override object Execute()
        {
            return EntityManager.Instance.CreateEntity(type, args);
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
