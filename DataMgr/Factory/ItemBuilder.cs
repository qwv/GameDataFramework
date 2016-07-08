
namespace Assets.Scripts.Data
{
    public class ItemBuilder: Builder 
    {
        private DataCollection collection = new DataCollection();

        private static ItemBuilder instance;

        public static ItemBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new ItemBuilder();
                    instance.collection.Init(ConfigTablePath.ITEM_SOURCE);
                }
                return instance;
            }
        }

        public override void Build(Entity entity, params object[] args)
        {
            ItemEntity itemEntity = (ItemEntity)entity;

            int index = (int)args[0];
            Properties properties = collection.Get(index);
            entity.properties = properties;
        }
    }
}
