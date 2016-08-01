
namespace Assets.Scripts.Data.Internal
{
    public class SkillEntity : Entity, ISkillAvater
    {
        public class PropName
        {
            public const string ID = "id";
            public const string NAME = "name";
            public const string CD = "cd";
            public const string ATK_MULT = "atk_mult";
            public const string ATK_RAY_MULT = "atk_ray_mult";
            public const string ATK_ICE_MULT = "atk_ice_mult";
            public const string ATK_FIRE_MULT = "atk_fire_mult";
            public const string ATK_WIND_MULT = "atk_wind_mult";
            public const string ATK_ADD = "atk_add";
            public const string ATK_RAY_ADD = "atk_ray_add";
            public const string ATK_ICE_ADD = "atk_ice_add";
            public const string ATK_FIRE_ADD = "atk_fire_add";
            public const string ATK_WIND_ADD = "atk_wind_add";
        }

        public SkillEntity()
        {
            type = EntityType.SKILL;
        }

        public SkillEntity(SkillEntity entity)
        {
            type = entity.type;
            properties = entity.properties;
        }

        public override void Init(params object[] args)
        {
        }

        public override object Clone()
        {
            return new SkillEntity(this);
        }

        public string DebugTag()
        {
            return Name() + "(" + entityId + ")";
        }

        public EntityType Type()
        {
            return type;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Id()
        {
            return properties.GetIntValue(PropName.ID);
        }

        public string Name()
        {
            return properties.GetStringValue(PropName.NAME);
        }

        public int CD()
        {
            return properties.GetIntValue(PropName.CD);
        }

        public float AtkMult()
        {
            return properties.GetFloatValue(PropName.ATK_MULT);
        }

        public float AtkRayMult()
        {
            return properties.GetFloatValue(PropName.ATK_RAY_MULT);
        }

        public float AtkIceMult()
        {
            return properties.GetFloatValue(PropName.ATK_ICE_MULT);
        }

        public float AtkFireMult()
        {
            return properties.GetFloatValue(PropName.ATK_FIRE_MULT);
        }

        public float AtkWindMult()
        {
            return properties.GetFloatValue(PropName.ATK_WIND_MULT);
        }

        public float AtkAdd()
        {
            return properties.GetFloatValue(PropName.ATK_ADD);
        }

        public float AtkRayAdd()
        {
            return properties.GetFloatValue(PropName.ATK_RAY_ADD);
        }

        public float AtkIceAdd()
        {
            return properties.GetFloatValue(PropName.ATK_ICE_ADD);
        }

        public float AtkFireAdd()
        {
            return properties.GetFloatValue(PropName.ATK_FIRE_ADD);
        }

        public float AtkWindAdd()
        {
            return properties.GetFloatValue(PropName.ATK_WIND_ADD);
        }
    }
}
