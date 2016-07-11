using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class EnemyEntity : Entity, IEnemyAvater
    {
        public class PropName{
            public const string ID = "id";
            public const string NAME = "name";
            public const string LEVEL = "level";
            public const string HP = "hp";
            public const string ATK = "atk";
            public const string ATK_RAY = "atk_ray";
            public const string ATK_ICE = "atk_ice";
            public const string ATK_FIRE = "atk_fire";
            public const string ATK_WIND = "atk_wind";
            public const string DEF = "def";
            public const string DEF_RAY = "def_ray";
            public const string DEF_ICE = "def_ice";
            public const string DEF_FIRE = "def_fire";
            public const string DEF_WIND = "def_wind";
            public const string CRIT = "crit";
            public const string CRIT_RATE = "crit_rate";
            public const string DROP_NUM = "drop_num";
            public const string DROP = "drop";
        }

        public int id;
        public string name;
        public int level;
        public float hp;
        public float atk;
        public float atkRay;
        public float atkIce;
        public float atkFire;
        public float atkWind;
        public float def;
        public float defRay;
        public float defIce;
        public float defFire;
        public float defWind;
        public float crit;
        public float critRate;

        public EnemyEntity() { }

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
            dict.Add(PropName.ID, id);
            return dict;
        }

        public override void Deserialize(Dictionary<string, string> dict)
        {
            int id = dict[PropName.ID];
            EnemyBuilder.Instance.Build(this, Type(), id);
        }

        public EntityType Type()
        {
            return EntityType.ENEMY;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int StackNum()
        {
            return 1;
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

        public float Hp()
        {
            return hp;
        }

        public float Atk()
        {
            return atk;
        }

        public float AtkRay()
        {
            return atkRay;
        }

        public float AtkIce()
        {
            return atkIce;
        }

        public float AtkFire()
        {
            return atkFire;
        }

        public float AtkWind()
        {
            return atkWind;
        }

        public float Def()
        {
            return def;
        }

        public float DefRay()
        {
            return defRay;
        }

        public float DefIce()
        {
            return defIce;
        }

        public float DefFire()
        {
            return defFire;
        }

        public float DefWind()
        {
            return defWind;
        }

        public float Crit()
        {
            return crit;
        }

        public float CritRate()
        {
            return critRate;
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
