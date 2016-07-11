
namespace Assets.Scripts.Data.Internal
{
    public abstract class Factory
    {
        public abstract Entity Create(int entityId, params object[] args);
    }
}
