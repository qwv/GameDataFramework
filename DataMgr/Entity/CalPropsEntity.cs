
namespace Assets.Scripts.Data.Internal
{
    public class CalPropsEntity : Entity
    {
        public class PropName
        {
            public const string HP = "hp";
            public const string HP_MAX = "hp_max";
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
        public float hpMax;
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
            properties = entity.properties;
            hp = entity.hp;
            hpMax = entity.hpMax;
            atk = entity.atk;
            atkRay = entity.atkRay;
            atkIce = entity.atkIce;
            atkFire = entity.atkFire;
            atkWind = entity.atkWind;
            def = entity.def;
            defRay = entity.defRay;
            defIce = entity.defIce;
            defFire = entity.defFire;
            defWind = entity.defWind;
            crit = entity.crit;
            critMult = entity.critMult;
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new CalPropsEntity(this);
        }

        public float Hp()
        {
            return hp;
        }

        public float HpMax()
        {
            return hpMax;
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

        public void FullHp()
        {
            hp = hpMax;
        }

        public void AddHp(float value)
        {
            hp += value;
            hp = hp < hpMax ? hp : hpMax;
        }

        public void SubHp(float value)
        {
            hp -= value;
            hp = hp > 0 ? hp : 0; 
        }

        public static CalPropsEntity operator +(CalPropsEntity operand1, CalPropsEntity operand2)
        {
            CalPropsEntity result = new CalPropsEntity();
            result.hp = operand1.hp + operand2.hp;
            result.hpMax = operand1.hpMax + operand2.hpMax;
            result.atk = operand1.atk + operand2.atk;
            result.atkRay = operand1.atkRay + operand2.atkRay;
            result.atkIce = operand1.atkIce + operand2.atkIce;
            result.atkFire = operand1.atkFire + operand2.atkFire;
            result.atkWind = operand1.atkWind + operand2.atkWind;
            result.def = operand1.def + operand2.def;
            result.defRay = operand1.defRay + operand2.defRay;
            result.defIce = operand1.defIce + operand2.defIce;
            result.defFire = operand1.defFire + operand2.defFire;
            result.defWind = operand1.defWind + operand2.defWind;
            result.crit = operand1.crit + operand2.crit;
            result.critMult = operand1.critMult + operand2.critMult;

            return result;
        }
    }
}
