
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
            if (t.Verify(args))
            {
                t.Init(args);
                t.GenerateMessage(args);
                return t;
            }
            return null;
        }
    }
}
