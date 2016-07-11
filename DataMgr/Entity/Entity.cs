using System;
using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public abstract class Entity : ICloneable
    {
        public Properties properties;

        public int entityId;

        public abstract void Init(params object[] args);

        public abstract object Clone();

        public abstract Dictionary<string, string> Serialize();

        public abstract void Deserialize(Dictionary<string, string> dict);

        public virtual bool Same(Entity entity) { return false; }
    }
}
