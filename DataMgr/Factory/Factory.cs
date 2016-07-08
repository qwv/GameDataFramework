
namespace Assets.Scripts.Data
{
    public abstract class Factory
    {
        public abstract Entity Create(int entityId, params object[] args);
    }
}
