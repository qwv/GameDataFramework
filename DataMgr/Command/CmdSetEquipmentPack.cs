using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdSetEquipmentPack: Command
    {
        private PlayerEntity player;
        private string packName;

        public CmdSetEquipmentPack() 
        {
            argsType = new Type[] { typeof(PlayerEntity), typeof(string) };
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
