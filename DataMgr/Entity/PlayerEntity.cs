
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

        public string equipmentPackName;

        public PackEntity equipmentPack;

        public int exp;

        public PlayerEntity()
        {
            type = EntityType.PLAYER;

            equipmentPackName = "";
            equipmentPack = null;
            exp = 0;
        }

        public PlayerEntity(PlayerEntity entity) : base(entity)
        {
            type = entity.type;

            equipmentPackName = entity.equipmentPackName;
            equipmentPack = entity.equipmentPack;
            exp = entity.exp;
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
            return exp;
        }

        public int ExpUp()
        {
            return properties.GetIntValue(PropName.EXP);
        }

        public IAvater EquipmentPack()
        {
            return (IAvater)equipmentPack;
        }

        public string EquipmentPackName()
        {
            return equipmentPackName;
        }

        public void SetEquipmentPack(string name, PackEntity pack)
        {
            equipmentPackName = name;
            equipmentPack = pack;
        }
    }
}
