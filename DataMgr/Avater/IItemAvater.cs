
namespace Assets.Scripts.Data
{
    public interface IItemAvater : IAvater, ICalPropsAvater
    {
        int Id();

        string Name();

        int Level();

        string Model();
    }
}
