using System.Collections;

namespace Assets.Scripts.Data
{
    public interface IPlayerAvater : IAvater, ICalPropsAvater
    {
        int Id();

        int Level();

        int Exp();
    }
}
