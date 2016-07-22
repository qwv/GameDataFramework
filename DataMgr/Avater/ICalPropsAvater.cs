
namespace Assets.Scripts.Data
{
    public interface ICalPropsAvater
    {
        float Hp();

        float HpMax();

        float Atk();

        float AtkRay();

        float AtkIce();

        float AtkFire();

        float AtkWind();

        float Def();

        float DefRay();

        float DefIce();

        float DefFire();

        float DefWind();

        float Crit();

        float CritMult();

        void FullHp();

        void AddHp(float value);

        void SubHp(float value);
    }
}
