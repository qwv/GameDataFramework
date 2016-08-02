using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdAddPlayerExp: Command
    {
        private PlayerEntity player;
        private int exp;
        private Notification levelUpNotification;

        public CmdAddPlayerExp() 
        {
            argsType = new Type[] { typeof(PlayerEntity), typeof(int)/*, typeof(Notification)*/ };
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

            if (player.exp >= player.ExpUp() && player.Level() < player.LevelMax())
            {
                player.exp -= player.ExpUp();

                PlayerBuilder.Instance.Build(player, player.Id(), player.Level() + 1);

                PackEntity equipmentPack = (PackEntity)ArchiveManager.Instance.GetEntity(player.equipmentPackName);
                if (equipmentPack != null)
                {
                    CalculateManager.Instance.EquipmentPackAddition(player, equipmentPack);
                }

                if (levelUpNotification != null)
                {
                    levelUpNotification();
                }
                message += " level up!";
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
