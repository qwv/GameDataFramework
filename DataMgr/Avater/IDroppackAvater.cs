
namespace Assets.Scripts.Data
{
    public interface IDroppackAvater : IPackAvater
    {
        int Id();

        string Name();

        int GoldMin();

        int GoldMax();

        int Value();

        int ItemNum();
    }
}
