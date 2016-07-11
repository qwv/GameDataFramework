
namespace Assets.Scripts.Data.Internal
{
    public class GoldEntity : Entity, IGoldAvater
    {
        public int gold;

        public GoldEntity() { }

        public GoldEntity(GoldEntity entity)
        {
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

        public override void Save()
        {
        }

        public EntityType Type()
        {
            return EntityType.GOLD;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int BindNum()
        {
            return 1;
        }

        public int Gold()
        {
            return gold;
        }
    }
}
