
namespace Assets.Scripts.Data.Internal
{
    public class CalculateManager
    {
        private static CalculateManager instance;

        public static CalculateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CalculateManager();
                }
                return instance;
            }
        }

        private CalculateManager()
        {
        }

        public void PropertiesAddition(ref CalPropsEntity target, CalPropsEntity calProps)
        {
            target += calProps;
        }

        public void EquipmentPackAddition(CalPropsEntity target, PackEntity pack)
        {
            CalPropsBuilder.Instance.Build(target);

            for (int i = 0; i < pack.capacity; i++)
            {
                CellEntity cell = pack.Get(i);
                if (cell.stack > 0 && (cell.goods.type == EntityType.EQUIPMENT ||
                                       cell.goods.type == EntityType.ITEM))
                {
                    PropertiesAddition(ref target, (CalPropsEntity)cell.goods);
                }
            }
        }

        public float Attack(CalPropsEntity attacker, CalPropsEntity target)
        {
            DamageFormula formula = new DamageFormula();
            formula.Calculate(attacker, target);
            target.SubHp(formula.Result);
            return formula.Result;
        }

        public float Skill(CalPropsEntity attacker, CalPropsEntity target, SkillEntity skill)
        {
            DamageFormula formula = new DamageFormula();
            formula.Calculate(new SkillAddition(attacker, skill), target);
            target.SubHp(formula.Result);
            return formula.Result;
        }
    }
}
