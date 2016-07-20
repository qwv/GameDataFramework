
namespace Assets.Scripts.Data.Internal
{
    public class CmdSkill: Command
    {
        private CalPropsEntity attacker;
        private CalPropsEntity target;
        private SkillEntity skill;

        public CmdSkill() { }

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
            attacker = (CalPropsEntity)args[0];
            target = (CalPropsEntity)args[1];
            skill = (SkillEntity)args[2];
        }

        public override object Execute()
        {
            CalculateManager.Instance.Skill(attacker, target, skill);
            return null;
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
