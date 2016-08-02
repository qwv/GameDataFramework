using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdFindInPack : Command
    {
        private PackEntity pack;
        private Entity entity;

        public CmdFindInPack() 
        {
            argsType = new Type[] { typeof(PackEntity), typeof(Entity) };
        }

        public override void Init(params object[] args)
        {
            pack = (PackEntity)args[0];
            entity = (Entity)args[1];
        }

        public override object Execute()
        {
            return pack.Find(entity);
        }
    }
}
