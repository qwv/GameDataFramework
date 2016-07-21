
namespace Assets.Scripts.Data.Internal
{
    public class CmdEnforceEquipment : Command
    {
        private PlayerEntity player;

        public CmdEnforceEquipment() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args"></param>
        public override bool Verify(params object[] args)
        {
            return true;
        }

        public override void Init(params object[] args)
        {
            player = (PlayerEntity)args[0];
        }

        public override object Execute()
        {
            if (player.equipmentPack != null)
            {
                CalculateManager.Instance.EquipmentPackAddition(player, player.equipmentPack);
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
