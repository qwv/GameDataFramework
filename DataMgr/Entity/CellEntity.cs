using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class CellEntity : Entity, ICellAvater
    {
        List<Entity> stack;

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
            stack.RemoveAt(0);
        }

        public Entity Get()
        {
            if (stack.Count > 0)
            {
                return stack[0];
            }
            return null;
        }
    }
}
