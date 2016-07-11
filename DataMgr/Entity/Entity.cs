using System;

namespace Assets.Scripts.Data.Internal
{
    public abstract class Entity : ICloneable
    {
        public Properties properties;

        public int entityId;

        public abstract void Init(params object[] args);

        public abstract void Save();

        public abstract object Clone();
    }
}
