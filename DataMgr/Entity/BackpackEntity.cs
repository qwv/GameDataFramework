using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    public class BackpackEntity: Entity, IBackpackAvater
    {
        private int capacity;

        private List<Entity> cells;

        public override void Init(int entityId, int capacity)
        {
            this.entityId = entityId;
            this.capacity = capacity;
            cells = new List<Entity>(capacity);
        }

        public override void Save()
        {
        }

        public override object Clone()
        {
            return new BackpackEntity();
        }

        public EntityType Type()
        {
            return EntityType.BACKPACK;
        }

        public int EntityId()
        {
            return entityId;
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
