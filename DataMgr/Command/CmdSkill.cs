using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdSkill: Command
    {
        private CalPropsEntity attacker;
        private CalPropsEntity target;
        private SkillEntity skill;

        public CmdSkill() 
        {
            message = base.GetType().Name;
            argsType = new Type[] { typeof(CalPropsEntity), typeof(CalPropsEntity), typeof(SkillEntity) };
        }

        public override void Init(params object[] args)
        {
            attacker = (CalPropsEntity)args[0];
            target = (CalPropsEntity)args[1];
            skill = (SkillEntity)args[2];

            message += " " + ((IAvater)args[0]).DebugTag();
            message += " " + ((IAvater)args[1]).DebugTag();
            message += " " + skill.DebugTag();
        }

        public override object Execute()
        {
            float damage = CalculateManager.Instance.Skill(attacker, target, skill);
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
