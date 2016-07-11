
namespace Assets.Scripts.Data.Internal
{
    public class CommandCreator<T> : Creator where T : Command, new()
    {
        /// <summary>
        /// Create commands
        /// </summary>
        /// <param name="args">args</param>
        /// <returns></returns>
        public override Command Create(params object[] args)
        {
            T t = new T();
            t.Init(args);
            return t;
        }
    }
}
