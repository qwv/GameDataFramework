using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class PackEntity: Entity, IPackAvater
    {
        public int capacity;

        public List<Entity> cells;

        public PackEntity() { }

        public PackEntity(PackEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
            capacity = (int)args[0];
            cells = new List<Entity>(capacity);
        }

        public override object Clone()
        {
            return new PackEntity(this);
        }

        public override void Save()
        {
        }

        public EntityType Type()
        {
            return EntityType.PACK;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int BindNum()
        {
            return 1;
        }

        public int Capacity()
        {
            return capacity;
        }

        public IAvater Cells(int id)
        {
            return (IAvater)cells[id];
        }
    }
}
