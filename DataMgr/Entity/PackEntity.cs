using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class PackEntity: Entity, IPackAvater
    {
        protected class Cell
        {
            List<Entity> stack;

            public Cell()
            {
                stack = new List<Entity>();
            }

            public int Count()
            {
                return stack.Count;
            }

            public bool Add(Entity entity)
            {
                if (stack.Count > 0)
                {
                    if (stack.Count >= stack[0].StackNum() || !stack[0].Same(entity))
                    {
                        return false;
                    }
                }
                stack.Add(entity);
                return true;
            }

            public void Remove()
            {
                stack.Remove(0);
            }

            public Entity Get()
            {
                if (Count() > 0)
                {
                    return stack[0];
                }
                return null;
            }
        }

        public int capacity;

        public List<Cell> cells;

        public int count;

        public PackEntity() { }

        public PackEntity(PackEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
            capacity = (int)args[0];
            cells = new List<Cell>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                cells.Add(new Cell());
            }
            count = 0;
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
            return EntityType.PACK;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int StackNum()
        {
            return 1;
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
            return Capacity() == Count();
        }

        public IAvater Cell(int index)
        {
            return (IAvater)cells[index].Get();
        }

        public int CellCount(int index)
        {
            return cells[index].Count();
        }

        public void Swap(int index1, int index2)
        {
            Cell temp = cells[index1];
            cells[index1] = cells[index2];
            cells[index2] = temp;
        }

        public bool Merge(int index1, int index2)
        {

        }

        public bool Add(Entity entity)
        {

        }
    }
}
