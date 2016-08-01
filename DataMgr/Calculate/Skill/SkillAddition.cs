
namespace Assets.Scripts.Data.Internal
{
    public class SkillAddition: CalPropsEntity
    {
        SkillEntity skill;

        public SkillAddition(CalPropsEntity calProps, SkillEntity skill) : base(calProps)
        {
            this.skill = skill;
        }

        public override float Atk()
        {
            return atk * skill.AtkMult() + skill.AtkAdd();
        }

        public override float AtkRay()
        {
            return atkRay * skill.AtkRayMult() + skill.AtkRayAdd();
        }

        public override float AtkIce()
        {
            return atkIce * skill.AtkIceMult() + skill.AtkIceAdd(); ;
        }

        public override float AtkFire()
        {
            return atkFire * skill.AtkFireMult() + skill.AtkFireAdd();
        }

        public override float AtkWind()
        {
            return atkWind * skill.AtkWindMult() + skill.AtkWindAdd();
        }
    }
}
