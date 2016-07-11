
namespace Assets.Scripts.Data.Internal
{
    public class ItemEntity : Entity, IItemAvater
    {
        public class PropName{
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string BIND_NUM = "bind_num";
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

        public override void Save()
        {
        }

        public EntityType Type()
        {
            return EntityType.ITEM;
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

        public int BindNum()
        {
            return properties.GetIntValue(PropName.BIND_NUM);
        }

        public string Model()
        {
            return properties.GetStringValue(PropName.MODEL);
        }
    }
}
