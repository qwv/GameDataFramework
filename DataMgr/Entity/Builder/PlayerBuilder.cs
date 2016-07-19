
namespace Assets.Scripts.Data.Internal
{
    public class PlayerBuilder: Builder 
    {
        private static PlayerBuilder instance;

        public static PlayerBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new PlayerBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build player entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:player id, arg[1]:level</param>
        public override void Build(Entity entity, params object[] args)
        {
            PlayerEntity playerEntity = (PlayerEntity)entity;

            int id = (int)args[0];
            int level = (int)args[1];
            PropertiesWrapper properties = DBProxy.Find(Table.PLAYER + id.ToString(), "level", level.ToString());
            playerEntity.properties = properties;
            CalPropsBuilder.Instance.Build(playerEntity);
        }
    }
}
