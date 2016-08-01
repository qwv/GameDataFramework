using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class DroppackBuilder: Builder 
    {
        private static DroppackBuilder instance;

        public static DroppackBuilder Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new DroppackBuilder();
                }
                return instance;
            }
        }

        /// <summary>
        /// Build drop pack entity
        /// </summary>
        /// <param name="entity">entity input</param>
        /// <param name="args">args[0]:drop id</param>
        public override void Build(Entity entity, params object[] args)
        {
            DroppackEntity packEntity = (DroppackEntity)entity;

            int id = (int)args[0];
            PropertiesWrapper properties = DBProxy.Find(Table.DROP, "id", id.ToString());
            // Random gold
            int goldMin = properties.GetIntValue(DroppackEntity.PropName.GOLD_MIN);
            int goldMax = properties.GetIntValue(DroppackEntity.PropName.GOLD_MAX);
            int gold = Random.Range(goldMin, goldMax + 1);
            // Random item
            List<int> itemList = new List<int>();
            float value = properties.GetFloatValue(DroppackEntity.PropName.VALUE);
            int itemNum = properties.GetIntValue(DroppackEntity.PropName.ITEM_NUM);
            for (int i = 0; i < itemNum; i++)
            {
                int itemId = properties.GetIntValue(DroppackEntity.PropName.ITEM + (i + 1) + "_id");
                float itemValue = properties.GetFloatValue(DroppackEntity.PropName.ITEM + (i + 1) + "_value");

                if (Random.Range(0f, 1.0f) < itemValue / value)
                {
                    itemList.Add(itemId);
                }
            }

            // Create pack
            int capacity = itemList.Count + 1;
            packEntity.Init(capacity);

            GoldEntity goldEntity = (GoldEntity)EntityManager.Instance.CreateEntity(EntityType.GOLD, gold);
            packEntity.PutInto(goldEntity);

            for (int i = 0; i < itemList.Count; i++)
            {
                int itemId = itemList[i];
                ItemEntity itemEntity = (ItemEntity)EntityManager.Instance.CreateEntity(EntityType.ITEM, itemId);
                packEntity.PutInto(itemEntity);
            }
        }
    }
}
