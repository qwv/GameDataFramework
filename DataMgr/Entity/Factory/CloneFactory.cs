
namespace Assets.Scripts.Data.Internal
{
    public class CloneFactory : Factory
    {
        private static CloneFactory instance;

        public static CloneFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CloneFactory();
                }
                return instance;
            }
        }

        /// <summary>
        /// Create entity's clone
        /// </summary>
        /// <param name="entityId">entity id</param>
        /// <param name="args">args[0]:entity need clone</param>
        /// <returns></returns>
        public override Entity Create(int entityId, params object[] args)
        {
            Entity entity = (Entity)args[0];
            Entity cloneEntity = (Entity)entity.Clone();
            cloneEntity.entityId = entityId;
            return cloneEntity;
        }
    }
}
