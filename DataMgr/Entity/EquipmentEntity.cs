using System;
using System.Collections;
using System.Collections.Generic;

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

        public EquipmentEntity(EquipmentEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new EquipmentEntity();
        }

        public override Dictionary<string, string> Serialize()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(PropName.ID, Id().ToString());
            return dict;
        }

        public override void Deserialize(Dictionary<string, string> dict)
        {
            int id = Convert.ToInt32(dict[PropName.ID]);
            EnemyBuilder.Instance.Build(this, Type(), id);
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
