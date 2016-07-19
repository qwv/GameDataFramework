
namespace Assets.Scripts.Data.Internal
{
    public class ItemBuilder: Builder 
    {
        private static ItemBuilder instance;

        public static ItemBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new ItemBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build item entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:item id</param>
        public override void Build(Entity entity, params object[] args)
        {
            ItemEntity itemEntity = (ItemEntity)entity;

            int id = (int)args[0];
            PropertiesWrapper properties = DBProxy.Find(Table.ITEM, "id", id.ToString());
            itemEntity.properties = properties;
            CalPropsBuilder.Instance.Build(itemEntity);
        }
    }
}
