using System.Collections;

namespace Assets.Scripts.Data
{
    public interface ISkillAvater : IAvater
    {
        int Id();

        string Name();

        int CD();

        float AtkMult();

        float AtkRayMult();

        float AtkIceMult();

        float AtkFireMult();

        float AtkWindMult();

        float AtkRayAdd();

        float AtkIceAdd();

        float AtkFireAdd();

        float AtkWindAdd();
    }
}
