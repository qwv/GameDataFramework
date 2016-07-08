using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class DroppackBuilder: Builder 
    {
        private DataCollection collection = new DataCollection();

        private static DroppackBuilder instance;

        public static DroppackBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new DroppackBuilder();
                    instance.collection.Init(ConfigTablePath.DROP_SOURCE);
                }
                return instance;
            }
        }

        public override void Build(Entity entity, params object[] args)
        {
            DroppackEntity packEntity = (DroppackEntity)entity;

            int index = (int)args[0];
            Properties properties = collection.Get(index);
            // Random gold.
            int goldMin = properties.GetIntValue(DroppackEntity.PropName.GOLD_MIN);
            int goldMax = properties.GetIntValue(DroppackEntity.PropName.GOLD_MAX);
            int gold = Random.Range(goldMin, goldMax + 1);
            // Random item.
            List<int> itemList = new List<int>();
            int value = properties.GetIntValue(DroppackEntity.PropName.VALUE);
            int itemNum = properties.GetIntValue(DroppackEntity.PropName.ITEM_NUM);
            for (int i = 0; i < itemNum; i++)
            {
                int itemId = properties.GetIntValue(DroppackEntity.PropName.ITEM + (i + 1) + "_id");
                int itemValue = properties.GetIntValue(DroppackEntity.PropName.ITEM + (i + 1) + "_value");

                if (Random.Range(0f, 1.0f) < itemValue / value)
                {
                    itemList.Add(itemId);
                }
            }

            int capacity = itemList.Count + 1;
            entity.Init(capacity);

            CmdCreateEntity cmd1 = new CmdCreateEntity(EntityType.GOLD, gold);
            packEntity.cells.Add((GoldEntity)cmd1.Execute());

            for (int i = 0; i < capacity; i++)
            {
                int itemId = itemList[i];
                CmdCreateEntity cmd = new CmdCreateEntity(EntityType.ITEM, itemId);
                packEntity.cells.Add((ItemEntity)cmd.Execute());
            }
        }
    }
}
