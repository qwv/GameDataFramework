
namespace Assets.Scripts.Data
{
    public interface IAvater : IDebug
    {
        void Retain();

        void Release();

        EntityType Type();

        int EntityId();
    }
}
