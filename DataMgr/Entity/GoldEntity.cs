
namespace Assets.Scripts.Data
{
    public class GoldEntity : Entity, IGoldAvater
    {
        public int gold;

        public override void Init(int entityId, int gold)
        {
            this.entityId = entityId;
            this.gold = gold;
        }

        public override void Save()
        {
        }

        public override object Clone()
        {
            return new GoldEntity();
        }

        public EntityType Type()
        {
            return EntityType.GOLD;
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
