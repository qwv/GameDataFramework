
namespace Assets.Scripts.Data.Internal
{
    public class SkillBuilder: Builder 
    {
        private static SkillBuilder instance;

        public static SkillBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new SkillBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build skill entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:<see cref="EntityType"/>, args[1]:item id</param>
        public override void Build(Entity entity, params object[] args)
        {
            SkillEntity skillEntity = (SkillEntity)entity;

            int id = (int)args[1];
            Properties properties = DBProxy.Find(Table.SKILL, "id", id.ToString());
            skillEntity.properties = properties;
        }
    }
}
