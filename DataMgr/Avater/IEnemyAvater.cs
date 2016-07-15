
namespace Assets.Scripts.Data
{
    public interface IEnemyAvater : IAvater, ICalPropsAvater
    {
        int Id();

        string Name();

        int Level();

        int DropNum();

        int Drop(int index);
    }
}
