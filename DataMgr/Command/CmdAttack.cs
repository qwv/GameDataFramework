using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdAttack: Command
    {
        private CalPropsEntity attacker;
        private CalPropsEntity target;

        public CmdAttack()
        {
            message = base.GetType().Name;
            argsType = new Type[] { typeof(CalPropsEntity), typeof(CalPropsEntity) };
        }

        public override void Init(params object[] args)
        {
            attacker = (CalPropsEntity)args[0];
            target = (CalPropsEntity)args[1];

            message += " " + ((IAvater)args[0]).DebugTag();
            message += " " + ((IAvater)args[1]).DebugTag();
        }

        public override object Execute()
        {
            float damage = CalculateManager.Instance.Attack(attacker, target);
            message += " damage " + damage.ToString();
            return true;
        }

        public override RunType GetRunType()
        {
            return RunType.INTERVAL;
        }

        public override Priority GetPriority()
        {
            return Priority.NORMAL;
        }
    }
}
