
namespace Assets.Scripts.Data.Internal
{
    public abstract class Creator
    {
        public abstract Command Create(params object[] args);
    }
}
