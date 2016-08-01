
namespace Assets.Scripts.Data.Internal
{
    public class PlayerEntity : CalPropsEntity, IPlayerAvater
    {
        public new class PropName : CalPropsEntity.PropName
        {
            public const string LEVEL = "level";
            public const string EXP = "exp";
        }

        public string equipmentPackName;

        public int exp;

        public PlayerEntity()
        {
            type = EntityType.PLAYER;

            equipmentPackName = "";
            exp = 0;
        }

        public PlayerEntity(PlayerEntity entity) : base(entity)
        {
            type = entity.type;

            equipmentPackName = entity.equipmentPackName;
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

        public string DebugTag()
        {
            return properties.tableName + "(" + entityId + ")";
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Id()
        {
            return 101;
        }

        public int Level()
        {
            return properties.GetIntValue(PropName.LEVEL);
        }

        public int LevelMax()
        {
            return properties.TableCount();
        }

        public int Exp()
        {
            return exp;
        }

        public int ExpUp()
        {
            return properties.GetIntValue(PropName.EXP);
        }

        public string EquipmentPackName()
        {
            return equipmentPackName;
        }

        public void SetEquipmentPack(string name)
        {
            equipmentPackName = name;
        }
    }
}
