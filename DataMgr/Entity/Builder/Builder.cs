
namespace Assets.Scripts.Data.Internal
{
    public abstract class Builder
    {
        public abstract void Build(Entity entity, params object[] args);
    }
}
