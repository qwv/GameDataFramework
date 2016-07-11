
namespace Assets.Scripts.Data
{
    public interface IPackAvater : IAvater
    {
        int Capacity();

        int Count();

        bool Full();

        IAvater Cell(int index);

        int CellCount(int index);

        void Swap(int index1, int index2);

        void Merge(int index1, int index2);
    }
}
