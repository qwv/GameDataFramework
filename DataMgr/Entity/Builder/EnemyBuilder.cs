
namespace Assets.Scripts.Data.Internal
{
    public class EnemyBuilder: Builder 
    {
        private Collection collection = new Collection();

        private static EnemyBuilder instance;

        public static EnemyBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new EnemyBuilder();
                    instance.collection.Load(ConfigTablePath.ENEMY_SOURCE);
                }
                return instance;
            }
        }

        /// <summary>
        /// Build enemy entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:entity type, args[1]:enemy id</param>
        public override void Build(Entity entity, params object[] args)
        {
            EnemyEntity enemyEntity = (EnemyEntity)entity;

            int id = (int)args[1];
            Properties properties = collection.Get(id);
            enemyEntity.properties = properties;
            enemyEntity.id = properties.GetIntValue(EnemyEntity.PropName.ID);
            enemyEntity.name = properties.GetStringValue(EnemyEntity.PropName.NAME);
            enemyEntity.level = properties.GetIntValue(EnemyEntity.PropName.LEVEL);
            enemyEntity.hp = properties.GetFloatValue(EnemyEntity.PropName.HP);
            enemyEntity.atk = properties.GetFloatValue(EnemyEntity.PropName.ATK);
            enemyEntity.atkRay = properties.GetFloatValue(EnemyEntity.PropName.ATK_RAY);
            enemyEntity.atkIce = properties.GetFloatValue(EnemyEntity.PropName.ATK_ICE);
            enemyEntity.atkFire = properties.GetFloatValue(EnemyEntity.PropName.ATK_FIRE);
            enemyEntity.atkWind = properties.GetFloatValue(EnemyEntity.PropName.ATK_WIND);
            enemyEntity.def = properties.GetFloatValue(EnemyEntity.PropName.DEF);
            enemyEntity.defRay = properties.GetFloatValue(EnemyEntity.PropName.DEF_RAY);
            enemyEntity.defIce = properties.GetFloatValue(EnemyEntity.PropName.DEF_ICE);
            enemyEntity.defFire = properties.GetFloatValue(EnemyEntity.PropName.DEF_FIRE);
            enemyEntity.defWind = properties.GetFloatValue(EnemyEntity.PropName.DEF_WIND);
            enemyEntity.crit = properties.GetFloatValue(EnemyEntity.PropName.CRIT);
            enemyEntity.critRate = properties.GetFloatValue(EnemyEntity.PropName.CRIT_RATE);
        }
    }
}
