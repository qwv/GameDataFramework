
namespace Assets.Scripts.Data
{
    public interface IAvater : IDebug
    {
        EntityType Type();

        int EntityId();
    }
}
