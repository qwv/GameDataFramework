
namespace Assets.Scripts.Data
{
    public interface IPackAvater : IAvater
    {
        int Capacity();

        IAvater Cells(int id);
    }
}
