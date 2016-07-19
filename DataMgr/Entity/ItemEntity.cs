
namespace Assets.Scripts.Data.Internal
{
    public class ItemEntity : CalPropsEntity, IItemAvater
    {
        public new class PropName : CalPropsEntity.PropName
        {
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string STACK_NUM = "stack_num";
            public const string MODEL = "model";
        }

        public ItemEntity()
        {
            type = EntityType.ITEM;
        }

        public ItemEntity(ItemEntity entity) : base(entity)
        {
            type = entity.type;
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new ItemEntity(this);
        }

        public EntityType Type()
        {
            return type;
        }

        public int EntityId()
        {
            return entityId;
        }

        public override bool Same(Entity entity)
        {
            return type == entity.type && Id() == ((ItemEntity)entity).Id();
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

        public override int StackNum()
        {
            return properties.GetIntValue(PropName.STACK_NUM);
        }

        public string Model()
        {
            return properties.GetStringValue(PropName.MODEL);
        }
    }
}
