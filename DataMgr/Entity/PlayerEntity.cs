
namespace Assets.Scripts.Data.Internal
{
    public class PlayerEntity : CalPropsEntity, IPlayerAvater
    {
        public new class PropName : CalPropsEntity.PropName
        {
            public const string ID = "id";
            public const string LEVEL = "level";
            public const string EXP = "exp";
        }

        public PlayerEntity()
        {
            type = EntityType.PLAYER;
        }

        public PlayerEntity(PlayerEntity entity) : base(entity)
        {
            type = entity.type;
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new PlayerEntity(this);
        }

        public EntityType Type()
        {
            return type;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Id()
        {
            return properties.GetIntValue(PropName.ID);
        }

        public int Level()
        {
            return properties.GetIntValue(PropName.LEVEL);
        }

        public int Exp()
        {
            return properties.GetIntValue(PropName.EXP);
        }
    }
}
