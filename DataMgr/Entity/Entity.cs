using System;

namespace Assets.Scripts.Data
{
    public enum EntityType
    {
        ITEM = 1,
        GOLD = 2,
        PACK = 3,
        DROPPACK = 4,
        ENEMY = 5,
        CLONE = 6,
    }

    public abstract class Entity : ICloneable
    {
        public Properties properties;

        public int entityId;

        public abstract void Init(params object[] args);

        public abstract void Save();

        public abstract object Clone();
    }
}
