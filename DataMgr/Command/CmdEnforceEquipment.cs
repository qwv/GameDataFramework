using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdEnforceEquipment : Command
    {
        private PlayerEntity player;

        public CmdEnforceEquipment()
        {
            argsType = new Type[] { typeof(PlayerEntity) };
        }

        public override void Init(params object[] args)
        {
            player = (PlayerEntity)args[0];
        }

        public override object Execute()
        {
            PackEntity equipmentPack = (PackEntity)ArchiveManager.Instance.GetEntity(player.equipmentPackName);
            if (equipmentPack != null)
            {
                CalculateManager.Instance.EquipmentPackAddition(player, equipmentPack);
                return true;
            }
            return false;
        }

        public override RunType GetRunType()
        {
            return RunType.INTERVAL;
        }

        public override Priority GetPriority()
        {
            return Priority.HIGHEST;
        }
    }
}
