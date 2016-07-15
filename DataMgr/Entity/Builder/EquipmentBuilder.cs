
namespace Assets.Scripts.Data.Internal
{
    public class EquipmentBuilder: Builder 
    {
        private static EquipmentBuilder instance;

        public static EquipmentBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new EquipmentBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build equipment entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:<see cref="EntityType"/>, args[1]:equipment id</param>
        public override void Build(Entity entity, params object[] args)
        {
            EquipmentEntity equipmentEntity = (EquipmentEntity)entity;

            int id = (int)args[1];
            Properties properties = DBProxy.Find(Table.EQUIPMENT, "id", id.ToString());
            equipmentEntity.properties = properties;
            CalPropsBuilder.Instance.Build(equipmentEntity);
        }
    }
}
