
namespace Assets.Scripts.Data
{
    public abstract class Builder
    {
        public abstract void Build(Entity entity, params object[] args);
    }
}
