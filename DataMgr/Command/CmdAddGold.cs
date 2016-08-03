using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdAddGold: Command
    {
        private GoldEntity store;
        private GoldEntity add;

        public CmdAddGold() 
        {
            argsType = new Type[] { typeof(GoldEntity), typeof(GoldEntity) };
        }

        public override void Init(params object[] args)
        {
            store = (GoldEntity)args[0];
            add = (GoldEntity)args[1];
        }

        public override object Execute()
        {
            store.gold += add.gold;
            return store.gold;
        }
    }
}
