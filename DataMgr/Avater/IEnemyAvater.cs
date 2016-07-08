
namespace Assets.Scripts.Data
{
    public interface IEnemyAvater : IAvater
    {
        int Id();

        string Name();

        int Level();

        float Hp();

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

        float CritRate();

        int DropNum();

        int Drop(int index);
    }
}
