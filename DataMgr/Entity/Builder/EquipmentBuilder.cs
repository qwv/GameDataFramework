
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
        /// <param name="args">args[0]:equipment id</param>
        public override void Build(Entity entity, params object[] args)
        {
            EquipmentEntity equipmentEntity = (EquipmentEntity)entity;

            int id = (int)args[0];
            PropertiesWrapper properties = DBProxy.Find(Table.EQUIPMENT, "id", id.ToString());
            equipmentEntity.properties = properties;
            CalPropsBuilder.Instance.Build(equipmentEntity);
        }
    }
}
