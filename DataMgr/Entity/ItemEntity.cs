
namespace Assets.Scripts.Data
{
    public class ItemEntity : Entity, IItemAvater
    {
        private class PropName{
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string BIND_NUM = "bind_num";
            public const string MODEL = "model";
        }

        public int id;
        public string name;
        public int level;
        public int bindNum;
        public string model;

        public override void SetProperties(EntityProperties ep)
        {
            properties = ep;
        }

        public override void Init(int entityId)
        {
            this.entityId = entityId;
            id = properties.GetIntValue(PropName.ID);
            name = properties.GetStringValue(PropName.NAME);
            level = properties.GetIntValue(PropName.LEVEL);
            bindNum = properties.GetIntValue(PropName.BIND_NUM);
            model = properties.GetStringValue(PropName.MODEL);
        }

        public override void Save()
        {
        }

        public override object Clone()
        {
            return new ItemEntity();
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
            return id;
        }

        public string Name()
        {
            return name;
        }

        public int Level()
        {
            return level;
        }

        public int BindNum()
        {
            return bindNum;
        }

        public string Model()
        {
            return model;
        }
    }
}
