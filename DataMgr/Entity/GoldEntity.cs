using System.Collections.Generic;
using System;

namespace Assets.Scripts.Data.Internal
{
    public class GoldEntity : Entity, IGoldAvater
    {
        public int gold;

        public GoldEntity() { }

        public GoldEntity(GoldEntity entity)
        {
            this.gold = entity.gold;
        }

        public override void Init(params object[] args)
        {
            gold = (int)args[0];
        }

        public override object Clone()
        {
            return new GoldEntity(this);
        }

        public override Dictionary<string, string> Serialize()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("gold", gold.ToString());
            return dict;
        }

        public override void Deserialize(Dictionary<string, string> dict)
        {
            gold = Convert.ToInt32(dict["gold"]);
        }

        public EntityType Type()
        {
            return EntityType.GOLD;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int StackNum()
        {
            return 1;
        }

        public int Gold()
        {
            return gold;
        }
    }
}
