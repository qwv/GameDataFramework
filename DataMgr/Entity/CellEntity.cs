using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class CellEntity : Entity, ICellAvater
    {
        public int stack;
        public Entity goods;

        public CellEntity()
        {
            type = EntityType.CELL;            
        }

        public CellEntity(CellEntity entity)
        {
            type = entity.type;
            stack = entity.stack;
            if (stack > 0)
            {
                goods = EntityManager.Instance.CreateEntity(EntityType.CLONE, entity.goods);
            }
        }

        public override void Init(params object[] args)
        {
            stack = 0;
        }

        public override object Clone()
        {
            return new CellEntity(this);
        }

        public string DebugTag()
        {
            return "Cell(" + entityId + ")";
        }

        public EntityType Type()
        {
            return type;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Stack()
        {
            return stack;
        }

        public IAvater Goods()
        {
            return (IAvater)Get();
        }

        public Entity Get()
        {
            return goods;
        }

        public bool Add(Entity entity)
        {
            if (entity == null)
            {
                return false;
            }

            if (stack > 0)
            {
                if (stack >= goods.StackNum() || !goods.Same(entity))
                {
                    return false;
                }
            }
            stack++;
            goods = entity;
            return true;
        }

        public void Remove()
        {
            if (stack > 0)
            {
                if (--stack == 0)
                {
                    goods = null;
                }
            }
        }

        public void clear()
        {
            stack = 0;
            goods = null;
        }

        public static bool SwapCell(CellEntity cell1, CellEntity cell2)
        {
            CellEntity temp = cell1;
            cell1.stack = cell2.stack;
            cell1.goods = cell2.goods;
            cell2.stack = temp.stack;
            cell2.goods = temp.goods;
            return true;
        }

        public static bool MergeCell(CellEntity cell1, CellEntity cell2, int num = 10000)
        {
            num = num < cell2.Stack() ? num : cell2.Stack();

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
