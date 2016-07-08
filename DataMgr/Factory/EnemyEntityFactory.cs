
namespace Assets.Scripts.Data
{
    public class EnemyEntityFactory : EntityFactory
    {
        private DataCollection collection = new DataCollection();

        private static EnemyEntityFactory instance;

        public static EnemyEntityFactory Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new EnemyEntityFactory();
                    instance.collection.Init(ConfigTablePath.ENEMY_SOURCE);
                }
                return instance;
            }
        }

        public override Entity Create(int entityId, params object[] args)
        {
            int index = (int)args[0];
            EnemyEntity item = new EnemyEntity();
            item.SetProperties(collection.Get(index));
            item.Init(entityId);
            return item;
        }
    }
}
