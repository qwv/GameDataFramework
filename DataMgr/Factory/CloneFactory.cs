
namespace Assets.Scripts.Data
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

        public override Entity Create(int entityId, params object[] args)
        {
            Entity entity = (Entity)args[0];
            Entity cloneEntity = (Entity)entity.Clone();
            cloneEntity.entityId = entityId;
            return cloneEntity;
        }
    }
}
