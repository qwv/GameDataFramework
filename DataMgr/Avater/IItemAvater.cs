
namespace Assets.Scripts.Data
{
    public interface IItemAvater : IAvater
    {
        int Id();

        string Name();

        int Level();

        int BindNum();

        string Model();
    }
}
