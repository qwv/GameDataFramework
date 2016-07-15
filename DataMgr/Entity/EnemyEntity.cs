using System.Collections.Generic;
using System;

namespace Assets.Scripts.Data.Internal
{
    public class EnemyEntity : CalPropsEntity, IEnemyAvater 
    {
        public new class PropName : CalPropsEntity.PropName
        {
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string DROP_NUM = "drop_num";
            public const string DROP = "drop";
        }

        public EnemyEntity() 
        {
            type = EntityType.ENEMY;
        }

        public EnemyEntity(EnemyEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new EnemyEntity();
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

        public int Level()
        {
            return properties.GetIntValue(PropName.LEVEL);
        }

        public int DropNum()
        {
            return properties.GetIntValue(PropName.DROP_NUM);
        }

        public int Drop(int index)
        {
            return properties.GetIntValue(PropName.DROP + (index + 1) + "_id"); 
        }
    }
}
