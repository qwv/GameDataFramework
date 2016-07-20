
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

        public new float Atk()
        {
            return calProps.atk * skill.AtkMult() + skill.AtkAdd();
        }

        public new float AtkRay()
        {
            return calProps.atkRay * skill.AtkRayMult() + skill.AtkRayAdd();
        }

        public new float AtkIce()
        {
            return calProps.atkIce * skill.AtkIceMult() + skill.AtkIceAdd(); ;
        }

        public new float AtkFire()
        {
            return calProps.atkFire * skill.AtkFireMult() + skill.AtkFireAdd();
        }

        public new float AtkWind()
        {
            return calProps.atkWind * skill.AtkWindMult() + skill.AtkWindAdd();
        }
    }
}
