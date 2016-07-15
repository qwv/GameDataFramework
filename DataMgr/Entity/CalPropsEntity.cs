using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class CalPropsEntity : Entity
    {
        public class PropName
        {
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
            public const string CRIT_MULT = "crit_mult";
        }

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
        public float critMult;

        public CalPropsEntity()
        {
        }

        public CalPropsEntity(CalPropsEntity entity)
        {
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new CalPropsEntity(this);
        }

        public override Dictionary<string, string> Serialize()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            return dict;
        }

        public override void Deserialize(Dictionary<string, string> dict)
        {
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

        public float CritMult()
        {
            return critMult;
        }
    }
}
