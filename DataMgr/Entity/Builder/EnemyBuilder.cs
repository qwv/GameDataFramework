
namespace Assets.Scripts.Data.Internal
{
    public class EnemyBuilder: Builder 
    {
        private static EnemyBuilder instance;

        public static EnemyBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new EnemyBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build enemy entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:enemy id</param>
        public override void Build(Entity entity, params object[] args)
        {
            EnemyEntity enemyEntity = (EnemyEntity)entity;

            int id = (int)args[0];
            PropertiesWrapper properties = DBProxy.Find(Table.ENEMY, "id", id.ToString());
            enemyEntity.properties = properties;
            CalPropsBuilder.Instance.Build(enemyEntity);
        }
    }
}
