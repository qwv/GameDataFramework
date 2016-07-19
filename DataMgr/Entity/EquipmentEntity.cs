
namespace Assets.Scripts.Data.Internal
{
    public class EquipmentEntity : CalPropsEntity, IEquipmentAvater
    {
        public new class PropName : CalPropsEntity.PropName
        {
            public const string ID = "id";
            public const string NAME = "name";
            public const string EQUIPMENT_TYPE = "type";
        }

        public EquipmentEntity()
        {
            type = EntityType.EQUIPMENT;
        }

        public EquipmentEntity(EquipmentEntity entity) : base(entity)
        {
            type = entity.type;
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new EquipmentEntity(this);
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

        public string Name()
        {
            return properties.GetStringValue(PropName.NAME);
        }

        public string EquipmentType()
        {
            return properties.GetStringValue(PropName.EQUIPMENT_TYPE);
        }
    }
}
