using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class DamageFormula : Formula
    {
        public override void Calculate(CalPropsEntity attacker, CalPropsEntity target)
        {
            float atkDmg = attacker.atk - target.def;
            float rayDmg = attacker.atkRay - target.defRay;
            float fireDmg = attacker.atkFire - target.defFire;
            float iceDmg = attacker.atkIce - target.defIce;
            float windDmg = attacker.atkWind - target.defWind;

            float allDmg = atkDmg + rayDmg + fireDmg + iceDmg + windDmg;
            float critMult = Random.Range(0f, 1f) < attacker.crit ? attacker.critMult : 1;
            float correction = Random.Range(0.75f, 1.25f);

            float endValue = allDmg * critMult * correction;

            result = endValue > 0 ? endValue : 0;
        }
    }
}
