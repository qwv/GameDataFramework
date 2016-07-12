using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class PackEntity: Entity, IPackAvater
    {
        public int capacity;

        public int count;

        public List<CellEntity> cells;

        public PackEntity()
        {
            type = EntityType.PACK;
        }

        public PackEntity(PackEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
            capacity = (int)args[0];
            count = 0;
            cells = new List<CellEntity>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                cells.Add(new CellEntity());
            }
        }

        public override object Clone()
        {
            return new PackEntity(this);
        }

        public override Dictionary<string, string> Serialize()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < capacity; i++)
            {
                
            }
            return dict;
        }

        public override void Deserialize(Dictionary<string, string> dict)
        {
            
        }

        public EntityType Type()
        {
            return type;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Capacity()
        {
            return capacity;
        }

        public int Count()
        {
            return count;
        }

        public bool Full()
        {
            return count == capacity;
        }

        public CellEntity Cell(int index)
        {
            if (index >= 0 && index < capacity)
            {
                return cells[index];
            }
            return null;
        }

        public void CellSwap(int index1, int index2)
        {
            CellEntity temp = cells[index1];
            cells[index1] = cells[index2];
            cells[index2] = temp;
        }

        public bool CellMerge(int index1, int index2)
        {
            return false;
        }

        public bool CellSplit(int index, int num)
        {
            return false;
        }

        public bool PutInto(Entity entity)
        {
            return false;
        }

        public void TakeOut()
        {

        }

        public Entity Find()
        {
            return null;
        }
    }
}
