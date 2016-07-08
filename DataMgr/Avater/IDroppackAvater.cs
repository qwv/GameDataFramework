
namespace Assets.Scripts.Data
{
    public interface IDroppackAvater : IPackAvater
    {
        int Id();

        int GoldMin();

        int GoldMax();

        int Value();

        int ItemNum();
    }
}
