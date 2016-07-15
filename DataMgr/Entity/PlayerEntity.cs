using System;
using System.Collections;
using System.Collections.Generic;

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

        public PlayerEntity(PlayerEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new PlayerEntity();
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
