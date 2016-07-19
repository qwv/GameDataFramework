
namespace Assets.Scripts.Data.Internal
{
    public class GoldEntity : Entity, IGoldAvater
    {
        public int gold;

        public GoldEntity() 
        {
            type = EntityType.GOLD;
        }

        public GoldEntity(GoldEntity entity)
        {
            type = entity.type;
            this.gold = entity.gold;
        }

        public override void Init(params object[] args)
        {
            gold = (int)args[0];
        }

        public override object Clone()
        {
            return new GoldEntity(this);
        }

        public EntityType Type()
        {
            return type;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Gold()
        {
            return gold;
        }
    }
}
