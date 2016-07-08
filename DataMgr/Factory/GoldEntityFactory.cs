
namespace Assets.Scripts.Data
{
    public class GoldEntityFactory : EntityFactory
    {
        private static GoldEntityFactory instance;

        public static GoldEntityFactory Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new GoldEntityFactory();
                }
                return instance;
            }
        }

        public override Entity Create(int entityId, params object[] args)
        {
            int goldNum = (int)args[0];
            GoldEntity gold = new GoldEntity();
            gold.Init(entityId, goldNum);
            return gold;
        }
    }
}
