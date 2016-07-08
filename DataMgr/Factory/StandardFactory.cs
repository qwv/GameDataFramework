
namespace Assets.Scripts.Data
{
    public class StandardFactory<T> : Factory where T : Entity, new()
    {
        private Builder builder;

        public StandardFactory(Builder builder = null)
        {
            this.builder = builder;
        }

        public override Entity Create(int entityId, params object[] args)
        {
            T t = new T();
            t.entityId = entityId;

            if (builder != null)
            {
                builder.Build(t, args);
            }
            else
            {
                t.Init(args);
            }
            return t;
        }
    }
}
