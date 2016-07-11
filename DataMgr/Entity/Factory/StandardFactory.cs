
namespace Assets.Scripts.Data.Internal
{
    public class StandardFactory<T> : Factory where T : Entity, new()
    {
        private Builder builder;

        public StandardFactory(Builder builder = null)
        {
            this.builder = builder;
        }

        /// <summary>
        /// Create entity
        /// Use builder if it's not null
        /// </summary>
        /// <param name="entityId">entity id</param>
        /// <param name="args">args</param>
        /// <returns></returns>
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
