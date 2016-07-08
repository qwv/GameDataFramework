
namespace Assets.Scripts.Data
{
    public abstract class EntityFactory
    {
        public abstract Entity Create(int entityId, params object[] args);
    }

    public class StandardFactory<T> where T : Entity, new()
    {
        private StandardBuilder builder;

        public StandardFactory(StandardBuilder builder = null)
        {
            this.builder = builder;
        }

        public T Create(int entityId, params object[] args)
        {
            T t = new T();
            t.entityId = entityId;
            if (builder != null)
            {
                builder.Build(t, args);
            }
            return t;
        }
    }
}
