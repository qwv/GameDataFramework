using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class ItemEntity : Entity, IItemAvater
    {
        public class PropName{
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string STACK_NUM = "stack_num";
            public const string MODEL = "model";
        }

        public ItemEntity() { }

        public ItemEntity(ItemEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new ItemEntity(this);
        }

        public override Dictionary<string, string> Serialize()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(PropName.ID, Id());
            return dict;
        }

        public override void Deserialize(Dictionary<string, string> dict)
        {
            int id = dict[PropName.ID];
            ItemBuilder.Instance.Build(this, Type(), id);
        }

        public EntityType Type()
        {
            return EntityType.ITEM;
        }

        public int EntityId()
        {
            return entityId;
        }

        public override bool Same(Entity entity)
        {
            return Type() == entity.Type() && Id() == entity.Id();
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

        public int StackNum()
        {
            return properties.GetIntValue(PropName.STACK_NUM);
        }

        public string Model()
        {
            return properties.GetStringValue(PropName.MODEL);
        }
    }
}
