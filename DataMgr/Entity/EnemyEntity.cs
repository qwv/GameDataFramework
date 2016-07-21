
namespace Assets.Scripts.Data.Internal
{
    public class EnemyEntity : CalPropsEntity, IEnemyAvater 
    {
        public new class PropName : CalPropsEntity.PropName
        {
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string EXP = "exp";
            public const string DROP_NUM = "drop_num";
            public const string DROP = "drop";
        }

        public EnemyEntity() 
        {
            type = EntityType.ENEMY;
        }

        public EnemyEntity(EnemyEntity entity) : base(entity)
        {
            type = entity.type;
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new EnemyEntity(this);
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

        public int Exp()
        {
            return properties.GetIntValue(PropName.EXP);
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
