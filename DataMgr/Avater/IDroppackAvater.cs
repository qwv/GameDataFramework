
namespace Assets.Scripts.Data
{
    public interface IDroppackAvater : IAvater
    {
        int Capacity();

        IAvater Cells(int id);
    }
}
