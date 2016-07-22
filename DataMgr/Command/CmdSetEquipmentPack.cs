
namespace Assets.Scripts.Data.Internal
{
    public class CmdSetEquipmentPack: Command
    {
        private PlayerEntity player;
        private string packName;

        public CmdSetEquipmentPack() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args">args[0]:attacker, args[1]:target</param>
        public override bool Verify(params object[] args)
        {
            content = "SetEquipmentPack";
            return true;
        }

        public override void Init(params object[] args)
        {
            player = (PlayerEntity)args[0];
            packName = (string)args[1];
        }

        public override object Execute()
        {
            Entity pack = ArchiveManager.Instance.GetEntity(packName);
            if (pack != null && pack.type == EntityType.PACK)
            {
                player.SetEquipmentPack(packName);
                return true;
            }
            return false;
        }
    }
}
