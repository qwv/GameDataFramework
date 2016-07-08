
namespace Assets.Scripts.Data
{
    public class EnemyEntity : Entity, IEnemyAvater
    {
        private class PropName{
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
        public int dropNum;
        public int[] dropList;

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
            hp = properties.GetFloatValue(PropName.HP);
            atk = properties.GetFloatValue(PropName.ATK);
            atkRay = properties.GetFloatValue(PropName.ATK_RAY);
            atkIce = properties.GetFloatValue(PropName.ATK_ICE);
            atkFire = properties.GetFloatValue(PropName.ATK_FIRE);
            atkWind = properties.GetFloatValue(PropName.ATK_WIND);
            def = properties.GetFloatValue(PropName.DEF);
            defRay = properties.GetFloatValue(PropName.DEF_RAY);
            defIce = properties.GetFloatValue(PropName.DEF_ICE);
            defFire = properties.GetFloatValue(PropName.DEF_FIRE);
            defWind = properties.GetFloatValue(PropName.DEF_WIND);
            crit = properties.GetFloatValue(PropName.CRIT);
            critRate = properties.GetFloatValue(PropName.CRIT_RATE);
            dropNum = properties.GetIntValue(PropName.DROP_NUM);
            dropList = new int[dropNum];
            for (int i = 0; i < dropNum; i++)
            {
                dropList[i] = properties.GetIntValue(PropName.DROP + (i + 1) + "_id"); 
            }
        }

        public override void Save()
        {
        }

        public override object Clone()
        {
            return new EnemyEntity();
        }

        public EntityType Type()
        {
            return EntityType.ENEMY;
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
            return dropNum;
        }

        public int Drop(int index)
        {
            if (index >= 0 && index < dropList.Length)
            {
                return dropList[index];
            }
            return 0;
        }
    }
}
