using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class CellEntity : Entity, ICellAvater
    {
        private List<Entity> stack;

        public CellEntity()
        {
            type = EntityType.CELL;            
        }

        public CellEntity(CellEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
            stack = new List<Entity>();
        }

        public override object Clone()
        {
            return new CellEntity(this);
        }

        public override Dictionary<string, string> Serialize()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
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

        public int Count()
        {
            return stack.Count;
        }

        public bool Add(Entity entity)
        {
            if (entity == null)
            {
                return false;
            }

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

        public Entity Get()
        {
            if (stack.Count > 0)
            {
                return stack[0];
            }
            return null;
        }

        public void Remove()
        {
            stack.RemoveAt(0);
        }

        public void clear()
        {
            stack.Clear();
        }

        public static bool SwapCell(CellEntity cell1, CellEntity cell2)
        {
            List<Entity> temp = cell1.stack;
            cell1.stack = cell2.stack;
            cell2.stack = temp;
            return true;
        }

        public static bool MergeCell(CellEntity cell1, CellEntity cell2, int num = cell2.Count())
        {
            for (int i = 0; i < num; i++)
            {
                if (cell1.Add(cell2.Get()))
                {
                    cell2.Remove();
                }
                else
                {
                    break;
                }
            }
            return true;
        }

        public static bool SplitCell(PackEntity pack, CellEntity cell, int num)
        {
            CellEntity blankCell = pack.FindBlank();
            if (blankCell != null)
            {
                return MergeCell(blankCell, cell, num);
            }
            return false;
        }
    }
}
