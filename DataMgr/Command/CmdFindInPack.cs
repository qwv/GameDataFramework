using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdFindInPack : Command
    {
        private PackEntity pack;
        private Entity entity;

        public CmdFindInPack() 
        {
            message = base.GetType().Name;
            argsType = new Type[] { typeof(PackEntity), typeof(Entity) };
        }

        public override void Init(params object[] args)
        {
            pack = (PackEntity)args[0];
            entity = (Entity)args[1];

            message += " " + pack.DebugTag();
            message += " " + ((IAvater)args[1]).DebugTag();
        }

        public override object Execute()
        {
            return pack.Find(entity);
        }
    }
}
