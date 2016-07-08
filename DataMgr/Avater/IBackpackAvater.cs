
namespace Assets.Scripts.Data
{
    public interface IBackpackAvater : IAvater
    {
        int Capacity();

        IAvater Cells(int id);
    }
}
