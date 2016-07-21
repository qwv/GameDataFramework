
namespace Assets.Scripts.Data.Internal
{
    public class CmdAddPlayerExp: Command
    {
        private PlayerEntity player;
        private int exp;
        private Notification levelUpNotification;

        public CmdAddPlayerExp() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args">args[0]:attacker, args[1]:target</param>
        public override bool Verify(params object[] args)
        {
            content = "";
            return true;
        }

        public override void Init(params object[] args)
        {
            player = (PlayerEntity)args[0];
            exp = (int)args[1];
            levelUpNotification = (Notification)args[2];
        }

        public override object Execute()
        {
            player.exp += exp;
            if (player.exp >= player.ExpUp())
            {
                player.exp -= player.ExpUp();
                PlayerBuilder.Instance.Build(player, player.Id(), player.Level() + 1);
                if (player.equipmentPack != null)
                {
                    CalculateManager.Instance.EquipmentPackAddition(player, player.equipmentPack);
                }

                if (levelUpNotification != null)
                {
                    levelUpNotification();
                }
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
