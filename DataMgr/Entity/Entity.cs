using System;

namespace Assets.Scripts.Data.Internal
{
    public abstract class Entity : ICloneable
    {
        public PropertiesWrapper properties;

        public EntityType type;

        public int entityId;

        public abstract void Init(params object[] args);

        public abstract object Clone();

        public virtual int StackNum() { return 1; }

        public virtual bool Same(Entity entity) { return false; }
    }
}
