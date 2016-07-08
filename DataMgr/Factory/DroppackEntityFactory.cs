
namespace Assets.Scripts.Data
{
    public class DroppackEntityFactory : EntityFactory
    {
        private DataCollection collection = new DataCollection();

        private static DroppackEntityFactory instance;

        public static DroppackEntityFactory Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new DroppackEntityFactory();
                }
                return instance;
            }
        }

        public override Entity Create(int entityId, params object[] args)
        {
            int index = (int)args[0];
            DroppackEntity dropback = new DroppackEntity();
            dropback.SetProperties(collection.Get(index));
            dropback.Init(entityId);
            return dropback;
        }
    }
}
