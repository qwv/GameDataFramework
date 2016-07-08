using System;

namespace Assets.Scripts.Data
{
    public enum EntityType
    {
        ITEM = 1,
        GOLD = 2,
        BACKPACK = 3,
        DROPPACK = 4,
        ENEMY = 5,
    }

    public abstract class Entity : ICloneable
    {
        protected EntityProperties properties;

        public int entityId;

        public virtual void SetProperties(EntityProperties ep) { }

        public abstract void Init(int entityId);

        public abstract void Save();

        public abstract object Clone();
    }
}
