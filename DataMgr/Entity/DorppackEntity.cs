using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class DroppackEntity: Entity, IDroppackAvater
    {
        private class PropName
        {
            public const string ID = "id";
            public const string GOLD_MIN = "gold_min";
            public const string GOLD_MAX = "gold_max";
            public const string VALUE = "value";
            public const string ITEM_NUM = "item_num";
            public const string ITEM = "item";
        }

        private int capacity;

        private List<Entity> cells;

        public override void Init(int entityId)
        {
            this.entityId = entityId;
            Generate();
        }

        public override void Save()
        {
        }

        public override object Clone()
        {
            return new DroppackEntity();
        }

        public void Generate()
        {
            // Random gold.
            int goldMin = properties.GetIntValue(PropName.GOLD_MIN);
            int goldMax = properties.GetIntValue(PropName.GOLD_MAX);
            int gold = Random.Range(goldMin, goldMax + 1);

            // Random item.
            List<int> itemList = new List<int>();
            int value = properties.GetIntValue(PropName.VALUE);
            int itemNum = properties.GetIntValue(PropName.ITEM_NUM);
            for (int i = 0; i < itemNum; i++)
            {
                int itemId = properties.GetIntValue(PropName.ITEM + (i + 1) + "_id");
                int itemValue = properties.GetIntValue(PropName.ITEM + (i + 1) + "_value");

                if (Random.Range(0f, 1.0f) < itemValue / value)
                {
                    itemList.Add(itemId);
                }
            }

            capacity = itemList.Count + 1;
            cells = new List<Entity>(capacity);

            CmdCreateEntity cmd1 = new CmdCreateEntity(EntityType.GOLD, 0);
            cmd1.Execute();
        }

        public EntityType Type()
        {
            return EntityType.DROPPACK;
        }

        public int EntityId()
        {
            return entityId;
        }

        public int Capacity()
        {
            return capacity;
        }

        public IAvater Cells(int id)
        {
            return (IAvater)cells[id];
        }
    }
}
