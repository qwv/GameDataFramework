using System;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class DamageFormula : Formula
    {
        public override void Calculate(CalPropsEntity attacker, CalPropsEntity target)
        {
            float atkDmg = attacker.Atk() - target.Def();
            float rayDmg = attacker.AtkRay() - target.DefRay();
            float fireDmg = attacker.AtkFire() - target.DefFire();
            float iceDmg = attacker.AtkIce() - target.DefIce();
            float windDmg = attacker.AtkWind() - target.DefWind();
            
            atkDmg = atkDmg > 0 ? atkDmg : 0;
            rayDmg = rayDmg > 0 ? rayDmg : 0;
            fireDmg = fireDmg > 0 ? fireDmg : 0;
            iceDmg = iceDmg > 0 ? iceDmg : 0;
            windDmg = windDmg > 0 ? windDmg : 0;

            float allDmg = atkDmg + rayDmg + fireDmg + iceDmg + windDmg;
            float critMult = UnityEngine.Random.Range(0f, 1f) < attacker.crit ? attacker.critMult : 1;
            float correction = UnityEngine.Random.Range(0.75f, 1.25f);

            float endValue = allDmg * critMult * correction;

            endValue = (float)Math.Round((decimal)endValue, MidpointRounding.AwayFromZero);

            result = endValue > 0 ? endValue : 0;
        }
    }
}
