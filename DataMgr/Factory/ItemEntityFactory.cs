
namespace Assets.Scripts.Data
{
    public class ItemEntityFactory : EntityFactory
    {
        private DataCollection collection = new DataCollection();

        private static ItemEntityFactory instance;

        public static ItemEntityFactory Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new ItemEntityFactory();
                    instance.collection.Init(ConfigTablePath.ITEM_SOURCE);
                }
                return instance;
            }
        }

        public override Entity Create(int entityId, params object[] args)
        {
            int index = (int)args[0];
            ItemEntity item = new ItemEntity();
            item.SetProperties(collection.Get(index));
            item.Init(entityId);
            return item;
        }
    }
}
