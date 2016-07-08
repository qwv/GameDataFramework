
namespace Assets.Scripts.Data
{
    public class BackpackEntityFactory : EntityFactory
    {
        private static BackpackEntityFactory instance;

        public static BackpackEntityFactory Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new BackpackEntityFactory();
                }
                return instance;
            }
        }

        public override Entity Create(int entityId, params object[] args)
        {
            int capacity = (int)args[0];
            BackpackEntity backpack = new BackpackEntity();
            backpack.Init(entityId, capacity);
            return backpack;
        }
    }
}
