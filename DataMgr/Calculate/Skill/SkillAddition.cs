
namespace Assets.Scripts.Data.Internal
{
    public class SkillAddition: CalPropsEntity
    {
        CalPropsEntity calProps;
        SkillEntity skill;

        public SkillAddition(CalPropsEntity calProps, SkillEntity skill)
        {
            this.calProps = calProps;
            this.skill = skill;
        }

        public override float Atk()
        {
            return calProps.atk * skill.AtkMult() + skill.AtkAdd();
        }

        public override float AtkRay()
        {
            return calProps.atkRay * skill.AtkRayMult() + skill.AtkRayAdd();
        }

        public override float AtkIce()
        {
            return calProps.atkIce * skill.AtkIceMult() + skill.AtkIceAdd(); ;
        }

        public override float AtkFire()
        {
            return calProps.atkFire * skill.AtkFireMult() + skill.AtkFireAdd();
        }

        public override float AtkWind()
        {
            return calProps.atkWind * skill.AtkWindMult() + skill.AtkWindAdd();
        }
    }
}
