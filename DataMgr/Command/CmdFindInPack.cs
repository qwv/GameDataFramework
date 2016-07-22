
namespace Assets.Scripts.Data.Internal
{
    public class CmdFindInPack : Command
    {
        private PackEntity pack;
        private Entity entity;

        public CmdFindInPack() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args">args[0]:packvater, args[1]:entity avater</param>
        public override bool Verify(params object[] args)
        {
            content = "FindInPack";
            IAvater pack = (IAvater)args[0];
            if (pack.Type() != EntityType.PACK)
            {   
                //errorMessage = "args 0 is not a pack avater";
                return false;
            }
            return true;
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
