using System.Collections;

namespace Assets.Scripts.Data
{
    public interface IEquipmentAvater : IAvater, ICalPropsAvater
    {
        int Id();

        string Name();

        string EquipmentType();
    }
}
