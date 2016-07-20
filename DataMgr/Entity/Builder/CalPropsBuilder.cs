
namespace Assets.Scripts.Data.Internal
{
    public class CalPropsBuilder: Builder 
    {
        private static CalPropsBuilder instance;

        public static CalPropsBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new CalPropsBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build calProps entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args"></param>
        public override void Build(Entity entity, params object[] args)
        {
            CalPropsEntity calPropsEntity = (CalPropsEntity)entity;

            PropertiesWrapper properties = entity.properties;
            calPropsEntity.hpMax = properties.GetFloatValue(EnemyEntity.PropName.HP_MAX);
            calPropsEntity.atk = properties.GetFloatValue(EnemyEntity.PropName.ATK);
            calPropsEntity.atkRay = properties.GetFloatValue(EnemyEntity.PropName.ATK_RAY);
            calPropsEntity.atkIce = properties.GetFloatValue(EnemyEntity.PropName.ATK_ICE);
            calPropsEntity.atkFire = properties.GetFloatValue(EnemyEntity.PropName.ATK_FIRE);
            calPropsEntity.atkWind = properties.GetFloatValue(EnemyEntity.PropName.ATK_WIND);
            calPropsEntity.def = properties.GetFloatValue(EnemyEntity.PropName.DEF);
            calPropsEntity.defRay = properties.GetFloatValue(EnemyEntity.PropName.DEF_RAY);
            calPropsEntity.defIce = properties.GetFloatValue(EnemyEntity.PropName.DEF_ICE);
            calPropsEntity.defFire = properties.GetFloatValue(EnemyEntity.PropName.DEF_FIRE);
            calPropsEntity.defWind = properties.GetFloatValue(EnemyEntity.PropName.DEF_WIND);
            calPropsEntity.crit = properties.GetFloatValue(EnemyEntity.PropName.CRIT);
            calPropsEntity.critMult = properties.GetFloatValue(EnemyEntity.PropName.CRIT_MULT);
        }
    }
}
