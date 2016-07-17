using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class PackEntity: Entity, IPackAvater
    {
        public int capacity;

        public int count;

        public List<CellEntity> cells;

        public Dictionary<string, Entity> index;

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

        public bool Empty()
        {
            return count == 0;
        }

        public CellEntity Cell(int index)
        {
            if (index >= 0 && index < capacity)
            {
                return cells[index];
            }
            return null;
        }

        public bool PutInto(Entity entity)
        {
            if (entity.type == EntityType.Cell)
            {
                return PutIntoBlank(entity);
            }
            else
            {
                foreach (CellEntity cell in cells)
                {
                    if (cell.Add(entity))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PutIntoBlank(Entity entity)
        {
            CellEntity cell = FindBlank();
            if (cell != null)
            {
                if (entity.type == EntityType.Cell)
                {
                    return CellEntity.Merge(cell, (CellEntity)entity);
                }
                else
                {
                    return cell.Add(entity)
                }
            }
            return false;
        }

        public CellEntity Find(Entity entity)
        {
            foreach (CellEntity cell in cells)
            {
                if (cell.Count() > 0 && cell.Get().Same(entity))
                {
                    return cell;
                }
            }
            return null;
        }

        public CellEntity FindBlank()
        {
            foreach (CellEntity cell in cells)
            {
                if (cell.Count() == 0)
                {
                    return cell;
                }
            }
            return null;
        }
    }
}
