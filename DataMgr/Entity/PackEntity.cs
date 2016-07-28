using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class PackEntity: Entity, IPackAvater
    {
        public int capacity;

        public List<CellEntity> cells;

        public Dictionary<string, Entity> index;

        public PackEntity()
        {
            type = EntityType.PACK;
        }

        public PackEntity(PackEntity entity)
        {
            type = entity.type;
            capacity = entity.capacity;
            cells = new List<CellEntity>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                cells.Add((CellEntity)EntityManager.Instance.CreateEntity(EntityType.CLONE, entity.cells[i]));
            }
        }

        public override void Init(params object[] args)
        {
            capacity = (int)args[0];
            cells = new List<CellEntity>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                cells.Add((CellEntity)EntityManager.Instance.CreateEntity(EntityType.CELL));
            }
        }

        public override object Clone()
        {
            return new PackEntity(this);
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
            int count = 0;
            foreach (CellEntity cell in cells)
            {
                if (cell.Stack() > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public bool Full()
        {
            return Count() == capacity;
        }

        public bool Empty()
        {
            return Count() == 0;
        }

        public ICellAvater Cell(int index)
        {
            return (ICellAvater)Get(index);
        }

        public CellEntity Get(int index)
        {
            if (index >= 0 && index < capacity)
            {
                return cells[index];
            }
            return null;
        }

        public bool PutInto(Entity entity)
        {
            if (entity.type == EntityType.CELL)
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
                if (entity.type == EntityType.CELL)
                {
                    return CellEntity.MergeCell(cell, (CellEntity)entity);
                }
                else
                {
                    return cell.Add(entity);
                }
            }
            return false;
        }

        public CellEntity Find(Entity entity)
        {
            foreach (CellEntity cell in cells)
            {
                if (cell.Stack() > 0 && cell.Get().Same(entity))
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
                if (cell.Stack() == 0)
                {
                    return cell;
                }
            }
            return null;
        }
    }
}
