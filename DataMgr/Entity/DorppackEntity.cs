
namespace Assets.Scripts.Data.Internal
{
    public class DroppackEntity: PackEntity, IDroppackAvater
    {
        public class PropName
        {
            public const string ID = "id";
            public const string GOLD_MIN = "gold_min";
            public const string GOLD_MAX = "gold_max";
            public const string VALUE = "value";
            public const string ITEM_NUM = "item_num";
            public const string ITEM = "item";
        }

        public DroppackEntity() 
        {
            type = EntityType.DROPPACK;
        }

        public DroppackEntity(DroppackEntity entity) : base(entity)
        {
            this.properties = entity.properties;
        }

        public override object Clone()
        {
            return new DroppackEntity(this);
        }

        public new EntityType Type()
        {
            return type;
        }

        public int Id()
        {
            return properties.GetIntValue(PropName.ID);
        }

        public int GoldMin()
        {
            return properties.GetIntValue(PropName.GOLD_MIN);
        }

        public int GoldMax()
        {
            return properties.GetIntValue(PropName.GOLD_MAX);
        }

        public int Value()
        {
            return properties.GetIntValue(PropName.VALUE);
        }

        public int ItemNum()
        {
            return properties.GetIntValue(PropName.ITEM_NUM);
        }
    }
}
