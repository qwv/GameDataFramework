
namespace Assets.Scripts.Data.Internal
{
    public class ItemBuilder: Builder 
    {
        private Collection collection = new Collection();

        private static ItemBuilder instance;

        public static ItemBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new ItemBuilder();
                    instance.collection.Load(ConfigTablePath.ITEM_SOURCE);
                }
                return instance;
            }
        }

        /// <summary>
        /// Build item entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:<see cref="EntityType"/>, args[1]:item id</param>
        public override void Build(Entity entity, params object[] args)
        {
            ItemEntity itemEntity = (ItemEntity)entity;

            int id = (int)args[1];
            Properties properties = collection.Get(id);
            entity.properties = properties;
        }
    }
}
