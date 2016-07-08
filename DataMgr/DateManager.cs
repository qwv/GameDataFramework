using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface IDataManager
    {
    }

    public class DataManager : IDataManager
    {
        private Dictionary<EntityType, Factory> entityFactories;

        private Dictionary<int, Entity> entities;
        private int entityIdCursor;

        private List<Queue<Command>> commandQueues;

        private static DataManager instance;

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                    instance.Init();
                }
                return instance;
            }
        }

        public DataManager GetInstace()
        {
            return instance;
        }

        private void Init()
        {
            entityFactories = new Dictionary<EntityType, Factory>();
            entityFactories.Add(EntityType.ITEM, new StandardFactory<ItemEntity>(ItemBuilder.Instance));
            entityFactories.Add(EntityType.GOLD, new StandardFactory<GoldEntity>());
            entityFactories.Add(EntityType.PACK, new StandardFactory<PackEntity>());
            entityFactories.Add(EntityType.DROPPACK, new StandardFactory<DroppackEntity>(DroppackBuilder.Instance));
            entityFactories.Add(EntityType.ENEMY, new StandardFactory<EnemyEntity>(EnemyBuilder.Instance));
            entityFactories.Add(EntityType.CLONE, CloneFactory.Instance);

            entities = new Dictionary<int, Entity>(); 
            entityIdCursor = 0;

            for (int i = 0; i < (int)Command.Priority.COUNT; i++)
            {
                commandQueues.Add(new Queue<Command>()); 
            }
        }

        private int GenerateEntityId()
        {
            return entityIdCursor++;
        }

        private Factory FindFactory(EntityType type)
        {
            return entityFactories[type];
        }

        public IAvater CreateEntity(EntityType type, params object[] args)
        {
            int entityId = GenerateEntityId(); 
            Entity entity = FindFactory(type).Create(entityId, args);
            entities.Add(entityId, entity);
            return (IAvater)entity;
        }

        public void SaveEntities()
        {

        }
    }
}
